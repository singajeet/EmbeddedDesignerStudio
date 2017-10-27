/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WorkspaceProviderModule.Explorer.Views
{
	partial class TemplateExplorerView
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton smallIconRadioButton;
		private System.Windows.Forms.RadioButton largeIconRadioButton;
		private System.Windows.Forms.TreeView templateExplorerTreeView;
		private System.Windows.Forms.ListView projectsListView;
		private System.Windows.Forms.ImageList largeImageList;
		private System.Windows.Forms.ImageList smallImageList;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateExplorerView));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.templateExplorerTreeView = new System.Windows.Forms.TreeView();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.smallIconRadioButton = new System.Windows.Forms.RadioButton();
			this.largeIconRadioButton = new System.Windows.Forms.RadioButton();
			this.projectsListView = new System.Windows.Forms.ListView();
			this.largeImageList = new System.Windows.Forms.ImageList(this.components);
			this.smallImageList = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer1.Size = new System.Drawing.Size(657, 300);
			this.splitContainer1.SplitterDistance = 219;
			this.splitContainer1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.templateExplorerTreeView, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 296);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(203, 33);
			this.label1.TabIndex = 1;
			this.label1.Text = "Categories:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// templateExplorerTreeView
			// 
			this.templateExplorerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateExplorerTreeView.Location = new System.Drawing.Point(4, 48);
			this.templateExplorerTreeView.Name = "templateExplorerTreeView";
			this.templateExplorerTreeView.Size = new System.Drawing.Size(207, 244);
			this.templateExplorerTreeView.TabIndex = 2;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.projectsListView, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(430, 296);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.smallIconRadioButton, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.largeIconRadioButton, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(422, 37);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 4);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(331, 31);
			this.label2.TabIndex = 0;
			this.label2.Text = "Templates:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// smallIconRadioButton
			// 
			this.smallIconRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.smallIconRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smallIconRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("smallIconRadioButton.Image")));
			this.smallIconRadioButton.Location = new System.Drawing.Point(342, 3);
			this.smallIconRadioButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.smallIconRadioButton.Name = "smallIconRadioButton";
			this.smallIconRadioButton.Size = new System.Drawing.Size(32, 31);
			this.smallIconRadioButton.TabIndex = 1;
			this.smallIconRadioButton.UseVisualStyleBackColor = true;
			this.smallIconRadioButton.CheckedChanged += new System.EventHandler(this.smallIconRadioButton_CheckedChanged);
			// 
			// largeIconRadioButton
			// 
			this.largeIconRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.largeIconRadioButton.Checked = true;
			this.largeIconRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.largeIconRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("largeIconRadioButton.Image")));
			this.largeIconRadioButton.Location = new System.Drawing.Point(384, 3);
			this.largeIconRadioButton.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.largeIconRadioButton.Name = "largeIconRadioButton";
			this.largeIconRadioButton.Size = new System.Drawing.Size(33, 31);
			this.largeIconRadioButton.TabIndex = 2;
			this.largeIconRadioButton.TabStop = true;
			this.largeIconRadioButton.UseVisualStyleBackColor = true;
			this.largeIconRadioButton.CheckedChanged += new System.EventHandler(this.largeIconRadioButton_CheckedChanged);
			// 
			// projectsListView
			// 
			this.projectsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.projectsListView.LargeImageList = this.largeImageList;
			this.projectsListView.Location = new System.Drawing.Point(4, 48);
			this.projectsListView.MultiSelect = false;
			this.projectsListView.Name = "projectsListView";
			this.projectsListView.ShowItemToolTips = true;
			this.projectsListView.Size = new System.Drawing.Size(422, 244);
			this.projectsListView.SmallImageList = this.smallImageList;
			this.projectsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.projectsListView.TabIndex = 2;
			this.projectsListView.TileSize = new System.Drawing.Size(30, 30);
			this.projectsListView.UseCompatibleStateImageBehavior = false;
			// 
			// largeImageList
			// 
			this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
			this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.largeImageList.Images.SetKeyName(0, "Console-Project-Icon");
			this.largeImageList.Images.SetKeyName(1, "Window-Project-Icon");
			// 
			// smallImageList
			// 
			this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
			this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.smallImageList.Images.SetKeyName(0, "Console-Project-Icon");
			this.smallImageList.Images.SetKeyName(1, "Window-Project-Icon");
			// 
			// TemplateExplorerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "TemplateExplorerView";
			this.Size = new System.Drawing.Size(657, 300);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
