/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 19:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WorkspaceProviderModule.Explorer.Interfaces;
using BindingModule;
using log4net;
using Microsoft.Practices.Unity;

namespace WorkspaceProviderModule.Explorer.Models
{
	/// <summary>
	/// Description of LanguageTypeAsNodeItemModel.
	/// </summary>
    public class LanguageType : PropertyChangedNotifier, ILanguageType
	{
		private string _name;
		private ProjectCollection _projects; 
		
		public LanguageType(){            
			this._projects = new ProjectCollection();
		}

        public string Name{
			get { return this._name; }
			set { this._name = value;
            NotifyPropertyChanged(() => Name);
            }
		}
		
		public ProjectCollection Projects{
			get { return this._projects; }
			set { this._projects = value;
            NotifyPropertyChanged(() => Projects);
            }
		}
	}
	
	public class LanguageTypeCollection : ObservableCollection<ILanguageType>{
		#region public members
        
        public void Remove(int index) {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception(String.Format("No project exist at index {0} in this collection", index));
            }
            else
            {
                Items.RemoveAt(index);
            }
        }

        public ILanguageType Item(int index) {
            return Items[index];
        }
		
		public ILanguageType find(string langType){
			foreach(ILanguageType lang in this.Items){
				if(lang.Name.Equals(langType))
					return lang;
			}
			
			return null;
		}
		
		public void AddRange(ObservableCollection<ILanguageType> objects){
			foreach(ILanguageType langType in objects){
				Items.Add(langType);
			}
		}
		
		public bool Contains(string langType){
			foreach(ILanguageType lang in this.Items){
				if(lang.Name.Equals(langType))
					return true;
			}
			
			return false;
		}

        #endregion
	}
}
