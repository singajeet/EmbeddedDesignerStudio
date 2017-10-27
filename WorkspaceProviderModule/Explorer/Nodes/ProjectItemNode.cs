using System;
using System.ComponentModel;
using System.Linq;
using WorkspaceProviderModule.Explorer.Interfaces;
using System.Windows.Forms;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Views
{
    public class ProjectItemNode : TreeNode, INotifyPropertyChanged
    {
    	private IProjectItem _item;

    	public event PropertyChangedEventHandler PropertyChanged;
        #region constructors
        
        public ProjectItemNode(){
        	this._item = new ProjectItem();
        	this.Text = this._item.Name = "ProjectItem#";
        }

        public ProjectItemNode(IProjectItem item)  {
        	this._item = item;
        	this.Text = this._item.Name;
        	CreateChildNodes();
        }

        private void SetIconAndMenu() {
            this.SelectedImageIndex = (int)IconsImageIndex.File;
            this.ContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip.Items.Add("Add Item...");
            this.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            this.ContextMenuStrip.Items.Add("Rename...");
            this.ContextMenuStrip.Items.Add("Delete");
            this.ContextMenuStrip.DropShadowEnabled = true;            
        }

        #endregion

        #region IProjectItemNode Members

        public IProjectItem Item {
        	get { return this._item; }
        	set { 
        		this._item = value;
        		this.Text = this._item.Name;
        		CreateChildNodes();
        		OnPropertyChanged("Item");
        	}
        }

        #endregion

		private void CreateChildNodes()
		{
			
		}

		void OnPropertyChanged(string propertyName)
		{
			if(this.PropertyChanged != null){
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
    }
        
}
