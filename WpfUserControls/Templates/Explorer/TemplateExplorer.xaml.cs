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
using WorkspaceProviderModule.Explorer.Interfaces;
using Microsoft.Practices.Unity;
using log4net;
using Core.Interfaces.Services;
using MahApps.Metro.SimpleChildWindow;
using Metro.Dialogs;
using Caliburn.Micro;

namespace WpfUserControls.Templates.Explorer
{
    /// <summary>
    /// Interaction logic for TemplateExplorer.xaml
    /// </summary>
    public partial class TemplateExplorer : ChildWindow
    {
        IWorkspaceBrowserViewModel _viewModel;

        [Dependency]
        public IWorkspaceBrowserViewModel BrowserViewModel {
            get { return this._viewModel; }
            set { this._viewModel = value;
            //CategoriesTabControl.ItemsSource = this._viewModel.Categories;
            }
        }

        log4net.ILog _logger;

        [Dependency]
        public log4net.ILog Logger {
            get { return this._logger; }
            set { this._logger = value; }
        }

        public TemplateExplorer()
        {
            if(Logger == null)
                Logger = log4net.LogManager.GetLogger(typeof(TemplateExplorer));

            Logger.Debug("Starting up the 'TemplateExplorer' view...");
            InitializeComponent();
            try
            {
                if (BrowserViewModel != null)
                {
                    Logger.Debug("BrowserViewModel is available through Unity, so applying same to 'DataContext'");

                    this.DataContext = BrowserViewModel;
                    CategoriesTabControl.ItemsSource = BrowserViewModel.Categories;

                    Logger.Debug("Tab control's item source is set to 'Categories' field available in ViewModel");
                }
                else
                {
                    Logger.Debug("Unity is unable to set the BrowserViewModel, so trying to use 'ServiceLocator' for this action");

                    IServiceLocator svc = Core.Services.ServiceLocator.Start();
                    if (svc != null)
                    {
                        Logger.Debug("'LocatorService' has been started successfully");

                        Logger.Debug("Trying to resolve 'BrowserViewModel' as service using Unity");
                        BrowserViewModel = svc.Resolve<IWorkspaceBrowserViewModel>();

                        if (BrowserViewModel != null)
                        {
                            Logger.Debug("Found 'BrowserViewModel' instance from Unity 'ServiceLocator' and applying same to 'DataContext'");

                            this.DataContext = BrowserViewModel;
                            CategoriesTabControl.ItemsSource = BrowserViewModel.Categories;

                            Logger.Debug("Tab control's item source is set to 'Categories' field available in ViewModel");
                        }
                    }
                }
            }
            catch (Exception ex) {
                Logger.Error("Error while initializing TemplateExplorer user control => ", ex);
            }
        }

        public IWorkspaceBrowserViewModel ViewModel {
            get { return (IWorkspaceBrowserViewModel)this.DataContext; }
        }

        private void BrowsePathButton_Click(object sender, RoutedEventArgs e)
        {           
            var dialogService = new WindowsDialogs(new WindowManager());
            BrowserViewModel.WorkspaceFolderPath = dialogService.ShowSelectFolderDialog("Select folder");  
          
            Logger.Debug(String.Format("Workspace folder path has been set to [{0}]", BrowserViewModel.WorkspaceFolderPath));
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Logger.Debug(String.Format("Closing the child window => [{0}]", this.Title));
            this.Close();
        }
    }    

    public class TextValidator : ValidationRule {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Value can't be empty!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
