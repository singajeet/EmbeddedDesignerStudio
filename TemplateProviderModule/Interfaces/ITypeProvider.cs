/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 9/28/2017
 * Time: 11:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TemplateProviderModule.Interfaces;
using TemplateProviderModule.Models;

namespace TemplateProviderModule.Interfaces
{
	/// <summary>
	/// Description of ITypeService.
	/// </summary>
	public interface ITypeProvider
	{
		TypeModelCollection Types { get; }
		IType CreateInstance();
		I CreateInstance<I>(string p_typeName, string assembly, string assemblyPath, string rootNamespace) where I : class;
		Type GetInterfaceTypeFromString(string interfaceName, string assembly, string assemblyPath, string rootNamespace);
	}
}
