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

namespace Core.Services
{
	/// <summary>
	/// Description of BaseService.
	/// </summary>
	public abstract class BaseService : IService
	{		
		protected ILog _logger;
		
		protected ServiceStatus _status;
		protected string _name;
		protected string _description;

		#region IService implementation

        [Dependency]
		protected ILog Logger{
			get { return this._logger; }
            set { this._logger = value; }
		}
		
		public ServiceStatus Status{
			get {
				return this._status;
			}            
		}
		
		public void Enable()
		{
			if(this._status.HasFlag(ServiceStatus.Disabled))
			{
				this._status &= ~ServiceStatus.Disabled;
				this._status |= ServiceStatus.Enabled;
				
				Logger.Info(String.Format("Service {0} has been Enabled", this._name));
			}
		}

		public void Disable()
		{
			if(this._status.HasFlag(ServiceStatus.Enabled)){
				this._status &= ~ServiceStatus.Enabled;
				this._status |= ServiceStatus.Disabled;
				
				Logger.Info(String.Format("Service [{0}] has been Disabled", this._name));
			}
		}

		public void Start()
		{
			if(this._status.HasFlag(ServiceStatus.Started)){
				Logger.Info(String.Format("Service [{0}] is already in started mode", this._name));
			} else {
				if (this._status == (ServiceStatus.Stopped | ServiceStatus.Enabled)) {
					this._status &= ~ServiceStatus.Stopped;
					this._status |= ServiceStatus.Started;
				} else {
					throw new Exception(string.Format("Invalid service state for this operation [{0}]", this._status));
				}
			
				Logger.Info(String.Format("Service [{0}] has been started", this._name));
			}
		}

		public void Stop()
		{
			if(this._status == (ServiceStatus.Started | ServiceStatus.Enabled)){								
				this._status &= ~ServiceStatus.Started;
				this._status |= ServiceStatus.Stopped;
			} else {
				throw new Exception(string.Format("Invalid service state for this operation [{0}]", this._status));
			}
			
			Logger.Info(String.Format("Service [{0}] has been stopped", this._name));
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
