using System;
using System.Linq;
using BindingModule;
using WorkspaceProviderModule.Explorer.Interfaces;
using System.Collections.ObjectModel;
using System.IO;

namespace WorkspaceProviderModule.Explorer.Models
{
    public class ProjectItem : PropertyChangedNotifier, IProjectItem
    {
        #region variables    
        private Guid _id = new Guid();
        private String _name;
        private IProjectItem _parent;
        private ProjectItemCollection _items;
        private IProject _project;
        private IWorkspace _workspace;
        private bool _isRoot;
        private bool _isLeaf;
        private bool _isActive;
        private bool _isSelected;
        private bool _isInEditMode;
        private bool _isSaved;
        #endregion

        #region IProjectItem Members
        public new Guid Id {
            get { return this._id; }
        }

        public string Name {
            get { return this._name; }
            set { this._name = value; 
            	NotifyPropertyChanged(() => Name);
            }
        }

        public IProjectItem Parent {
            get { return this._parent; }
            set { this._parent = value; 
            	NotifyPropertyChanged(() => Parent);
            }
        }

        public ProjectItemCollection Items {
            get { return this._items; }
            set { this._items = value; 
            	NotifyPropertyChanged(() => Items);
            }
        }

        public IProject Project {
            get { return this._project; }
            set { this._project = value; 
            	NotifyPropertyChanged(() => Project);
            }
        }

        public IWorkspace Workspace {
            get { return this._workspace; }
            set { this._workspace = value; 
            	NotifyPropertyChanged(() => Workspace);
            }
        }

        public bool IsRoot {
            get { return this._isRoot; }
            set { this._isRoot = value; 
            	NotifyPropertyChanged(() => IsRoot);
            }
        }

        public bool IsLeaf {
            get { return this._isLeaf; }
            set { this._isLeaf = value; 
            	NotifyPropertyChanged(() => IsLeaf);
            }
        }

        public bool IsActive {
            get { return this._isActive; }
            set { this._isActive = value; 
            	NotifyPropertyChanged(() => IsActive);
            }
        }

        public bool IsSelected {
            get { return this._isSelected; }
            set { this._isSelected = value; 
            	NotifyPropertyChanged(() => IsSelected);
            }
        }

        public bool IsInEditMode {
            get { return this._isInEditMode; }
            set { this._isInEditMode = value; 
            	NotifyPropertyChanged(() => IsInEditMode);
            }
        }

        public bool IsSaved {
            get { return this._isSaved; }
            set { this._isSaved = value; 
            	NotifyPropertyChanged(() => IsSaved);
            }
        }
        #endregion

        #region public methods

        public void AddChildItem(IProjectItem item) {
            if (this._items == null)
                this._items = new ProjectItemCollection();

            this._items.Add(item);
        }

        public void RemoveChildItem(IProjectItem item) {
            if (this._items != null)
                this._items.Remove(item);
        }

        public void removeChildItem(int index) {
            if (this._items != null)
                this._items.Remove(index);
        }

        #endregion
    }

    public class ProjectItemCollection : ObservableCollection<IProjectItem>
    {

        #region public members
        
        public void Remove(int index) {
            if (index > Count - 1 || index < 0)
            {
                throw new ProjectCollectionOutOfIndexException(String.Format("No project exist at index {0} in this collection", index));
            }
            else
            {
                Items.RemoveAt(index);
            }
        }

        public IProjectItem Item(int index) {
            return Items[index];
        }

        #endregion

    }

    public class FileItem : ProjectItem
    {

        #region variables

        private String _filePath;
        private String _directoryPath;
        private FileInfo _file;
        private DirectoryInfo _directory;
        private byte[] _content;
        private Type _contentType = typeof(byte);
        #endregion

        #region public properties

        public String FilePath {
            get { return this._filePath; }            
        }

        public String DirectoryPath {
            get { return this._directoryPath; }            
        }

        public FileInfo File {
            get {
                if (this._file == null)
                {
                    this._file = new FileInfo(this._filePath);
                    this._directory = this._file.Directory;
                    this._directoryPath = this._file.DirectoryName;
                }
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
                return this._directory;
            }
        }

        public byte[] Content {
            get { return this._content; }
            set { 
                //this._content = value;
                this._content = new byte[value.Length];
                Array.Copy(value, this._content, value.Length);
                IsInEditMode = true;
                NotifyPropertyChanged(() => Content);
            }
        }

        #endregion

        #region public methods

        public bool CreateContent(string p_filePath, byte[] p_content) {
            this._filePath = p_filePath;

            if (!System.IO.File.Exists(this._filePath))
            {
                FileStream v_stream = this.File.Create();

                if (p_content != null)
                {
                    v_stream.Write(p_content, 0, p_content.Length);

                    this.Content = new byte[p_content.Length];
                    Array.Copy(p_content, this.Content, p_content.Length);
                }

                v_stream.Flush();
                v_stream.Close();

                return true;
            }

            return false;
        }

        public byte[] ReadContent() {
            if (this._file != null) {
                FileStream v_stream = this._file.OpenRead();
                v_stream.Read(this.Content, 0, this.Content.Length);
                v_stream.Close();

                return this.Content;
            }

            return null;
        }

        public bool WriteContent() {
            if (this.Content != null && this._file != null) {
                FileStream v_stream = this.File.OpenWrite();               
                v_stream.Write(this.Content, 0, this.Content.Length);
                v_stream.Close();

                return true;
            }

            return false;
        }

        public bool WriteContent(byte[] p_content)
        {
            if (this._file != null)
            {
                FileStream v_stream = this.File.OpenWrite();
                v_stream.Write(this.Content, 0, this.Content.Length);
                this.Content = new byte[p_content.Length];
                Array.Copy(p_content, this.Content, p_content.Length);
                v_stream.Close();

                return true;
            }

            return false;
        }

        public bool DeleteContent() {
            if (this.Content != null && this._file != null) {
                this._file.Delete();
                this.Content = null;
                return true;
            }

            return false;
        }
        
        #endregion
                
    }
}
