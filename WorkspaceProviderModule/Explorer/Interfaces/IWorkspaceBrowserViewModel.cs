/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 6:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
	/// <summary>
	/// Description of IWorkspaceBrowserViewModel.
	/// </summary>
	public interface IWorkspaceBrowserViewModel
	{
		string Name { get; }

        ICommand BrowseFolderCommand { get; }

        ObservableCollection<ICategory> Categories { get; set; }
        ICommand CreateWorkspaceAndProjectCommand { get; }
        ICommand CancelAndCloseDialogCommand { get; }
        bool CanCreateWorkspaceAndProject(object project);
        void CreateWorkspaceAndProject(object project);

        ICategory DefaultCategory { get; }        
        ILanguageType DefaultLanguageType { get; }
        IProject DefaultProject { get; }

        string ProjectName { get; set; }

        ICategory SelectedCategory { get; set; }
        IProject SelectedProject { get; set; }
        ILanguageType SelectedLanguageType { get; set; }
        ICommand SaveAndCloseDialogCommand { get; }
        void SaveProject(object project);

        IWorkspace WorkspaceInstance { get; set; }
        string WorkspaceFolderPath { get; set; }
        string WorkspaceFileName { get; set; }

        void SetWorkspaceFolderPath(object obj);
        void SetWorkspaceFolderPath(string folderPath);        
	}
}
