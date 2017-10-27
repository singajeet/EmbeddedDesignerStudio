using System;
using System.Linq;

namespace TemplateProviderModule.Interfaces
{
    public interface IGeneric : IType
    {
        int GenericId { get; set; }
        IGeneric GenericParent { get; set; }
        IGeneric[] GenericChilds { get; set; }
    }
}
