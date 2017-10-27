/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 21:21
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
	/// Description of LanguageTypeNode.
	/// </summary>
	public class LanguageTypeNode : TreeNode, INotifyPropertyChanged
	{
		private ILanguageType _item;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		public LanguageTypeNode()
		{
			this._item = new LanguageType();
			this.Text = this._item.Name = "LanguageType#";
		}
		
		public LanguageTypeNode(ILanguageType item){
			this._item = item;
			this.Text = item.Name;
			//CreateChildNodes();
		}
		
		public ILanguageType Item{
			get { return this._item; }
			set { 
				this._item = value;
				this.Text = this._item.Name;
				//CreateChildNodes();
				OnPropertyChanged("Item");
			}
		}
		
		private void CreateChildNodes(){
			if(this.Item.Projects != null){
				ProjectCollection projects = this._item.Projects;
				
				foreach(IProject project in projects){
					this.Nodes.Add(new ProjectNode(project));
				}
			}
		}
		
		private void OnPropertyChanged(string propertyName){
			if(this.PropertyChanged != null){
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
