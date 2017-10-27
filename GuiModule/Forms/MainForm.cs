/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 2:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Core.Interfaces.Views;
using GuiModule.Dialogs;
using Microsoft.Practices.Unity;

namespace GuiModule.Forms
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form, IForm
	{	
		private IFormDialog _templateBrowserDialog;
		
		[Dependency("TemplateBrowserDialogWindow")]
		public IFormDialog TemplateBrowserDialogWindow{
			get { return this._templateBrowserDialog; }
			set { this._templateBrowserDialog = value; }
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainForm_Load(object sender, EventArgs e)
		{
			this.dockPanel.BringToFront();
		}
		void solutionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//TemplateBrowserDialog _templateBrowserDialog = new TemplateBrowserDialog();
			((Form)_templateBrowserDialog).ShowDialog();
		}
	}
}
