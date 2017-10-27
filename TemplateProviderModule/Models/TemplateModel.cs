using System;
using System.Collections;
using System.Linq;
using BindingModule;
using TemplateProviderModule.Interfaces;
using System.Collections.ObjectModel;

namespace TemplateProviderModule.Models
{
    public class TemplateModel : PropertyChangedNotifier, ITemplate
    {
        #region variables
        private int _templateId;
        private string _tag = "Template";
        private string _name;
        private string _languageType;
        private string _author;
        private string _category;
        private string _description;
        private string _revision;
        private string _workspaceAssembly;
        private string _workspaceAssemblyPath;
        private string _workspaceRootNamespace;
        private string _typeObjectsAssembly;
        private string _typeObjectsAssemblyPath;
        private string _typeObjectsRootNamespace;
        private DateTime _releaseDate;
        private TypeModelCollection _projects;
        #endregion

        #region public properties
        public int TemplateId
        {
            get { return this._templateId; }
            set { this._templateId = value;
            	NotifyPropertyChanged(() => TemplateId);
            }
        }

        public string Tag { 
            get { return this._tag; } 
        }

        public string Name {
            get { return this._name; }
            set { this._name = value; 
            	NotifyPropertyChanged(() => Name);
            }
        }
        
        public string LanguageType { 
        	get { return this._languageType; }
        	set { this._languageType = value; 
        		NotifyPropertyChanged(() => LanguageType);
        	}
        }
        
        public string Author { 
        	get { return this._author; }
        	set { this._author = value; 
        		NotifyPropertyChanged(() => Author);
        	}
        }
        
        public string Category { 
        	get { return this._category; }
        	set { this._category = value; 
        		NotifyPropertyChanged(() => Category);
        	}
        }
        
        public string Description { 
        	get { return this._description; }
        	set { this._description = value; 
        		NotifyPropertyChanged(() => Description);
        	}
        }
        
        public string Revision { 
        	get { return this._revision; }
        	set { this._revision = value; 
        		NotifyPropertyChanged(() => Revision);
        	}
        }
        
        public string WorkspaceAssembly { 
        	get { return this._workspaceAssembly; }
        	set { this._workspaceAssembly = value; 
        		NotifyPropertyChanged(() =>  WorkspaceAssembly);
        	}
        }       
		
        public string WorkspaceAssemblyPath {
			get {
				return this._workspaceAssemblyPath;
			}
			set {
        		this._workspaceAssemblyPath = value;
        		NotifyPropertyChanged(() => WorkspaceAssemblyPath);
			}
		}        
		
        public string WorkspaceRootNamespace {
			get {
				return this._workspaceRootNamespace;
			}
			set {
        		this._workspaceRootNamespace = value;
        		NotifyPropertyChanged(() => WorkspaceRootNamespace);
			}
		}
        
		
        public string TypeObjectsAssembly {
			get {
				return this._typeObjectsAssembly;
			}
			set {
        		this._typeObjectsAssembly = value;
        		NotifyPropertyChanged(() => TypeObjectsAssembly);
			}
		}        
		
        public string TypeObjectsAssemblyPath {
			get {
				return this._typeObjectsAssemblyPath;
			}
			set {
        		this._typeObjectsAssemblyPath = value;
        		NotifyPropertyChanged(() => TypeObjectsAssemblyPath);
			}
		}
        
		public string TypeObjectsRootNamespace {
			get {
				return this._typeObjectsRootNamespace;
			}
			set {
        		this._typeObjectsRootNamespace = value;
        		NotifyPropertyChanged(() => TypeObjectsRootNamespace);
			}
		}
        
		public DateTime ReleaseDate {
			get {
				return this._releaseDate;
			}
			set {
        		this._releaseDate = value;
        		NotifyPropertyChanged(() => ReleaseDate);
			}
		}

        public TypeModelCollection Projects{
        	get { return this._projects; }
        	set { this._projects = value; 
        		NotifyPropertyChanged(() => Projects);
        	}
        }
        #endregion
    }

    public class TemplateModelCollection : ObservableCollection<ITemplate>, IEnumerable {
        #region public members

        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new Exception(String.Format("No project exist at index {0} in this collection", index));
            }
            else
            {
                Items.RemoveAt(index);
            }
        }

        public ITemplate Item(int index)
        {
            return (ITemplate)Items[index];
        }

        #endregion
		
    }
}
