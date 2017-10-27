/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 10:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Interfaces;
using Core.Interfaces.Modules;
using Core.Providers;
using Microsoft.Win32;
using System.ComponentModel;

namespace NameProviderModule
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	
	public class NameProvider : BaseProvider, INameProvider
	{
		private const string _nameServiceRegistryKey = "NameProvider";		
				
		IWindowsRegistryProvider _registryService;
		
		private IWindowsRegistryProvider RegistryService{
			get { return this._registryService; }
		}
		
		/*Should be called during installation of the application*/
        public void RegisterName(string p_name) {
            RegistryService.CreateRegistryKey(_nameServiceRegistryKey);
            RegistryKey v_namesKey = RegistryService.CreateRegistryUnderCurrentKey("Names");
            
            v_namesKey.SetValue(p_name, 0);
            v_namesKey.Close();

            RegistryService.CloseRegistry();
        }

        public RegistryKey GetNamesRegistryKey() {
            RegistryService.CreateRegistryKey(_nameServiceRegistryKey);
            return RegistryService.CreateRegistryUnderCurrentKey("Names");
        }

        public string GetUniqueIdForName(string p_name) {
            RegistryKey v_namesKey = this.GetNamesRegistryKey();           

            string v_s_counter = (string)v_namesKey.GetValue(p_name);
            int v_counter = Convert.ToInt32(v_s_counter);
            v_counter = v_counter + 1;
            v_namesKey.SetValue(p_name, v_counter);
            v_namesKey.Close();

            return p_name + v_counter;
        }        
    }
}