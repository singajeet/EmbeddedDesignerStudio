using System;
using System.Drawing;
using WorkspaceProviderModule.Explorer.Models;
using System.Windows.Input;
using System.IO;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
    public interface IProject : IModel
    {
        Guid Id { get; }
        string Name { get; set; }      

        string FileName { get; set; }
        string FileExtension { get; set; }
        string FolderPath { get; set; }

        DirectoryInfo Directory { get; set; }
        FileInfo File { get; set; }

        int BuildOrderIndex { get; set; }
        bool IsStartupProject { get; set; }       
        bool IsUsedInWorkspaceBrowser { get; set; }        
        bool IsRoot { get; set; }
		bool IsLeaf { get; set; }
		bool IsActive { get; set; }
		bool IsSelected { get; set; }
		bool IsInEditMode { get; set; }
		bool IsSaved { get; set; }
		string Icon { get; set; }

        ProjectCollection ProjectDependencies { get; set; }
        ProjectType ProjectType { get; set; }
        ProjectItemCollection Items { get; set; }
        IWorkspace Workspace { get; set; }        

        void AddBuildTypes();
        void AddDependency(Project project);
        void AddObject();

        void Build();

        void Create();
        void Clean();
        void Close();
        void Configure();       

        void Open();       
        
        void ReBuild();
        void Remove();
        void RemoveBuildTypes();
        void RemoveDependency(Project project);
        void RemoveDependency(int index);
        void RemoveObject();
    }
}
