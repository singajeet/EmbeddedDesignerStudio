using System;
using System.Linq;
using TemplateProviderModule.Models;

namespace TemplateProviderModule.Interfaces
{
    public interface IType
    {
        int TypeId { get; set; }        
        int TemplateId { get; set; }
        string Tag { get; set; }
        string TypeName { get; set; }        
        TypeModelCollection Childs { get; set; }
        Type Interface { get; set; }
        string DisplayName { get; set; }
        string IconPath { get; set; }
        void AddChild(IType type);
        IType GetChild(int index);
        IType GetChild(string typeName);
        void RemoveChild(IType type);
        void RemoveChild(int index);
    }
}
