/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 21:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WorkspaceProviderModule.Explorer.Interfaces;
using WorkspaceProviderModule.Explorer.Models;
using WorkspaceProviderModule.Explorer.Views;

namespace WorkspaceProviderModule.Explorer.Nodes
{
	/// <summary>
	/// Description of ProjectNode.
	/// </summary>
	public class ProjectNode : TreeNode, INotifyPropertyChanged
	{
		private IProject _item;		
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		public ProjectNode()
		{
			this._item = new Project();
			this.Text = this.Item.Name = "Project#";
		}
		
		public ProjectNode(string projectName){
			this._item = new Project(projectName);
			this.Text = this.Item.Name;
		}
		
		public ProjectNode(string projectName, string icon){
			this._item = new Project(projectName, icon);
			this.Text = this.Item.Name;
		}
		
		public ProjectNode(IProject item){
			this._item = item;
			this.Text = this._item.Name;
			CreateChildNodes();
		}
		
		public string Icon{
			get { return this.Item.Icon; }
			set { this.Item.Icon = value; 
				OnPropertyChanged("Icon");
			}
		}
		
		public IProject Item{
			get { return this._item; }
			set {
				this._item = value;
				this.Text = this._item.Name;
				CreateChildNodes();
				OnPropertyChanged("Item");
			}
		}
		
		public bool IsUsedInWorkspaceBrowser{
			get { return this.Item.IsUsedInWorkspaceBrowser; }
			set { this.Item.IsUsedInWorkspaceBrowser = value; 
				OnPropertyChanged("IsUsedInWorkspaceBrowser"); 
			}
		}

		private void CreateChildNodes()
		{
			if(this.Item.Items != null && !IsUsedInWorkspaceBrowser){
				foreach(IProjectItem item in this.Item.Items){
					this.Nodes.Add(new ProjectItemNode(item));
				}
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if(this.PropertyChanged != null){
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
