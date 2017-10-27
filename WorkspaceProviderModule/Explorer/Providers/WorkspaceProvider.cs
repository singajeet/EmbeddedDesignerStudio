/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/24/2017
 * Time: 01:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core;
using Core.Interfaces;
using Core.Interfaces.Providers;
using Core.Providers;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TemplateProviderModule.Interfaces;
using TemplateProviderModule.Models;
using WorkspaceProviderModule.Explorer.Interfaces;
using WorkspaceProviderModule.Explorer.Models;
using Core.Interfaces.Modules;
using log4net;
using System.Collections;

namespace WorkspaceProviderModule.Explorer.Providers
{
	/// <summary>
	/// Description of WorkspaceProvider.
	/// </summary>
	
	public class WorkspaceProvider : BaseProvider, IWorkspaceProvider
	{
		
		private ITemplateProvider _templateProvider;		
		private string _templatePath;
		private string[] _templateFiles;
		private string _templateFilter;
        private CategoryCollection _categories;
        private LanguageTypeCollection _languageTypes;
        private TemplateModelCollection _templates;
        private IList<TemplateModelCollection> _templateFilesCollection;
				
		public string[] TemplateFiles{
			get { return this._templateFiles; }
			set { this._templateFiles = value; 
				OnPropertyChanged(() => TemplateFiles);
			}
		}
		
		public string TemplatePath{
			get { return this._templatePath; }
			set { this._templatePath = value;
				OnPropertyChanged(() => TemplatePath);
			}
		}
		
		public string TemplateFilter{
			get { return this._templateFilter; }
			set { this._templateFilter = value;
				OnPropertyChanged(() => TemplateFilter);
			}
		}
		
		
		public WorkspaceProvider(ITemplateProvider templateProvider, ILog logger)
		{
			this._name = "WorkspaceProvider";
			this._description = "Provides service to work with Workspace";
			_logger = logger;
			_templateProvider = templateProvider;

            _templatePath = @"C:\Users\Admin\Documents\Visual Studio 2010\Projects\EmbeddedDesignerStudio\TemplateProviderModule\Templates";
			Logger.Debug(String.Format("Path configured to search templates => {0}", _templatePath));
			
			_templateFilter = "*.xml";
			Logger.Debug(String.Format("Following filters will be applied during search => {0}", _templateFilter));
			
			TemplateFiles = Directory.GetFiles(_templatePath, _templateFilter);
			
			Logger.Info(String.Format("{0} templates found as a search result", TemplateFiles.Length));
			
			Logger.Info( this._name + " instance has been created successfully");
            
            _templateFilesCollection = new List<TemplateModelCollection>();
		}
				
		private IList<TemplateModelCollection> GetTemplateCollections(){
						
			TemplateModelCollection v_collection = null;
            _templateFilesCollection.Clear();
			
			foreach(string v_templateFile in _templateFiles){
                Logger.Debug("\n=====================================START TEMPLATE FILE=======================================");
				Logger.Debug(String.Format("Processing template file => {0}", v_templateFile));
				
				_templateProvider.LoadTemplate(v_templateFile);
				
				Logger.Debug(String.Format("Template file '{0}' loaded successfully", v_templateFile));
				
				v_collection = _templateProvider.GetAllTemplates();
				
				Logger.Debug(String.Format("Got {0} templates from the processed file", v_collection.Count));
                Logger.Debug("=======================================END TEMPLATE FILE=======================================\n");

                _templateFilesCollection.Add(v_collection);
				//yield return v_collection;
			}
			//yield break;
            Logger.Debug(String.Format("Returning {0} number of TemplateModelCollection(s), each containing ITemplate Models", _templateFilesCollection.Count));

            return _templateFilesCollection;
		}

        public CategoryCollection GetCategories()
        {
            if (this._categories != null && this._categories.Count > 0)
                return this._categories;
		
			Logger.Info("Loading all categories available in the configured templates");
            IList<TemplateModelCollection> collections = null;
       
            if(_templateFilesCollection == null || _templateFilesCollection.Count == 0)
			    collections = GetTemplateCollections();

            Logger.Debug(String.Format("Number of collections to parse => {0}", collections.Count));

			
			this._categories = new CategoryCollection();
			this._languageTypes = new LanguageTypeCollection();
			
			foreach(TemplateModelCollection collection in collections){
                Logger.Debug("\n-----------------------------------START TEMPLATE COLLECTION-----------------------------------");

				Logger.Debug(String.Format("Current collection in the iterator has {0} templates", collection.Count));
				
				foreach(ITemplate template in collection){
                    Logger.Debug("\n_______________________________START TEMPLATE______________________________________________");
					Logger.Debug(String.Format("Processing template '{0}' to get unique Categories & LanguageTypes", template.Name));
					
					ProjectCollection projects = new ProjectCollection();
					
					Logger.Debug(String.Format("Current template in the iterator has {0} projects", template.Projects.Count));
					foreach(IType projectType in template.Projects){
							IProject project = new Project();
							project.Name = projectType.DisplayName;
							project.Icon = projectType.IconPath;
							
							Logger.Debug(String.Format("Project's ('{0}') absolute Icon path provided [{1}]", project.Name,
							             this.TemplatePath + projectType.IconPath));
							
							Logger.Debug("Project Icon has been loaded successfully");
							
							projects.Add(project);
							
							Logger.Debug(String.Format("Project '{0}' has been added to project collection", project.Name));
					}
					
					if(this._categories.Count == 0){					
						
						Logger.Info("Categories collection is empty, adding new categories now");
						
						ILanguageType langType = new LanguageType();
						langType.Name = template.LanguageType;
						langType.Projects = projects;
						Logger.Debug(String.Format("Found new LanguageType '{0}'", langType.Name));
						
						ICategory category =  new Category();
						category.Name = template.Category;
						category.LanguageTypes.Add(langType);		
						Logger.Debug(String.Format("Found new Category '{0}'", category.Name));
						
						this._categories.Add(category);
						
						Logger.Debug(String.Format("'{0}' LanguageType added to Category '{1}'", langType.Name, category.Name));
						Logger.Debug(String.Format("{0} projects added to LanguageType '{1}'", projects.Count, langType.Name));
					} else {
                        bool isCategoryAlreadyExist = this._categories.Contains(template.Category);
						
						if(isCategoryAlreadyExist){
							ICategory category = this._categories.find(template.Category);
							bool isLangTypeAlreadyExist = category.LanguageTypes.Contains(template.LanguageType);
							
							if(isLangTypeAlreadyExist){
								ILanguageType langType = category.LanguageTypes.find(template.LanguageType);
								langType.Projects.AddRange(projects);
								Logger.Debug(String.Format("{0} projects added to LanguageType '{1}'", projects.Count, langType.Name));
								
							} else {
								ILanguageType langType = new LanguageType();
								langType.Name = template.LanguageType;
								langType.Projects = projects;
								
								Logger.Debug(String.Format("Found new LanguageType '{0}'", langType.Name));
								
								category.LanguageTypes.Add(langType);
								
								Logger.Debug(String.Format("'{0}' LanguageType added to Category '{1}'", langType.Name, category.Name));
								Logger.Debug(String.Format("{0} projects added to LanguageType '{1}'", projects.Count, langType.Name));
							}
						} else {
							ILanguageType langType = new LanguageType();
							langType.Name = template.LanguageType;
							langType.Projects = projects;
							
							Logger.Debug(String.Format("Found new LanguageType '{0}'", langType.Name));
							
							ICategory category =  new Category();
							category.Name = template.Category;
							
							Logger.Debug(String.Format("Found new Category '{0}'", category.Name));
							
							category.LanguageTypes.Add(langType);											
							
							this._categories.Add(category);
							Logger.Debug(String.Format("'{0}' LanguageType added to Category '{1}'", langType.Name, category.Name));
							Logger.Debug(String.Format("{0} projects added to LanguageType '{1}'", projects.Count, langType.Name));
						}
					}
                    Logger.Debug("_______________________________END TEMPLATE______________________________________________\n");
				}
                Logger.Debug("-----------------------------------END TEMPLATE COLLECTION-----------------------------------\n");
			}
			return this._categories;
		}
		
		public TemplateModelCollection GetTemplates(){

            if (this._templates != null && this._templates.Count > 0)
                return this._templates;

			Logger.Debug("Iterating through all available template collections");

            this._templates = new TemplateModelCollection();
            IList<TemplateModelCollection> collections = null;
            
            if(_templateFilesCollection == null || _templateFilesCollection.Count == 0)
                collections = GetTemplateCollections();
			
			foreach(TemplateModelCollection collection in collections){
				foreach(ITemplate template in collection){
					
                    this._templates.Add(template);
				}
			}
			
            return this._templates;
		}



        public TemplateModelCollection GetTemplates(ICategory category)
        {
            TemplateModelCollection filtered_templates = new TemplateModelCollection();
            if (this._templates == null || this._templates.Count == 0)
                this._templates = GetTemplates();

            Logger.Debug(String.Format("Applying filter [Category = '{0}'] on all templates", category.Name));

            foreach (ITemplate template in this._templates) {
                if (template.Category.Equals(category.Name))
                    filtered_templates.Add(template);
            }
            
            return filtered_templates;
        }

        public TemplateModelCollection GetTemplates(ICategory category, ILanguageType langType) {
            TemplateModelCollection filtered_templates = new TemplateModelCollection();
            if (this._templates == null || this._templates.Count == 0)
                this._templates = GetTemplates();

            Logger.Debug(String.Format("Applying filter [Category = '{0}' And LanguageType = '{1}'] on all templates", category.Name, langType.Name));

            foreach (ITemplate template in this._templates)
            {
                if (template.Category.Equals(category.Name) && template.LanguageType.Equals(langType.Name))
                    filtered_templates.Add(template);
            }

            return filtered_templates;
        }

        public IProject GetProjectTemplate(ICategory category, ILanguageType langType, IProject project) {

            if (category == null || langType == null || project == null)
                return null;

            if (project.Id == null || category.Name == null || langType.Name == null)
                return null;

            if (this._templates == null || this._templates.Count == 0)
                this._templates = GetTemplates();

            Logger.Debug(String.Format("Applying filter [Category = '{0}' And LanguageType = '{1}'] on all templates", category.Name, langType.Name));

            foreach (ITemplate template in this._templates)
            {
                if (template.Category.Equals(category.Name) && template.LanguageType.Equals(langType.Name)) {
                    foreach (IProject v_project in template.Projects) {
                        if (project.Id == v_project.Id)
                            return v_project;
                    }
                }                    
            }
            return null;
        }

        public IProject GetProjectTemplate(ICategory category, ILanguageType langType, Guid projectId)
        {

            if (category == null || langType == null || projectId == null)
                return null;

            if (category.Name == null || langType.Name == null)
                return null;

            if (this._templates == null || this._templates.Count == 0)
                this._templates = GetTemplates();

            Logger.Debug(String.Format("Applying filter [Category = '{0}' And LanguageType = '{1}' And Project.Id = '{2}'] on all templates", category.Name, langType.Name, projectId));

            foreach (ITemplate template in this._templates)
            {
                if (template.Category.Equals(category.Name) && template.LanguageType.Equals(langType.Name))
                {
                    foreach (IProject v_project in template.Projects)
                    {
                        if (projectId == v_project.Id)
                            return v_project;
                    }
                }
            }
            return null;
        }
		       
	}
}
