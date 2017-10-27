/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/13/2017
 * Time: 9:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Reflection;
using Core.Interfaces;
using Core.Interfaces.Aspects;
using Core.Interfaces.Modules;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Core.Interfaces.Services;
using log4net;

namespace AspectModule.Aspects
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class LoggingCallHandler : ICallHandler, IAspect
	{
		
		ILog _logger;
		
		[Dependency]
		public ILog Logger{
			get { return this._logger; }
			set { this._logger = value; 				
			}
		}
		
		public LoggingCallHandler()
		{
			
		}
		
		#region IInterceptionBehavior implementation
		public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
		{
			string MethodFullName = "[" + input.MethodBase.DeclaringType.FullName + "." + input.MethodBase.Name + "] ";
			//Before
			Logger.Debug(String.Format(MethodFullName + "Trying to invoke method [{0}] with the following parameters => ", input.MethodBase.Name));

			IEnumerator enumerator = input.Arguments.GetEnumerator();
			
			Logger.Debug(String.Format(MethodFullName + "Number of Arguments: {0}", input.Arguments.Count));
			foreach (object obj in input.Arguments) {
				int index = input.Arguments.IndexOf(obj);
				ParameterInfo info = input.Arguments.GetParameterInfo(index);
				Logger.Debug(String.Format(MethodFullName + "Parameter: [{0}] ==> Value: [{1}]", info.Name, info.DefaultValue ?? "None"));
				Logger.Debug(String.Format(MethodFullName + "Parameter Type: [{0}]", info.ParameterType.FullName));
			
			}
			
			var result = getNext()(input, getNext);
				
			if (result.Exception != null) {
				Logger.
					Error(String.Format(MethodFullName + "Call to method [{0}] failed due to following exception => {1}", 
					input.MethodBase, result.Exception.Message));
				Logger.Error(MethodFullName + "Source of the exception => " + result.Exception.Source);
				Logger.Error(MethodFullName + "Data related to exception => ");
				foreach (string key in result.Exception.Data.Keys) {
					Logger.Error(String.Format(MethodFullName + "Key: {0} = Value: {1}", key, result.Exception.Data[key]));
				}
				Logger.Error(MethodFullName + "Inner exception details => " + result.Exception.InnerException.Message);
				Logger.Error(MethodFullName + "Stack trace => " + result.Exception.StackTrace);			
			} else {
				Logger.Debug(String.Format(MethodFullName + "Method [{0}] has been executed successfully with return value => [{1}]", input.MethodBase.Name, result.ReturnValue));
			}
			
			
			return result;
		}
		
		public int Order{
			get;
			set;
		}
		#endregion
		
	}
}