using System;
using System.Linq;
using BindingModule;
using TemplateProviderModule.Interfaces;
using System.Collections.ObjectModel;

namespace TemplateProviderModule.Models
{
    public class TypeModel : PropertyChangedNotifier, IType
    {
        #region variables
        private int _typeId;        
        private int _templateId;
        private string _typeName;
        private string _tag = "Type";        
        private TypeModelCollection _childs;
        private Type _interface;
        private string _displayName;
        private string _iconPath;
        #endregion

        #region public properties
        public int TypeId
        {
            get { return this._typeId; }
            set { this._typeId = value; 
            	NotifyPropertyChanged(() => TypeId);
            }
        }

        public int TemplateId {
            get { return this._templateId; }
            set { this._templateId = value; 
            	NotifyPropertyChanged(() => TemplateId);
            }
        }

        public string Tag {
            get { return this._tag; }
            set { this._tag = value; 
            	NotifyPropertyChanged(() => Tag);
            }
        }

        public string TypeName {
            get { return this._typeName; }
            set { this._typeName = value; 
            	NotifyPropertyChanged(() => TypeName);
            }
        }

        public TypeModelCollection Childs
        {
            get { return this._childs; }
            set { this._childs = value; 
            	NotifyPropertyChanged(() => Childs);
            }
        }

        public Type Interface {
            get { return this._interface; }
            set { this._interface = value; 
            	NotifyPropertyChanged(() => Interface);
            }
        }

        public string DisplayName {
            get { return this._displayName; }
            set { this._displayName = value; 
            	NotifyPropertyChanged(() => DisplayName);
            }
        }
        
        public string IconPath{
        	get { return this._iconPath; }
        	set { this._iconPath = value; 
        		NotifyPropertyChanged(() => IconPath);
        	}
        }
        #endregion

        #region public methods
        
        public TypeModel(){}

        public void AddChild(IType p_type)
        {
            Childs.Add(p_type);
        }

        public IType GetChild(int p_index)
        {
            return Childs[p_index];
        }

        public IType GetChild(string p_typeName)
        {
            foreach (IType v_child in Childs) {
                if (v_child.TypeName == p_typeName)
                    return v_child;
            }

            return null;
        }

        public void RemoveChild(IType p_type)
        {
            Childs.Remove(p_type);
        }

        public void RemoveChild(int p_index)
        {
            Childs.Remove(p_index);
        }
        #endregion
    }

    public class TypeModelCollection : ObservableCollection<IType> {
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

        public IType Item(int index)
        {
            return (IType)Items[index];
        }

        #endregion
    }
}
