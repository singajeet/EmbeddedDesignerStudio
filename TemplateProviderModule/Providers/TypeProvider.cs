/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 9/28/2017
 * Time: 11:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using Core;
using Core.Interfaces;
using Core.Providers;
using TemplateProviderModule.Interfaces;
using TemplateProviderModule.Models;
using Core.Interfaces.Modules;
using log4net;

namespace TemplateProviderModule.Providers
{
	/// <summary>
	/// Description of TypeService.
	/// </summary>
	
	public class TypeProvider : BaseProvider, ITypeProvider
	{
		private TypeModelCollection _collection;		
		
		public TypeProvider(ILog logger)
		{
			this._name = "TypeService";
			this._description = "Provides service to create instances of various project item types model.";
			this._collection = new TypeModelCollection();
			this._logger = logger;
			
			Logger.Info(this._name + "instance has been created successfully");
		}

		#region ITypeService implementation

		public IType CreateInstance()
		{
			IType type = new TypeModel();
			this._collection.Add(type);			
			return type;
		}
		
		public I CreateInstance<I>(string p_typeName, string assembly, string assemblyPath, string rootNamespace) where I : class{
			Logger.Debug(String.Format(
				"Creating instance with following details => TYPENAME [{0}] | ASSEMBLY [{1}] | ASSYPATH [{2}] | NAMESPACE [{3}]", 
				p_typeName, assembly, assemblyPath, rootNamespace
			));
			
			string v_assemblyPath = assemblyPath + "\\" + assembly;
            
			Assembly v_assembly = Assembly.LoadFrom(v_assemblyPath);
			
			string fullTypeName = rootNamespace + "." + p_typeName + "Model";
			Logger.Debug(String.Format("Creating instance of type [{0}] from the Activator assembly", fullTypeName));
			
            Type v_type = Type.GetType(fullTypeName);            
            return Activator.CreateInstance(v_type) as I; 
		}

		public TemplateProviderModule.Models.TypeModelCollection Types {
			get {
				return this._collection;
			}
		}
		
		public Type GetInterfaceTypeFromString(string interfaceName, string assembly, string assemblyPath, string rootNamespace)
        {
			Logger.Debug(String.Format(
				"Searching for Interface with following details => TYPENAME [{0}] | ASSEMBLY [{1}] | ASSYPATH [{2}] | NAMESPACE [{3}]", 
				interfaceName, assembly, assemblyPath, rootNamespace
			));
			
            string v_assemblyPath = assemblyPath + "\\" + assembly;
            Assembly v_assembly = Assembly.LoadFrom(v_assemblyPath);
            
            string interface_name = rootNamespace + "." + interfaceName;
            Logger.Debug(String.Format("Trying to get Interface [{0}] from assembly", interface_name));
            
            Type v_type = v_assembly.GetType(interface_name);
            return v_type;
        }

		#endregion
	}
}
