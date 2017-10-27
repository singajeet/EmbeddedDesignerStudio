/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 20:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using WorkspaceProviderModule.Explorer.Interfaces;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Nodes
{
	/// <summary>
	/// Description of CategoryNode.
	/// </summary>
	public class CategoryNode : TreeNode, INotifyPropertyChanged
	{
		private ICategory _item;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		public CategoryNode()
		{
			this._item = new Category();
			this.Text = this.Item.Name = "Category#";
		}
		
		public CategoryNode(ICategory item){
			this._item = item;
			this.Text = this.Item.Name;
			CreateChildNodes();
		}
		
		public ICategory Item{
			get { return this._item; }
			set { 
				this._item = value;
				this.Text = this._item.Name;
				CreateChildNodes();
				OnPropertyChanged("Item");			
			}
		}
		
		private void CreateChildNodes(){
			if(this.Item.LanguageTypes != null){
				LanguageTypeCollection languageTypes = this.Item.LanguageTypes;
				
				foreach(ILanguageType item in languageTypes){
					this.Nodes.Add(new LanguageTypeNode(item));
				}
			}
		}
		
		private void OnPropertyChanged(string propertyName){
			if(PropertyChanged != null){
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
