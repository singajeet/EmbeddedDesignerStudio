/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/13/2017
 * Time: 6:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Interfaces;
using Core.Interfaces.Views;
using Core.Interfaces.Modules;
using log4net;

namespace GuiModule.Interfaces
{
	/// <summary>
	/// Description of IMainProgram.
	/// </summary>
	public interface IMainProgram
	{
		void run(); //IForm form);
		ILog Logger { get; set; }
		IForm MainForm { get; set; }
	}
}
