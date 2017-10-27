/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 9/28/2017
 * Time: 9:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using Core;
using Core.Interfaces;
using Core.Interfaces.Providers;
using Core.Providers;
using TemplateProviderModule.Interfaces;
using TemplateProviderModule.Models;
using Core.Interfaces.Modules;
using log4net;

namespace TemplateProviderModule.Providers
{
	/// <summary>
	/// Description of TemplateService.
	/// </summary>
	
	public class TemplateProvider : BaseProvider, ITemplateProvider
	{

		private XmlDocument _document;
        private TemplateModelCollection _templates;
        private ITypeProvider _typeProvider;
		
        
		public TemplateProvider(ITypeProvider typeProvider, ILog logger)
		{
			this._name = "TemplateService";
			this._description = "Provides service to create instances of template model.";
			this._typeProvider = typeProvider;			
			this._logger = logger;
			_templates = new TemplateModelCollection();
			
			Logger.Info(this._name + " instance has been created successfully");
		}
		
		public TemplateModelCollection Templates{
			get { return this._templates; }
		}
		
		#region public methods
		public ITemplate CreateInstance(){
			ITemplate template = new TemplateModel();
			return template;
		}

		public void LoadTemplate(string p_path){
			
			Logger.Info(String.Format("Trying to load template document available at path => '{0}'", p_path));				
			
			try
	        {
	            _document = new XmlDocument();
	            _document.Load(p_path);
	
	            Logger.Info("Template document successfully parsed and loaded in memory");

                _templates = new TemplateModelCollection();    
	            _templates = LoadAllTemplates();
	        }
	        catch (Exception ex) {
				Logger.Error(String.Format("Unable to process template document => '{0}'", p_path), ex);	
				throw ex;
	        }							
			
		}
		#endregion
		
		#region private methods
		
		private TemplateModelCollection LoadAllTemplates()
        {
			
			try{
		        XmlNodeList v_templateNodes = _document.SelectNodes("//Templates/Template");
		        Logger.Info(String.Format("{0} templates found in the Xml document", v_templateNodes.Count));
		
		        foreach (XmlNode v_xmlTemplate in v_templateNodes) {
		
		            ITemplate v_template = new TemplateModel();
		            int id = Convert.ToInt32(v_xmlTemplate.Attributes["Id"].Value);
		            v_template.TemplateId = id;
		            v_template.Name = v_xmlTemplate.Attributes["Name"].Value;
		                
		            Logger.Debug(String.Format("Template instance created for template with Id: [{0}] and Name: [{1}]", 
		                	            v_template.TemplateId, v_template.Name));
		                
		            v_template.LanguageType = v_xmlTemplate.Attributes["LanguageType"].Value;
		            v_template.Author = v_xmlTemplate.Attributes["Author"].Value;
		            v_template.Category = v_xmlTemplate.Attributes["Category"].Value;
		            v_template.Description = v_xmlTemplate.Attributes["Description"].Value;
		            v_template.Revision = v_xmlTemplate.Attributes["Revision"].Value;
		            v_template.ReleaseDate = GetReleaseDateFromString(v_xmlTemplate.Attributes["ReleaseDate"].Value);
		            v_template.WorkspaceAssembly = v_xmlTemplate.Attributes["WorkspaceAssembly"].Value;
		            v_template.WorkspaceAssemblyPath = v_xmlTemplate.Attributes["WorkspaceAssemblyPath"].Value;
		            v_template.WorkspaceRootNamespace = v_xmlTemplate.Attributes["WorkspaceRootNamespace"].Value;
		            v_template.TypeObjectsAssembly = v_xmlTemplate.Attributes["TypeObjectsAssembly"].Value;
		            v_template.TypeObjectsAssemblyPath = v_xmlTemplate.Attributes["TypeObjectsAssemblyPath"].Value;
		            v_template.TypeObjectsRootNamespace = v_xmlTemplate.Attributes["TypeObjectsRootNamespace"].Value;                
		
		            XmlNode projectsNode = v_xmlTemplate.ChildNodes[0];                
		            var projectCollection = new TypeModelCollection();                
		            PopulateProjects(projectsNode, projectCollection, v_template);
		            v_template.Projects = projectCollection;
		
		            this._templates.Add(v_template);
		            Logger.Debug(String.Format("{0} template has been added to the collection", v_template.Name));
		        }
			}catch(Exception ex){
				Logger.Error("Template load process has been failed due to following error =>", ex);	
				throw ex;
			}
				
	        return this._templates;		
			
        }
		
		private void PopulateProjects(XmlNode projectsNode, TypeModelCollection projectCollection, ITemplate p_template)
		{			
			Logger.Info(String.Format("{0} projects found in template '{1}'", projectsNode.ChildNodes.Count, p_template.Name));
			
			foreach(XmlNode v_child in projectsNode.ChildNodes){
				Logger.Debug(String.Format("Creating instance for object type => '{0}'", v_child.Name));
				
				IType v_type = GetTypeForName(v_child.Name, v_child.ChildNodes, p_template.TemplateId, p_template);
				v_type.Interface = _typeProvider.GetInterfaceTypeFromString(v_child.Attributes["interface"].Value, 
				                                                           p_template.WorkspaceAssembly, 
				                                                           p_template.WorkspaceAssemblyPath, 
				                                                           p_template.WorkspaceRootNamespace);
				v_type.DisplayName = v_child.Attributes["name"].Value;
				v_type.TypeId = Convert.ToInt32(v_child.Attributes["id"].Value);
				v_type.IconPath = v_child.Attributes["icon"].Value;
				
				projectCollection.Add(v_type);
			}
			Logger.Info(String.Format("All projects have been loaded successfully from template '{0}'", p_template));
		}
		
		private IType GetTypeForName(string p_parent, XmlNodeList p_xmlNodeList, int id, ITemplate p_template)
        {
			try{
				Logger.Debug(String.Format("Calling 'TypeService' to get '{0}' object instance", p_parent));
				
	        	IType v_parentType = _typeProvider.CreateInstance<IType>(p_parent, p_template.TypeObjectsAssembly,
				                                                       p_template.TypeObjectsAssemblyPath,
				                                                       p_template.TypeObjectsRootNamespace);
	            v_parentType.TypeName = p_parent;
	            v_parentType.TemplateId = id;
	
	            Logger.Debug(String.Format("{0} childs found for object type '{1}'", p_xmlNodeList.Count, p_parent));
	            if (p_xmlNodeList.Count > 0)
	            {
	                v_parentType.Childs = new TypeModelCollection();
	                foreach (XmlNode v_child in p_xmlNodeList)
	                {
	                    IType v_type = GetTypeForName(v_child.Name, v_child.ChildNodes, id, p_template);
						
	                    Logger.Debug("Populating following type attribute values from Xml => INTERFACE, NAME & ID");
	                    if(v_child.Attributes["interface"] != null){
	                    	v_type.Interface = _typeProvider.GetInterfaceTypeFromString(v_child.Attributes["interface"].Value, 
					                                                           p_template.WorkspaceAssembly, 
					                                                           p_template.WorkspaceAssemblyPath, 
					                                                           p_template.WorkspaceRootNamespace);
	                    	
	                    	Logger.Debug(String.Format("INTERFACE => '{0}'", v_type.Interface));
	                    }
	                    
	                    if(v_child.Attributes["name"] != null){
	                    	if(v_child.Attributes["name"].Value != null)
	                    		v_type.DisplayName = v_child.Attributes["name"].Value;
	                    	
	                    	Logger.Debug(String.Format("NAME => '{0}'", v_type.DisplayName));
	                    }
	                    
	                    if(v_child.Attributes["id"] != null){
	                    	if(v_child.Attributes["id"].Value != null)
	                    		v_type.TypeId = Convert.ToInt32(v_child.Attributes["id"].Value);
	                    	
	                    	Logger.Debug(String.Format("ID => '{0}'", v_type.TypeId));
	                    }
	                    
	                    
	                    v_parentType.Childs.Add(v_type);
	                }
	            } 
	            return v_parentType;
			}catch(Exception ex){
				Logger.Error(String.Format("Failed to create object instance of '{0}' type due to following error =>", p_parent), ex);
			}
			
			return null;
        }
		
		private DateTime GetReleaseDateFromString(string p)
        {
			Logger.Debug(String.Format("Parsing '{0}' string to be converted into DataTime format", p));
			try{
	            int firstSeparatorIndex = p.IndexOf(@"/", 0, StringComparison.CurrentCulture);
	            int month = Convert.ToInt32(p.Substring(0, firstSeparatorIndex));
	
	            int secondSeparatorIndex = p.IndexOf(@"/", firstSeparatorIndex + 1, StringComparison.CurrentCulture);
	            int day = Convert.ToInt32(p.Substring(firstSeparatorIndex + 1, (secondSeparatorIndex - firstSeparatorIndex) - 1));
	
	            int year = Convert.ToInt32(p.Substring(secondSeparatorIndex + 1, (p.Length - secondSeparatorIndex) - 1));
	
	            Logger.Debug(String.Format("String parsed successfully with values as YEAR:'{0}', MONTH:'{1}' & DAY:'{2}'", year, month, day));
	            return new DateTime(year, month, day);
			}catch(Exception ex){
				Logger.Warn(String.Format("Failed to convert string '{0}' to DateTime object due to following error =>", p), ex);
			}
			
			Logger.Warn(String.Format("Current DateTime will be returned as default value => '{0}'", DateTime.Now.ToString()));
			return DateTime.Now;
        }

        private TemplateType GetTypeFromString(string p)
        {
        	Logger.Debug(String.Format("Parsing string '{0}' as enum type [TemplateType]", p));
            return (TemplateType)Enum.Parse(typeof(TemplateType), p, true);
        }
        
        public TemplateModelCollection GetAllTemplates() {
            return this._templates;
        }
		
		#endregion		
	}
}
