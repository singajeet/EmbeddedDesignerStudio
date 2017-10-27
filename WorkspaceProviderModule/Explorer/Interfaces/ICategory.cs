/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 18:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
	/// <summary>
	/// Description of ICategoryAsNodeItem.
	/// </summary>
	public interface ICategory
	{
		string Name { get; set; }
		LanguageTypeCollection LanguageTypes { get; set; }
	}
}
