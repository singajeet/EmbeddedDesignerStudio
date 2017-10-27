/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 3:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Core.Interfaces.Modules
{
	/// <summary>
	/// Description of ILogger.
	/// </summary>
	public interface ILogger
	{
		void Debug(string message, params object[] param);
		void Debug(string message, Exception ex, params object[] param);
		void Info(string message, params object[] param);
		void Warn(string message, params object[] param);
		void Warn(string message, Exception ex, params object[] param);
		void Error(string message, params object[] param);
		void Error(string message, Exception ex, params object[] param);
	}
}
