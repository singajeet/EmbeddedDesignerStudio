/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Core.Interfaces.Views;
using Microsoft.Practices.Unity;
using WorkspaceProviderModule.Explorer.Interfaces;
using WorkspaceProviderModule.Explorer.Nodes;

namespace WorkspaceProviderModule.Explorer.Views
{
	/// <summary>
	/// Description of TemplateExplorerView.
	/// </summary>
	
	public partial class TemplateExplorerView : UserControl, ICustomControl
	{
		
		IWorkspaceBrowserViewModel _model;
		
		[Dependency]
		public IWorkspaceBrowserViewModel ViewModel{
			get { return this._model; }
			set { this._model = value; 
				BindViewModel();
			}
		}
		
		
		
		public TemplateExplorerView()
		{
			InitializeComponent();
			templateExplorerTreeView.NodeMouseClick += templateExplorerTreeView_NodeMouseClick;
		}

		void BindViewModel()
		{
			foreach (ICategory category in _model.Categories) {
				templateExplorerTreeView.Nodes.Add(new CategoryNode(category));				
			}
		}

		void templateExplorerTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode selectedNode = templateExplorerTreeView.SelectedNode;
			if (selectedNode is LanguageTypeNode) {
				projectsListView.Items.Clear();
				
				foreach (IProject project in ((LanguageTypeNode)selectedNode).Item.Projects) {
					projectsListView.Items.Add(new ProjectListViewItem(project));
				}
			}
		}
		void largeIconRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (largeIconRadioButton.Checked)
				projectsListView.View = View.LargeIcon; 
		}
		void smallIconRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (smallIconRadioButton.Checked)
				projectsListView.View = View.SmallIcon;
		}
	}
}
