/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 14:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using BindingModule;
using Core.Interfaces.Modules;
using Core.Interfaces.Services;
using WorkspaceProviderModule.Explorer.Interfaces;
using log4net;
using System.Windows.Input;
using WorkspaceProviderModule.Explorer.Commands;
using System.Windows;
using WorkspaceProviderModule.Explorer.Models;
using Metro.Dialogs;

namespace WorkspaceProviderModule.Explorer.ViewModels
{
	/// <summary>
	/// Description of WorkspaceBrowserViewModel.
	/// </summary>
	
	
	public class WorkspaceBrowserViewModel : PropertyChangedNotifier, IWorkspaceBrowserViewModel
	{
		private IWorkspaceProvider _workspaceProvider;
		private ObservableCollection<ICategory> _categories;
		private ICommand _browseFolderCommand;
        private IWorkspace _workspace;
        private ILanguageType _selectedLanguageType;
        private IProject _selectedProject;
        private ICategory _selectedCategory;
        private ICommand _createWorkspaceAndProjectCommand;
        private ICommand _saveAndCloseDialogCommand;
        private ICommand _cancelAndCloseDialogCommand;
        private bool _closeTrigger;
        private string _projectName;
		
		public WorkspaceBrowserViewModel(IWorkspaceProvider workspaceProvider, ILog logger)
		{
			try{
			_workspaceProvider = workspaceProvider;
			Logger = logger;
			
			Logger.Debug("Calling WorkspaceService to get all template Categories");
			
			_categories = _workspaceProvider.GetCategories();
			
			Logger.Debug(String.Format("Got {0} Categories from WorkspaceService", _categories.Count));			
			
			}catch(Exception ex){
				Logger.Error("Call to WorkspaceService failed while fetching Categories due to following exception =>", ex);
				throw ex;
			}
			
		}

        public bool CloseTrigger {
            get { return this._closeTrigger; }
            set { _closeTrigger = value;
            NotifyPropertyChanged(() => CloseTrigger);
            }
        }

        public ICategory DefaultCategory {
            get { return Categories[0]; }
        }

        public ILanguageType DefaultLanguageType {
            get { return DefaultCategory.LanguageTypes[0]; }
        }

        public IProject DefaultProject {
            get { return DefaultLanguageType.Projects[0]; }
        }      

        public ICategory SelectedCategory {
            get { return this._selectedCategory; }
            set { this._selectedCategory = value;
            NotifyPropertyChanged(() => SelectedCategory);
            }
        }
        
        public ILanguageType SelectedLanguageType
        {
            get { return this._selectedLanguageType; }
            set
            {
                this._selectedLanguageType = value;
                NotifyPropertyChanged(() => SelectedLanguageType);
            }
        }

        public IWorkspace WorkspaceInstance {
            get
            {
                if (this._workspace == null)
                    this._workspace = Workspace.GetWorkspace();
                return this._workspace; 
            }
            set { this._workspace = value;
            NotifyPropertyChanged(() => WorkspaceInstance);
            }
        }

        public ObservableCollection<ICategory> Categories
        {
            get { return this._categories; }
            set
            {
                this._categories = value;
                NotifyPropertyChanged(() => Categories);
            }
        }

        public string Name
        {
            get { return "All Categories"; }
        }

        public string WorkspaceFolderPath {
            get { return WorkspaceInstance.FolderPath; }
            set { WorkspaceInstance.FolderPath = value;
            NotifyPropertyChanged(() => WorkspaceFolderPath);
            }
        }

        public string WorkspaceFileName {
            get { return WorkspaceInstance.FileName; }
            set { WorkspaceInstance.FileName = value;
            NotifyPropertyChanged(() => WorkspaceFileName);
            }
        }

        public string ProjectName {
            get { return _projectName; }
            set { _projectName = value;
            NotifyPropertyChanged(() => ProjectName);
            }
        }

        public ICommand BrowseFolderCommand {
            get {
                if (_browseFolderCommand == null) {
                    _browseFolderCommand = new RelayCommand(new Action<object>(SetWorkspaceFolderPath));                   
                }
                return _browseFolderCommand;
            }
        }

        public ICommand CreateWorkspaceAndProjectCommand
        {
            get
            {
                if (_createWorkspaceAndProjectCommand == null)
                    _createWorkspaceAndProjectCommand = new RelayCommand(new Action<object>(CreateWorkspaceAndProject), new Predicate<object>(CanCreateWorkspaceAndProject));

                return _createWorkspaceAndProjectCommand;
            }
        }

        public ICommand SaveAndCloseDialogCommand { 
            get {
                if (_saveAndCloseDialogCommand == null)
                    _saveAndCloseDialogCommand = new RelayCommand(new Action<object>(SaveAndCloseDialog), new Predicate<object>(CanSaveAndCloseDialog));

                return _saveAndCloseDialogCommand;
            } 
        }

        public ICommand CancelAndCloseDialogCommand {
            get
            {
                if (_cancelAndCloseDialogCommand == null)
                    _cancelAndCloseDialogCommand = new RelayCommand(new Action<object>(CancelAndCloseDialog), new Predicate<object>(CanCancelAndCloseDialog));

                return _cancelAndCloseDialogCommand;
            }
        }

        public IProject SelectedProject {
            get { return this._selectedProject; }
            set { this._selectedProject = value;
            NotifyPropertyChanged(() => SelectedProject);
            }
        }

        private bool CanSaveAndCloseDialog(object project)
        {
            return true;
        }

        private void SaveAndCloseDialog(object project) {
            SelectedProject = (IProject)project;
            Logger.Debug(String.Format("User selected the following template for project creation => [{0}]", SelectedProject.Name));

            CloseTrigger = true;
            Logger.Debug("Workspace Explorer Dialog Window has been closed successfully");
        }

        private bool CanCancelAndCloseDialog(object obj)
        {
            return true;
        }

        private void CancelAndCloseDialog(object obj) {
            CloseTrigger = true;
        }

        public bool CanCreateWorkspaceAndProject(object project)
        {
            return true;
        }

        public void CreateWorkspaceAndProject(object project)
        {
            


            
            

            Logger.Debug(String.Format("Saving Workspace [{0}] with the following project template => [{1}]", "", project.ToString()));

        }

        public void SaveProject(object project)
        {
            Logger.Debug(String.Format("Saving project [{0}] with the following project template => [{1}]", this.SelectedProject.FileName, project.ToString()));
        }


        public void SetWorkspaceFolderPath(object obj)
        {            
            WorkspaceFolderPath = obj.ToString();
            Logger.Debug(String.Format("Workspace folder path has been set to [{0}]", WorkspaceFolderPath));
        }

        public void SetWorkspaceFolderPath(string folderPath)
        {
            WorkspaceFolderPath = folderPath;
            Logger.Debug(String.Format("Workspace folder path has been set to [{0}]", WorkspaceFolderPath));
        }       
    }
}
