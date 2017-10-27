using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using WpfUserControls.Templates.Explorer;
using MahApps.Metro.SimpleChildWindow;
using System.Threading.Tasks;
using EmbeddedDesignerStudio.Interfaces;
using WorkspaceProviderModule.Explorer.Interfaces;
using log4net;
using Microsoft.Practices.Unity;


namespace EmbeddedDesignerStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IMainWindow
    {
        private TemplateExplorer _explorer;
        private IWorkspaceBrowserViewModel _workspaceVM;
        private IProject _selectedProject;
        private ILog _logger;

        [Dependency]
        public ILog Logger {
            get { return this._logger; }
            set { this._logger = value; }
        }

        public MainWindow()
        {            
            InitializeComponent();
            if (Logger == null)
                Logger = LogManager.GetLogger(this.GetType().FullName);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _explorer = new TemplateExplorer();
            _explorer.ClosingFinished += new RoutedEventHandler(explorer_ClosingFinished);

            ChildWindowManager.ShowChildWindowAsync(this, _explorer);
        }

        void explorer_ClosingFinished(object sender, RoutedEventArgs e)
        {
            _workspaceVM = _explorer.BrowserViewModel;
            _selectedProject = _workspaceVM.SelectedProject;

            Logger.Debug("Selected Project Id => " + _selectedProject.Id);
            Logger.Debug("Selected Project Name => " + _selectedProject.Name);
            Logger.Debug("Project Name => " + _workspaceVM.ProjectName);
            Logger.Debug("Workspace Name => " + _workspaceVM.WorkspaceFileName);
            Logger.Debug("Workspace Path => " + _workspaceVM.WorkspaceFolderPath);
        }
                
        
    }
}
