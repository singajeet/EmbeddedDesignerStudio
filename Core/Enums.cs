/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/4/2017
 * Time: 3:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Core
{
	[Flags]
	public enum ServiceStatus{
	Stopped = 1,
	Started = 2,
	Paused = 4,
	Enabled = 8,
	Disabled = 16
	};
}
