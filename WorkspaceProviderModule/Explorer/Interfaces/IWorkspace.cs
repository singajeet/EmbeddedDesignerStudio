using System;
using WorkspaceProviderModule.Explorer.Models;
using System.IO;
namespace WorkspaceProviderModule.Explorer.Interfaces
{
    public interface IWorkspace : IModel
    {
        Guid Id { get; }
        string Name { get; set; }

        string FileName { get; set; }
        string FolderPath { get; set; }
                
        DirectoryInfo Directory { get; set; }
        FileInfo File { get; set; }

        BuildCollection Builds { get; }
        ProjectCollection Projects { get; }

        WorkspaceType WorkspaceType { get; set; }

        void AddBuild(Build build);
        void AddProject(Project project);

        void Build();
        
        void Clean();
        void Close();
        void Configure();
        void Create(string name, WorkspaceType type, string fileName, string directoryPath);
        void Create(string name, WorkspaceType type);

        void Open();

        void ReBuild();
        void Remove();
        void RemoveBuild(Build build);
        void RemoveBuild(int index);
        void RemoveProject(int index);
        void RemoveProject(Project project);
        void RemoveProjectDependencies(Project mainProject, ProjectCollection projects);        
        
        void InitProjectBuildOrder();
        
        void SetProjectBuildOrder(Project project, int order);
        void SetProjectDependencies(Project mainProject, ProjectCollection projects);
        
    }
}
