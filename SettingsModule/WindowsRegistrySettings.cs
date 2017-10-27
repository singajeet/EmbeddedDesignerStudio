/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 12:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Specialized;
using Core.Interfaces;
using Core.Interfaces.Modules;
using Core.Services;
using Microsoft.Win32;
using SettingsModule.Interfaces;
using log4net;
using Microsoft.Practices.Unity;

namespace SettingsModule
{
	/// <summary>
	/// Description of RegistrySettingsService.
	/// </summary>
	
	public class WindowsRegistrySettings : IWindowsRegistrySettings
	{
		#region Private Properties
		private const string _settingsRegistryKey = "WindowsRegistrySettings";
		private RegistryKey _currentSettingsKey = null;
		private RegistryKey _rootSettingsKey = null;
		private NameValueCollection _settings = new NameValueCollection();
		
		
		ILog _logger;
		
		
		IWindowsRegistryProvider _registryProvider;
		
        [Dependency]
		private ILog Logger{
			get { return this._logger; }
            set { this._logger = value; }
		}
		
		private IWindowsRegistryProvider RegistryProvider{
			get { return this._registryProvider; }
		}
		
		#endregion
		
		#region Constructors
		public WindowsRegistrySettings()
		{
			_rootSettingsKey = RegistryProvider.CreateRegistryKey(_settingsRegistryKey);
			_currentSettingsKey = _rootSettingsKey;
		}
		
		#endregion
		
		#region Private Methods
		#endregion
		
		#region Public Properties
		public NameValueCollection Settings{
			get {
				this._settings.Clear();
				string[] names = _currentSettingsKey.GetValueNames();
				for(int i=0; i<names.Length; i++){
					this._settings.Add(names[i], _currentSettingsKey.GetValue(names[i]) as String);
				}
				
				return this._settings;
			}
		}
		#endregion
		
		#region Public Methods
		public RegistryKey AddRegistrySettingSection(string name){
			_currentSettingsKey = RegistryProvider.CreateRegistryUnderCurrentKey(name);
			return _currentSettingsKey;
		}
		
		public RegistryKey AddRegistrySettingSection(RegistryKey key, string name){
			if(key != null){
				return key.CreateSubKey(name);
			}
			return null;
		}		
		
		public void AddRegistrySetting(string name, string value){
			if(_currentSettingsKey != null){
				_currentSettingsKey.SetValue(name, value);
			}
		}
		
		public void AddRegistrySetting(RegistryKey key, string name, string value){
			if(key != null){
				key.SetValue(name, value);
			}
		}
		
		public void DeleteRegistrySection(string name){
			if(name.Equals(_settingsRegistryKey) || name.Contains(_settingsRegistryKey))
				return;
			
			RegistryProvider.DeleteRegistryUnderCurrentKey(name);
			_currentSettingsKey = _rootSettingsKey;
		}
		
		public void DeleteRegistrySection(RegistryKey key, string name){
			if(key != null){
				key.DeleteSubKey(name);
			}
		}
		
		public void DeleteRegistrySetting(string name){
			if(_currentSettingsKey != null){
				_currentSettingsKey.DeleteValue(name);
			}
		}
		
		public void DeleteRegistrySetting(RegistryKey key, string name){
			if(key != null){
				key.DeleteValue(name);
			}
		}
		#endregion
	}
}
