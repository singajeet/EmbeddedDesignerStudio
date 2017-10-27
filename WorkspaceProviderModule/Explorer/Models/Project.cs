using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Collections.ObjectModel;
using BindingModule;
using WorkspaceProviderModule.Explorer.Interfaces;
using System.Windows.Input;
using WorkspaceProviderModule.Explorer.Commands;
using log4net;
using Microsoft.Practices.Unity;

namespace WorkspaceProviderModule.Explorer.Models
{
    public class Project : PropertyChangedNotifier, IProject
    {
        #region variables
        private Guid _id = Guid.NewGuid();
        private String _name;
        private ProjectType _type = ProjectType.Custom;
        private String _fileName;
        private String _fileExtension;
        private String _directoryPath;
        private String _icon;
        private FileInfo _file;
        private DirectoryInfo _directory;
        private int _buildOrderIndex;
        private ProjectCollection _projectDependencies;
        private bool _isStartupProject;
        private IWorkspace _workspace;
        private static int _nextBuildOrderIndex = 0;        
        private ProjectItemCollection _items;
        private bool _isRoot;
        private bool _isLeaf;
        private bool _isActive;
        private bool _isSelected;
        private bool _isInEditMode;
        private bool _isSaved;
        private bool _isUsedInWorkspaceBrowser;

        #endregion

        #region !!!!!!!!!!!!!!!!!!!!constructors FOR WorkSpaceBrowserView ONLY !!!!!!!!!!!!!!!!!!!!!
        public Project(){
        	_isUsedInWorkspaceBrowser = true;
        }
        
        public Project(string name){
        	this._name = name;
        	_isUsedInWorkspaceBrowser = true;
        }
        
        public Project(string name, string icon){
        	this._name = name;
        	this._icon = icon;
        	_isUsedInWorkspaceBrowser = true;
        }
        #endregion
        
        #region constructors
        public Project(String name, String fileName, String directoryPath, Workspace workspace) {
            this._name = name;
            this._fileName = fileName;
            this._directoryPath = directoryPath;
            this._projectDependencies = new ProjectCollection();
            this._buildOrderIndex = Project.NextBuildOrderIndex();
            this.IsStartupProject = false;
            this._workspace = workspace;
            _isUsedInWorkspaceBrowser = false;
        }

        public Project(String name, String fileName, String directoryPath, Workspace workspace, bool isStartProject)
        {
            this._name = name;
            this._fileName = fileName;
            this._directoryPath = directoryPath;
            this._projectDependencies = new ProjectCollection();
            this._buildOrderIndex = Project.NextBuildOrderIndex();
            this.IsStartupProject = false;
            this._workspace = workspace;
            this._isStartupProject = isStartProject;
            _isUsedInWorkspaceBrowser = false;
        }

        public Project(String name, String fileName, String directoryPath, Workspace workspace, ProjectType type) {
            this._name = name;
            this._fileName = fileName;
            this._directoryPath = directoryPath;
            this._projectDependencies = new ProjectCollection();
            this._buildOrderIndex = Project.NextBuildOrderIndex();
            this.IsStartupProject = false;
            this._workspace = workspace;
            this._type = type;
            _isUsedInWorkspaceBrowser = false;
        }

        public Project(String name, String fileName, String directoryPath, Workspace workspace, ProjectType type, bool isStartupProject)
        {
            this._name = name;
            this._fileName = fileName;
            this._directoryPath = directoryPath;
            this._projectDependencies = new ProjectCollection();
            this._buildOrderIndex = Project.NextBuildOrderIndex();
            this.IsStartupProject = false;
            this._workspace = workspace;
            this._type = type;
            this._isStartupProject = isStartupProject;
            _isUsedInWorkspaceBrowser = false;
        }
        #endregion

        #region public properties   

        public ILog Logger {
            get
            {
                if (base.Logger == null)
                    base.Logger = LogManager.GetLogger(this.GetType().FullName);

                return base.Logger;
            }

            set { base.Logger = value; }
        }

        public new Guid Id {
            get { return this._id; }            
        }

        public String Name {
            get { return this._name; }
            set {
                if (value == null)
                    return;
                this._name = value;
                NotifyPropertyChanged(() => Name);
            }
        }

        public ProjectType ProjectType {
            get { return this._type; }
            set { this._type = value; 
            	NotifyPropertyChanged(() => ProjectType);
            }
        }

        public String FileName {
            get { return this._fileName; }
            set {
                if (value == null)
                    return;
                this._fileName = value;
                NotifyPropertyChanged(() => FileName);
            }
        }

        public String FileExtension {
            get { return this._fileExtension; }
            set
            {
                if (value == null)
                    return;
                this._fileExtension = value;
                NotifyPropertyChanged(() => FileExtension);
            }
        }

        public String FolderPath {
            get { return this._directoryPath; }
            set {
                if (value == null)
                    return;
                this._directoryPath = value;
                NotifyPropertyChanged(() => FolderPath);
            }
        }

        public FileInfo File {
            get {
                if (this._file == null && this._fileName != null)
                    this._file = new FileInfo(this._fileName);
                return this._file;
            }
            set {
                if (value == null)
                    return;
                this._file = value;
                NotifyPropertyChanged(() => File);
            }
        }

        public DirectoryInfo Directory {
            get {
                if (this._directory == null && this._directoryPath != null)
                    this._directory = new DirectoryInfo(this._directoryPath);
                return this._directory;
            }
            set {
                if (value == null)
                    return;
                this._directory = value;
                NotifyPropertyChanged(() => Directory);
            }
        }

        public string Icon {
            get { return "pack://application:,,,/WpfUserControls;component/Images/Icons/" + this._icon + ".png"; }
            set {
                if (value == null)
                    return;
                this._icon = value;
                NotifyPropertyChanged(() => Icon);
            }
        }

        public int BuildOrderIndex {
            get { return this._buildOrderIndex; }
            set { this._buildOrderIndex = value; 
            	NotifyPropertyChanged(() => BuildOrderIndex);
            }
        }

        public IWorkspace Workspace {
            get { return this._workspace; }
            set { this._workspace = value; 
            	NotifyPropertyChanged(() => Workspace);
            }
        }

        public ProjectCollection ProjectDependencies {
            get { return this._projectDependencies; }
            set { this._projectDependencies = value; 
            	NotifyPropertyChanged(() => ProjectDependencies);
            }
        }

        public bool IsStartupProject {
            get { return this._isStartupProject; }
            set { this._isStartupProject = value; 
            	NotifyPropertyChanged(() => IsStartupProject);
            }
        }

        public ProjectItemCollection Items
        {
            get { return this._items; }
            set { this._items = value; 
            	NotifyPropertyChanged(() => Items);
            }
        }

        public bool IsRoot
        {
            get { return this._isRoot; }
            set { this._isRoot = value; 
            	NotifyPropertyChanged(() => IsRoot);
            }
        }

        public bool IsLeaf
        {
            get { return this._isLeaf; }
            set { this._isLeaf = value; 
            	NotifyPropertyChanged(() => IsLeaf);
            }
        }

        public bool IsActive
        {
            get { return this._isActive; }
            set { this._isActive = value; 
            	NotifyPropertyChanged(() => IsActive);
            }
        }

        public bool IsSelected
        {
            get { return this._isSelected; }
            set { this._isSelected = value; 
            	NotifyPropertyChanged(() => IsSelected);
            }
        }

        public bool IsInEditMode
        {
            get { return this._isInEditMode; }
            set { this._isInEditMode = value; 
            	NotifyPropertyChanged(() => IsInEditMode);
            }
        }

        public bool IsSaved
        {
            get { return this._isSaved; }
            set { this._isSaved = value; 
            	NotifyPropertyChanged(() => IsSaved);
            }
        }
        
        public bool IsUsedInWorkspaceBrowser{
        	get { return this._isUsedInWorkspaceBrowser; }
        	set { this._isUsedInWorkspaceBrowser = value; 
        		NotifyPropertyChanged(() => IsUsedInWorkspaceBrowser);
        	}
        }               

        #endregion

        #region public members
        public void Create() { }
        public void Open() { }
        public void Close() { }
        public void Remove() { }
        public void Build() { }
        public void ReBuild() { }
        public void Clean() { }
        public void Configure() { }

        public void AddObject() { }
        public void RemoveObject() { }
        public void AddBuildTypes() { }
        public void RemoveBuildTypes() { }
        public void AddDependency(Project project) {
            if (this._projectDependencies != null) {
                this._projectDependencies.Add(project);
            }
        }
        
        public void RemoveDependency(Project project) {
            if (this._projectDependencies != null) {
                int index = this._projectDependencies.IndexOf(project);
                this._projectDependencies.Remove(index);                
            }
        }

        public void RemoveDependency(int index) {
            if (this._projectDependencies != null) {
                this._projectDependencies.Remove(index);
            }
        }

        public static int NextBuildOrderIndex()
        {
            if (_nextBuildOrderIndex == 0)
            {
                _nextBuildOrderIndex = 2;
                return 1;
            }
            else
                return _nextBuildOrderIndex++;
        }

        public static int NextBuildOrderIndex(Project model)
        {
            if (model.IsStartupProject)
                return 0;
            else
                return _nextBuildOrderIndex++;
        }
        #endregion
    }

    public class ProjectCollection : ObservableCollection<IProject>
    {

        #region public members
        
        public void Remove(int index) {
            if (index > Count - 1 || index < 0)
            {
                throw new ProjectCollectionOutOfIndexException(String.Format("No project exist at index {0} in this collection", index));
            }
            else {
                Items.RemoveAt(index);
            }
        }

        public IProject Item(int index)
        {
            return (IProject)Items[index];
        }

        public IProject Item(string projectName){
        	foreach(IProject item in Items){
        		if(item.Name.Equals(projectName))
        			return item;
        	}
        	
        	return null;
        }
        
        public bool Contains(string projectName){
        	foreach(IProject item in Items){
        		if(item.Name.Equals(projectName))
        			return true;
        	}
        	
        	return false;
        }
        
        public void AddRange(ObservableCollection<IProject> objects){
        	foreach(IProject item in objects){
        		Items.Add(item);
        	}
        }
        #endregion
    }

    public class ProjectCollectionOutOfIndexException : Exception
    {

        #region constructors
        public ProjectCollectionOutOfIndexException() : base() {

        }

        public ProjectCollectionOutOfIndexException(String message) : base(message) { 
        
        }

        public ProjectCollectionOutOfIndexException(String message, Exception innerException) :
            base(message, innerException) {

            }
        #endregion
    }
}
