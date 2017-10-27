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
using Microsoft.Practices.Unity;

namespace Core.Interfaces.Services
{
	/// <summary>
	/// Description of IServiceLocator.
	/// </summary>
	public interface IServiceLocator
	{
        object ResolveInterface(Type t, params ResolverOverride[] resolverOverrides);
		object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides);
		T Resolve<T>(string name, params ResolverOverride[] resolverOverrides);
		T Resolve<T>(params ResolverOverride[] resolverOverrides);
		IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides);
		IEnumerable<T> ResolveAll<T>(params ResolverOverride[] resolverOverrides);
		IUnityContainer GetContainer();
		IUnityContainer Container{ get; }
	}
}
