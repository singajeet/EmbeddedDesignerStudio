/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/12/2017
 * Time: 6:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using Core.Interfaces.Modules;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Core.Interfaces.Services;

namespace Core.Services
{
	/// <summary>
	/// Description of ServiceLocator.
	/// </summary>
	public class ServiceLocator : IServiceLocator
	{
		private IUnityContainer _container;
		private static ServiceLocator _locator;
		
		private ServiceLocator()
		{
			_container = new UnityContainer();
			UnityConfigurationSection section = 
				(UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			
			section.Configure(_container, "EmbeddedDesignerStudioMainContainer");
		}
		
		public static IServiceLocator Start(){			
			if (_locator == null)
				_locator = new ServiceLocator();
			return _locator; 						
		}

        public object ResolveInterface(Type t, params ResolverOverride[] resolverOverrides)
        {
             return this._container.Resolve(t);
        }

		public object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides)
		{
			return this._container.Resolve(t, name, resolverOverrides);
		}		
		
		public T Resolve<T>(string name, params ResolverOverride[] resolverOverrides)
		{
			return this._container.Resolve<T>(name, resolverOverrides);
		}	

		public T Resolve<T>(params ResolverOverride[] resolverOverrides)
		{
			return this._container.Resolve<T>(resolverOverrides);            
		}		
		
		public IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides)
		{
			return this._container.ResolveAll(t, resolverOverrides);
		}
		
		public IEnumerable<T> ResolveAll<T>(params ResolverOverride[] resolverOverrides)
		{
			return this._container.ResolveAll<T>(resolverOverrides);
		}
		
		public IUnityContainer GetContainer()
		{
			return this._container;
		}
		
		public IUnityContainer Container{
			get { return this._container; }
		}
	}
}
