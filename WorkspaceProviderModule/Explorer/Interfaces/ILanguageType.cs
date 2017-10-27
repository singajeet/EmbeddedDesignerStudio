/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 09/26/2017
 * Time: 18:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using WorkspaceProviderModule.Explorer.Models;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
	/// <summary>
	/// Description of ILanguageTypeAsNodeItem.
	/// </summary>
	public interface ILanguageType
	{
		string Name { get; set; }
		ProjectCollection Projects { get; set; }
	}
}
