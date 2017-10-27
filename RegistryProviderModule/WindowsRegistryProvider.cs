/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 10:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Interfaces.Modules;
using Core.Providers;
using Microsoft.Win32;

namespace RegistryProviderModule
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	
	public class WindowsRegistryProvider : BaseProvider, IWindowsRegistryProvider
	{
		private RegistryKey _root;
        private RegistryKey _currentNode;
        private const string _appName = "EmbeddedDesignerStudio";
        
        public WindowsRegistryProvider() {
            this._root = Registry.CurrentUser.CreateSubKey(_appName);
            this._currentNode = this._root;
        }
        
        public RegistryKey Root {
            get { return this._root; }
        }

        public RegistryKey CurrentNode {
            get { return this._currentNode; }
        }

        public RegistryKey CreateRegistryKey(string p_name) {
            if (this._root != null)
            {
                this._currentNode = this._root.CreateSubKey(p_name);
                return this._currentNode;
            }

            return null;
        }
        
        public RegistryKey CreateRegistryUnderCurrentKey(string p_name){
        	if(this._currentNode != null){
        		return this._currentNode.CreateSubKey(p_name);        		
        	}        	
        	return null;
        }

        public RegistryKey OpenRegistryKey(string p_name) {
            if (this._root != null)
            {
                this._currentNode = this._root.OpenSubKey(p_name, true);
                return this._currentNode;
            }
            return null;
        }        

        public bool DeleteRegistryKey(string p_name) {
            if (p_name == _appName || p_name.Contains(_appName))
                return false;

            this._root.DeleteSubKey(p_name);
            this._currentNode = this._root;
            return true;
        }
        
        public bool DeleteRegistryUnderCurrentKey(string p_name){
        	if(p_name.Equals(_appName) || p_name.Contains(_appName))
                return false;
        	
        	if(this._currentNode == null)
        		return false;
        	
        	this._currentNode.DeleteSubKey(p_name);
        	return true;
        }


        public void CloseRegistry()
        {
            this._currentNode.Close();
            this._root.Close();
        }
	}
}