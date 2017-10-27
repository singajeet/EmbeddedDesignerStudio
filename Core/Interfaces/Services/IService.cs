/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace Core.Interfaces.Services
{
	/// <summary>
	/// Description of IService.
	/// </summary>
	public interface IService : INotifyPropertyChanged
	{
		string Name { get; }
		string Description { get; }
		ServiceStatus Status { get; }
		void Enable();
		void Disable();
		void Start();
		void Stop();		
		void Dispose();
	}
}
