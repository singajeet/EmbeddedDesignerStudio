using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core.Interfaces.Services;
using WorkspaceProviderModule.Explorer.Interfaces;
using WorkspaceProviderModule.Explorer.Models;
using Core.Interfaces.Modules;

namespace WorkspaceProviderModule.Explorer.Views
{
    public class WorkspaceNode : TreeNode, INotifyPropertyChanged
    {
        private IWorkspace _workspace;
                
        INameProvider _namingService;
        
        private INameProvider NamingService{
        	get { return this._namingService; }
        }

        public IWorkspace WorkspaceInstance {
            get { return this._workspace; }
            set { this._workspace = value; 
            	if(PropertyChanged != null)
            		PropertyChanged(this, new PropertyChangedEventArgs("Workspace"));
            }
        }

        public WorkspaceNode() : base() {
            this._workspace = Workspace.GetWorkspace();
            this.Name = NamingService.GetUniqueIdForName("Workspace");
        }

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
    }
}
