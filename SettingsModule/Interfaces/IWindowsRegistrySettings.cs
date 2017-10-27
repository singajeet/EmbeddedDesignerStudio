/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 12:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Specialized;
using Core.Interfaces.Modules;
using Microsoft.Win32;

namespace SettingsModule.Interfaces
{
	/// <summary>
	/// Description of IRegistrySettingsService.
	/// </summary>
	public interface IWindowsRegistrySettings : ISettings
	{
		NameValueCollection Settings { get; }
		RegistryKey AddRegistrySettingSection(string name);
		RegistryKey AddRegistrySettingSection(RegistryKey key, string name);
		void AddRegistrySetting(string name, string value);
		void AddRegistrySetting(RegistryKey key, string name, string value);
		void DeleteRegistrySection(string name);
		void DeleteRegistrySection(RegistryKey key, string name);
		void DeleteRegistrySetting(string name);
		void DeleteRegistrySetting(RegistryKey key, string name);
	}
}
