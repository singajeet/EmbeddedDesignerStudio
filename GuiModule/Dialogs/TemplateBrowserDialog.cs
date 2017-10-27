/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/6/2017
 * Time: 7:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Core.Interfaces.Views;
using Microsoft.Practices.Unity;
using WorkspaceProviderModule.Explorer.Views;

namespace GuiModule.Dialogs
{
	/// <summary>
	/// Description of TemplateBrowserDialog.
	/// </summary>
	public partial class TemplateBrowserDialog : Form, IFormDialog
	{
	
		[Dependency("TemplateExplorerViewControl")]
		public ICustomControl TemplateExplorerView{
			get { return this.templateExplorerView; }
			set { this.templateExplorerView = (TemplateExplorerView)value;
				SetupTemplateExplorerView();
			}
		}
		
		public TemplateBrowserDialog()
		{            
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
//			if(_templateExplorer != null){
//				this.Controls.Add(_templateExplorer);
//				_templateExplorer.Dock = DockStyle.Fill;
//			}
		}

		void SetupTemplateExplorerView()
		{
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			
			this.tableLayoutPanel1.Controls.Add(this.templateExplorerView, 0, 0);
			
			// 
			// templateExplorerView
			// 
			this.templateExplorerView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateExplorerView.Location = new System.Drawing.Point(3, 3);
			this.templateExplorerView.Name = "templateExplorerView";
			this.templateExplorerView.Size = new System.Drawing.Size(681, 246);
			this.templateExplorerView.TabIndex = 1;
			
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
	}
}
