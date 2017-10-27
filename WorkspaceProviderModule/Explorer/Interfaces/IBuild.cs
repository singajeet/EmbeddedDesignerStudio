using System;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
    public interface IBuild : IModel
    {   
        Guid Id { get; }
        string Name { get; set; }

        bool IsActive { get; set; }
        
        ProjectCollection Projects { get; }
        Platform BuildPlatform { get; set; }
        BuildType BuildType { get; set; }

        void Clean();
        void AddProject(Project project);
        void BuildWorkspace();
        void ReBuildWorkspace();
        void RemoveProject(int index);
        void RemoveProject(Project project);
    }
}
