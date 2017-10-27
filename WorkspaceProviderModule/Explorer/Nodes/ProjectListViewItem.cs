/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/15/2017
 * Time: 10:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using WorkspaceProviderModule.Explorer.Interfaces;

namespace WorkspaceProviderModule.Explorer.Nodes
{
	/// <summary>
	/// Description of ProjectListViewItem.
	/// </summary>
	public class ProjectListViewItem : ListViewItem, INotifyPropertyChanged
	{
		private IProject _item;

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion		
		 
		public ProjectListViewItem(IProject item)
		{
			_item = item;
			this.Text = _item.Name;
			this.ImageKey = _item.Icon;
			
		}
	}
}
