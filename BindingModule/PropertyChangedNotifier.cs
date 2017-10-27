/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 5:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using Core.Interfaces;
using Core.Interfaces.Properties;
using Microsoft.Practices.Unity;
using Core.Interfaces.Modules;
using log4net;

namespace BindingModule
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	
	public class PropertyChangedNotifier : IPropertyChangedNotifier
	{
		
		ILog _logger;
		
		[Dependency]
		public ILog Logger{
			get { 
				return this._logger; 
			}
			set { this._logger = value; }
		}
		
		public PropertyChangedNotifier(){
			
		}
		#region IPropertyChangedNotifier implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		
		protected virtual void NotifyPropertyChanged<T>(Expression<Func<T>> property){
			var propertyInfo = ((MemberExpression) property.Body).Member as PropertyInfo;
			if(propertyInfo == null){
				if(this._logger != null)
					Logger.Error("The lambda expression 'property' should point to valid Property");
				throw new ArgumentException("The lambda expression 'property' should point to valid Property");
			}
			
			if(this._logger != null)
				Logger.Debug(String.Format("Value of Property [{0}] has been changed and notification for same will be raised", propertyInfo.Name));
			
			if(PropertyChanged != null){
				if(this._logger != null)
					Logger.Debug(String.Format("Raising property changed notification for property [{0}]", propertyInfo.Name));
				PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
			}
		}
		
	}
}