/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/5/2017
 * Time: 2:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Core;
using Core.Interfaces.Modules;
using Core.Interfaces.Services;
using Core.Interfaces.Views;
using GuiModule.Interfaces;
using Microsoft.Practices.Unity;
using log4net;

namespace GuiModule
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program : IMainProgram
	{
		private ILog _logger;
		
		[Dependency]
		public ILog Logger{
			get { return _logger; }
			set { _logger = value; 
			}
		}
		
		private static IMainProgram _p;
				
		public static IMainProgram P{
			get { return _p; }
			set { _p = value; }
		}
		
		private static IForm _mainForm;
		
		[Dependency("MainWindow")]
		public IForm MainForm{
			get { return _mainForm; }
			set { _mainForm = value; }
		}
		
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			IServiceLocator serviceLocator = Core.Services.ServiceLocator.Start();			
			P = serviceLocator.Resolve<IMainProgram>();

			P.Logger.Info("Starting Embedded Designer Studio, Ver. 1, Copyright 2017...");
			P.Logger.Info(DesignerEnvironment.GetAllDetailsAsPrintableString());
						
			P.run();
			
		}
		
		public void run(){ 			
			Application.Run((Form)MainForm);			
		}
		
	}
}
