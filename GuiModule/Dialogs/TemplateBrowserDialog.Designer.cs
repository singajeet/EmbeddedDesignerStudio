/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/6/2017
 * Time: 7:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using WorkspaceProviderModule.Explorer.Views;
namespace GuiModule.Dialogs
{
	partial class TemplateBrowserDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button templateExplorerViewOkButton;
		private System.Windows.Forms.Button templateExplorerViewCancelButton;
		private TemplateExplorerView templateExplorerView;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.templateExplorerViewOkButton = new System.Windows.Forms.Button();
			this.templateExplorerViewCancelButton = new System.Windows.Forms.Button();
			//this.templateExplorerView = new WorkspaceServices.Explorer.Views.TemplateExplorerView();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);			
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 297);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel2.Controls.Add(this.templateExplorerViewOkButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.templateExplorerViewCancelButton, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 255);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(681, 39);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// templateExplorerViewOkButton
			// 
			this.templateExplorerViewOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.templateExplorerViewOkButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateExplorerViewOkButton.Location = new System.Drawing.Point(483, 7);
			this.templateExplorerViewOkButton.Margin = new System.Windows.Forms.Padding(7);
			this.templateExplorerViewOkButton.Name = "templateExplorerViewOkButton";
			this.templateExplorerViewOkButton.Size = new System.Drawing.Size(71, 25);
			this.templateExplorerViewOkButton.TabIndex = 0;
			this.templateExplorerViewOkButton.Text = "&Ok";
			this.templateExplorerViewOkButton.UseVisualStyleBackColor = true;
			// 
			// templateExplorerViewCancelButton
			// 
			this.templateExplorerViewCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.templateExplorerViewCancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateExplorerViewCancelButton.Location = new System.Drawing.Point(568, 7);
			this.templateExplorerViewCancelButton.Margin = new System.Windows.Forms.Padding(7);
			this.templateExplorerViewCancelButton.Name = "templateExplorerViewCancelButton";
			this.templateExplorerViewCancelButton.Size = new System.Drawing.Size(71, 25);
			this.templateExplorerViewCancelButton.TabIndex = 1;
			this.templateExplorerViewCancelButton.Text = "&Cancel";
			this.templateExplorerViewCancelButton.UseVisualStyleBackColor = true;			
			// 
			// TemplateBrowserDialog
			// 
			this.AcceptButton = this.templateExplorerViewOkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.templateExplorerViewCancelButton;
			this.ClientSize = new System.Drawing.Size(687, 297);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TemplateBrowserDialog";
			this.Text = "Template Browser Dialog";
			this.TopMost = true;            
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
