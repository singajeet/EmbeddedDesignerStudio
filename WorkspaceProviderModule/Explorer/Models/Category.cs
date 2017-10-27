/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 18:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WorkspaceProviderModule.Explorer.Interfaces;
using BindingModule;

namespace WorkspaceProviderModule.Explorer.Models
{
	/// <summary>
	/// Description of CategoryAsNodeItemModel.
	/// </summary>
    public class Category : PropertyChangedNotifier, ICategory
	{
		private string _name;
		private LanguageTypeCollection _langTypeCollection;

		public Category(){
			this._langTypeCollection = new LanguageTypeCollection();
		}
			
		public string Name {
			get { return this._name; }
            set { this._name = value; 
                NotifyPropertyChanged(() => Name); 
            }
		}
		
		public LanguageTypeCollection LanguageTypes {
			get { return this._langTypeCollection; }
            set { this._langTypeCollection = value; 
                NotifyPropertyChanged(() => LanguageTypes); 
            }
		}      
        
	}
	
	public class CategoryCollection : ObservableCollection<ICategory>, IEnumerable
	{
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

        public ICategory Item(int index) {
            return Items[index];
        }
		
		public ICategory find(string categoryName){
			foreach(ICategory category in this.Items){
				if(category.Name.Equals(categoryName))
					return category;
			}
			
			return null;
		}

        public ICategory find(ICategory category)
        {
            foreach (ICategory v_category in this.Items)
            {
                if (category.Name.Equals(v_category.Name))
                    return category;
            }

            return null;
        }
		
		public bool Contains(string categoryName){
			foreach(ICategory category in this.Items){
				if(category.Name.Equals(categoryName))
					return true;
			}
			
			return false;
		}

        public bool Contains(ICategory category)
        {
            foreach (ICategory v_category in this.Items)
            {
                if (category.Name.Equals(v_category.Name))
                    return true;
            }

            return false;
        }

        #endregion
	}
}
