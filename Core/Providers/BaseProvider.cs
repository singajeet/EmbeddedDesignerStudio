/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 3:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Core.Interfaces.Services;
using Core.Interfaces.Modules;
using log4net;
using Microsoft.Practices.Unity;
using Core.Interfaces.Providers;

namespace Core.Providers
{
	/// <summary>
	/// Description of BaseService.
	/// </summary>
	public abstract class BaseProvider : IProvider
	{		
		protected ILog _logger;
		
		protected string _name;
		protected string _description;

		#region IProvider implementation

        [Dependency]
		protected ILog Logger{
			get { return this._logger; }
            set { this._logger = value; }
		}

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

		#endregion

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void OnPropertyChanged<T>(Expression<Func<T>> property)
		{
			PropertyInfo propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
			if (propertyInfo == null) {
				throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
			}
			if (this.PropertyChanged != null) {
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
			}
		}
	}
}
