using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Core.Interfaces.Services;
using GuiModule.Interfaces;
using log4net;
using Core;
using EmbeddedDesignerStudio.Interfaces;
using Microsoft.Practices.Unity;

namespace EmbeddedDesignerStudio
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IApp
    {
        //IServiceLocator _serviceLocator;

        public App()
        {
            
        }
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //_serviceLocator = Core.Services.ServiceLocator.Start();
            //this.MainWindow = (MainWindow)_serviceLocator.Resolve<IMainWindow>();
            //log4net.Config.XmlConfigurator.Configure();

            //Logger = LogManager.GetLogger(typeof(App));
            //Logger.Info("Starting Embedded Designer Studio, Ver. 1, Copyright 2017...");
            //Logger.Info(DesignerEnvironment.GetAllDetailsAsPrintableString());         
        }        
    }
}
