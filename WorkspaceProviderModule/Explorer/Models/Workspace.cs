using System;
using System.Linq;
using System.Drawing;
using System.IO;
using BindingModule;
using WorkspaceProviderModule.Explorer.Interfaces;

namespace WorkspaceProviderModule.Explorer.Models
{
    public class Workspace : PropertyChangedNotifier, IWorkspace
    {
        #region variables
        private static Workspace _instance;
        private Guid _id = new Guid();
        private String _name;
        private WorkspaceType _type = WorkspaceType.Standard;
        private String _fileName;
        private String _directoryPath;
        private Icon _icon;
        private FileInfo _file;
        private DirectoryInfo _directory;
        private ProjectCollection _projects;
        private BuildCollection _builds;

        #endregion

        #region constructors
        private Workspace() {
            if (this._projects == null)
                this._projects = new ProjectCollection();

            if (this._builds == null)
                this._builds = new BuildCollection();
        }

        #endregion

        #region public properties       

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

        public WorkspaceType WorkspaceType {
            get { return this._type; }
            set { this._type = value; 
            	NotifyPropertyChanged(() => WorkspaceType);
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

        public Icon WorkspaceIcon {
            get { return this._icon; }
            set {
                if (value == null)
                    return;
                this._icon = value;
                NotifyPropertyChanged(() => WorkspaceIcon);
            }
        }

        public ProjectCollection Projects {
            get { return this._projects; }
        }

        public BuildCollection Builds {
            get { return this._builds; }
        }

        #endregion

        #region public members
        public static Workspace GetWorkspace()
        {
            if (_instance == null)
                _instance = new Workspace();
            
            return _instance;
        }

        public void Create(String name, WorkspaceType type) {
            this._name = name;
            this._type = type;            
        }

        public void Create(String name, WorkspaceType type, String fileName, String directoryPath)
        {
            this._name = name;
            this._type = type;
            this._fileName = fileName;
            this._directoryPath = directoryPath;

            this._file = new FileInfo(this._fileName);
            this._directory = new DirectoryInfo(this._directoryPath);            
        }

        public void Open() {
                      
        }

        public void Close() {
            
        }

        public void Remove() { }

        public void Build() { }
        public void ReBuild() { }
        public void Clean() { }
        public void Configure() { }

        public void AddProject(Project project) {
            if (this._projects != null)
                this._projects.Add(project);
        }

        public void RemoveProject(Project project) {
            if (this._projects != null) {
                int index = this._projects.IndexOf(project);
                this._projects.Remove(index);
            }
        }

        public void RemoveProject(int index) {
            if (this._projects != null) {
                this._projects.Remove(index);
            }
        }

        public void AddBuild(Build build) {
            if (this._builds != null)
            {
                this._builds.Add(build);
            }
            else {
                throw new Exception("Build collection is not initialized yet!");            
            }
        }

        public void RemoveBuild(Build build) {
            if (this._builds != null)
            {
                this._builds.Remove(build);
            }
            else {
                throw new Exception("Build collection is empty!");
            }
        }

        public void RemoveBuild(int index) {
            if (this._builds != null && index >= 0 && index < this._builds.Count)
            {
                this._builds.Remove(index);
            }
            else {
                throw new Exception("Build collection is empty!");
            }
        }

        public void SetProjectDependencies(Project mainProject, ProjectCollection projects) {             
            foreach(Project project in projects){
                mainProject.AddDependency(project);
            }
        }

        public void RemoveProjectDependencies(Project mainProject, ProjectCollection projects) {
            foreach (Project project in projects) {
                mainProject.RemoveDependency(project);
            }
        }

        public void SetProjectBuildOrder(Project project, int order) {
            project.BuildOrderIndex = order;
        }

        public void InitProjectBuildOrder() {
            int count = 1;
            foreach (Project project in Projects) {
                if (project.IsStartupProject)
                {
                    project.BuildOrderIndex = 0;
                }
                else {
                    project.BuildOrderIndex = count++;
                }
            }
        }

    }

        #endregion
}
