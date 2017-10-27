using System;
using System.Linq;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
    public interface IProjectItem : IModel
    {
        Guid Id { get; }
        String Name { get; set; }

        IProjectItem Parent { get; set; }
        ProjectItemCollection Items { get; set; }
        IProject Project { get; set; }
        IWorkspace Workspace { get; set; }

        bool IsRoot { get; set; }
        bool IsLeaf { get; set; }
        bool IsActive { get; set; }
        bool IsSelected { get; set; }
        bool IsInEditMode { get; set; }
        bool IsSaved { get; set; }
    }
}
