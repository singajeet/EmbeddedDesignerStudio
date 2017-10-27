/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 5:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace Core.Interfaces.Properties
{
	/// <summary>
	/// Description of IBindableProperty.
	/// </summary>
	public interface IPropertyChangedNotifier : INotifyPropertyChanged
	{
        event PropertyChangedEventHandler PropertyChanged;        
	}
}
