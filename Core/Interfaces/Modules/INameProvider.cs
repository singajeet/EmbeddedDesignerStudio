/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 10:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;
using Core.Interfaces.Services;
using Core.Interfaces.Providers;

namespace Core.Interfaces.Modules
{
	/// <summary>
	/// Description of INamingService.
	/// </summary>
	public interface INameProvider
	{
		void RegisterName(string p_name);
		RegistryKey GetNamesRegistryKey();
		string GetUniqueIdForName(string p_name);
	}
}
