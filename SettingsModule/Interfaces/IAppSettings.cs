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

namespace SettingsModule.Interfaces
{
	/// <summary>
	/// Description of IAppSettingsService.
	/// </summary>
	public interface IAppSettings : ISettings
	{
		NameValueCollection Settings { get; }
		void AddAppSetting(string name, string value);
		void RemoveAppSettings(string name);
		void Save();
	}
}
