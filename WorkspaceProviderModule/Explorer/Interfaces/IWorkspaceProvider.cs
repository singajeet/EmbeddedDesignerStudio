/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 9/30/2017
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TemplateProviderModule.Interfaces;
using WorkspaceProviderModule.Explorer.Models;
using TemplateProviderModule.Models;

namespace WorkspaceProviderModule.Explorer.Interfaces
{
	/// <summary>
	/// Description of IWorkspaceService.
	/// </summary>
	public interface IWorkspaceProvider
	{
        CategoryCollection GetCategories();
        TemplateModelCollection GetTemplates();
        TemplateModelCollection GetTemplates(ICategory category);
        TemplateModelCollection GetTemplates(ICategory category, ILanguageType langType);        
        IProject GetProjectTemplate(ICategory category, ILanguageType langType, IProject project);
        IProject GetProjectTemplate(ICategory category, ILanguageType langType, Guid projectId);
	}
}
