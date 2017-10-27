using System;
using System.Linq;
using BindingModule;
using WorkspaceProviderModule.Explorer.Interfaces;
using System.Collections.ObjectModel;

namespace WorkspaceProviderModule.Explorer.Models
{
    public class Build : PropertyChangedNotifier, IBuild
    {
        #region variables
        private Guid _id = new Guid();
        private String _name;
        private BuildType _type;
        private Platform _platform;
        private ProjectCollection _projectCollection;
        private const String UNKNOWN_BUILD = "Unknown";
        private bool _isActive = false;
        #endregion

        #region constructors
        public Build() {
            this._name = UNKNOWN_BUILD;
            this._projectCollection = new ProjectCollection();
            this._type = BuildType.Debug;
            this._platform = Platform.AnyCPU;
        }

        public Build(String p_name) {
            this._name = p_name;
            this._projectCollection = new ProjectCollection();
            this._type = BuildType.Debug;
            this._platform = Platform.AnyCPU;
        }

        public Build(String p_name, BuildType p_type, Platform p_platform)
        {
            this._name = p_name;
            this._projectCollection = new ProjectCollection();
            this._type = p_type;
            this._platform = p_platform;
        }
        #endregion

        #region public properties
        public new Guid Id {
            get { return this._id; }
        }

        public String Name {
            get { return this._name; }
            set { this._name = value; 
            	NotifyPropertyChanged(() => Name);
            }
        }

        public BuildType BuildType {
            get { return this._type; }
            set { this._type = value; 
            	NotifyPropertyChanged(() => BuildType);
            }
        }

        public Platform BuildPlatform {
            get { return this._platform; }
            set { this._platform = value; 
            	NotifyPropertyChanged(() => BuildPlatform);
            }
        }

        public ProjectCollection Projects {
            get { return this._projectCollection; }
        }

        public bool IsActive {
            get { return this._isActive; }
            set { this._isActive = value; 
            	NotifyPropertyChanged(() => IsActive);
            }
        }
        #endregion

        #region public members

        public void BuildWorkspace() { }
        public void Clean() { }
        public void ReBuildWorkspace() { }

        public void AddProject(Project p_project) {
            if (this._projectCollection != null)
            {
                if (!this._projectCollection.Contains(p_project))
                {
                    this._projectCollection.Add(p_project);
                }
            }
            else {
                throw new Exception("Project collection is not initialized yet!");
            }
        }

        public void RemoveProject(Project p_project) {
            if (this._projectCollection != null) {
                this._projectCollection.Remove(p_project);
            }
            else
            {
                throw new Exception("Project collection is not initialized yet!");
            }
        }

        public void RemoveProject(int index) {
            if (this._projectCollection != null && index < this._projectCollection.Count && index >=0) {
                this._projectCollection.Remove(index);
            }
            else
            {
                throw new Exception("Project collection is not initialized yet!");
            }
        }
        #endregion
    }

    public class BuildCollection : ObservableCollection<Build>
    {

        #region public members

        public void Remove(int index) {
            if (index >= 0 && index < Count)
            {
                Items.RemoveAt(index);
            }
            else {
                throw new Exception(String.Format("Specified index {0} is not valid for this collection!", index));
            }
        }

        public Build Item(int index) {
            return (Build)Items[index];
        }

        #endregion
    }
}
