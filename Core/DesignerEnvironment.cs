/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 10/13/2017
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

namespace Core
{
	/// <summary>
	/// Description of DesignerEnvironment.
	/// </summary>
	public class DesignerEnvironment
	{
		public DesignerEnvironment()
		{
			
		}
		
		public static string DesignerRootDirectory{
			get { return Environment.CurrentDirectory; }
		}
		
		public static DirectoryInfo DesignerRootDirectoryInfo{
			get { return new DirectoryInfo(Environment.CurrentDirectory); }
		}
		
		public static IDictionary EnvironmentVariables{
			get { return Environment.GetEnvironmentVariables(); }
		}
		
		public static string EnvironmentVariablesString{
			get { 
				StringBuilder strBuilder = new StringBuilder();
				foreach (string key in Environment.GetEnvironmentVariables().Keys) {
					strBuilder.AppendFormat("[{0}] = [{1}]", key, Environment.GetEnvironmentVariables()[key]);
					strBuilder.AppendLine();
				}
				return strBuilder.ToString();
			}
		}
		
		public static string MachineName{
			get { return Environment.MachineName; }
		}
		
		public static string OSVersion{
			get { return Environment.OSVersion.VersionString; }
		}
		
		public static string SystemDirectory{
			get { return Environment.SystemDirectory; }
		}
		
		public static DirectoryInfo SystemDirectoryInfo{
			get { return new DirectoryInfo(Environment.SystemDirectory); }
		}
		
		public static string Username{
			get { return Environment.UserName; }
		}
		
		public static string CLRVersion{
			get { return Environment.Version.ToString(); }
		}
		
		public static string GetAllDetailsAsPrintableString()
		{
			PropertyInfo[] properties = typeof(DesignerEnvironment).GetProperties();
			StringBuilder propString = new StringBuilder();
			
			for (int i = 0; i < properties.Length; i++) {
				propString.AppendFormat("[{0}] ==> [{1}]", properties[i].Name, properties[i].GetValue(0));
				propString.AppendLine();
			}
			
			return propString.ToString();
		}
	}
}
