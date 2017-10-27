/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 10:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;

namespace Core.Interfaces.Modules
{
	/// <summary>
	/// Description of IRegistryService.
	/// </summary>
	public interface IWindowsRegistryProvider
	{
		RegistryKey Root { get; }
		RegistryKey CurrentNode { get; }
		RegistryKey CreateRegistryKey(string p_name);
		RegistryKey CreateRegistryUnderCurrentKey(string p_name);
		RegistryKey OpenRegistryKey(string p_name);
		bool DeleteRegistryKey(string p_name);
		bool DeleteRegistryUnderCurrentKey(string p_name);
		void CloseRegistry();
	}
}
