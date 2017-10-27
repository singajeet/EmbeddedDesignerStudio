using System;
using System.Linq;
using TemplateProviderModule.Models;

namespace TemplateProviderModule.Interfaces
{
    public interface ITemplate
    {
        int TemplateId { get; set; }
        string Tag { get; }
        string Name { get; set; } 
        string LanguageType { get; set; }
        string Author { get; set; }
        string Category { get; set; }
        string Description { get; set; }
        string Revision { get; set; }
        string WorkspaceAssembly { get; set; }
        string WorkspaceAssemblyPath { get; set; }
        string WorkspaceRootNamespace { get; set; }
        string TypeObjectsAssembly { get; set; }
        string TypeObjectsAssemblyPath { get; set; }
        string TypeObjectsRootNamespace { get; set; }
        DateTime ReleaseDate { get; set; }
        TypeModelCollection Projects { get; set; }
    }
}
