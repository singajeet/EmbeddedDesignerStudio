/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 11:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Specialized;
using System.Configuration;
using Core.Interfaces;
using Core.Services;
using SettingsModule.Interfaces;
using Core.Interfaces.Modules;
using log4net;
using Microsoft.Practices.Unity;

namespace SettingsModule
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	
	public class AppSettings : IAppSettings
	{
		#region Private Properties
		
		private ILog _logger;
		
		private Configuration _configuration;
		
        [Dependency]
		private ILog Logger{
			get { return this._logger; }
            set { this._logger = value; }
		}
		#endregion
		
		#region Constructor
		public AppSettings(){
			
		}
		#endregion
		
		#region Private Members
		private Configuration ExeConfiguration{
			get {if(this._configuration == null)
				Logger.Debug("Trying to open the EXE configuration file");
			 	this._configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);			
				
			 	Logger.Debug("EXE configuration file has been opened successfully");
			 	Logger.Debug(String.Format("Configuration file exist in the following location => [{0}]", _configuration.FilePath));
			 	return this._configuration;
			}
		}
		
		private AppSettingsSection ApplicationSettings{
			get { return ExeConfiguration.AppSettings; }
		}
		
		private KeyValueConfigurationCollection ConfCollection{
			get { return ApplicationSettings.Settings; }
		}
		
		private void RefreshSettings(){
			ConfigurationManager.RefreshSection("appSettings");
			Logger.Debug("AppSettings have been refreshed successfully");
		}	
		
		#endregion
		
		#region Public Properties
		public NameValueCollection Settings{
			get { return ConfigurationManager.AppSettings; }
		}
		
		#endregion
		
		#region Public Members
		
		public void AddAppSetting(string name, string value){
			ConfCollection.Add(name, value);
			Logger.Debug(String.Format("New AppSetting has been added but not saved yet => [{0} = {1}]", name, value));
			Save();			
		}
		
		public void RemoveAppSettings(string name){
			ConfCollection.Remove(name);
			Logger.Debug(String.Format("[{0}] has been removed from AppSettings but not saved yet => [{0}]", name));
			Save();
		}
		
		public void Save(){
			ExeConfiguration.Save(ConfigurationSaveMode.Modified);
			Logger.Debug("Changes to the AppSettings have been saved successfully");
			RefreshSettings();
		}
		
		#endregion
	}
}