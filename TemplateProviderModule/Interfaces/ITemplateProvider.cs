/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 9/28/2017
 * Time: 10:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Interfaces.Providers;
using TemplateProviderModule.Interfaces;
using TemplateProviderModule.Models;

namespace TemplateProviderModule.Interfaces
{
	/// <summary>
	/// Description of ITemplateService.
	/// </summary>
	
	public interface ITemplateProvider
	{		
		TemplateModelCollection Templates { get; }
		ITemplate CreateInstance();
		void LoadTemplate(string p_path);
		TemplateModelCollection GetAllTemplates();
	}
}
