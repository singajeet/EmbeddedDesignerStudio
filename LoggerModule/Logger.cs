/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using Core;
using Core.Interfaces;
using Core.Interfaces.Modules;
using Core.Interfaces.Services;

namespace LoggerModule
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Logger : ILogger
	{
		log4net.ILog realLogger;
		protected string _name;
		protected string _description;

		public Logger()
		{	
			this._name = "LoggerService";
			this._description = "Service to log messages to configured logger";
			realLogger = CreateLogger();
			realLogger.Info("Logger instance created successfully!");
		}
		
		private log4net.ILog RealLogger{
			get {
				return realLogger ?? (realLogger = CreateLogger());
			}
		}

		private log4net.ILog CreateLogger()
		{
			var frame = new StackFrame(3, false);
			return log4net.LogManager.GetLogger(frame.GetMethod().DeclaringType.FullName);
		}
		
		#region ILogger implementation
		public void Debug(string message, params object[] param)
		{
			RealLogger.Debug(string.Format(message, param));
		}
		public void Debug(string message, Exception ex, params object[] param)
		{
			RealLogger.Debug(string.Format(message, param), ex);
		}
		public void Info(string message, params object[] param)
		{
			RealLogger.Info(string.Format(message, param));
		}
		public void Warn(string message, params object[] param)
		{
			RealLogger.Warn(string.Format(message, param));
		}
		public void Warn(string message, Exception ex, params object[] param)
		{
			RealLogger.Warn(string.Format(message, param), ex);
		}
		public void Error(string message, params object[] param)
		{
			RealLogger.Error(string.Format(message, param));
		}
		public void Error(string message, Exception ex, params object[] param)
		{
			RealLogger.Error(string.Format(message, param), ex);
		}
	#endregion
		
		public void Dispose()
		{
			
		}
		public string Name {
			get {
				return this._name;
			}
		}
		public string Description {
			get {
				return this._description;
			}
		}
	}
}