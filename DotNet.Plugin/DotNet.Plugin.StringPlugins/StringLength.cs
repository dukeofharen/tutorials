using System;
using DotNet.Plugin.Business;

namespace DotNet.Plugin.StringPlugins
{
	public class StringLength : IPlugin
	{
		public string Explanation
		{
			get
			{
				return "Gets a string as parameter and returns the string length in characters.";
			}
		}

		public string Name
		{
			get
			{
				return "strlength";
			}
		}

		public void Go(string parameters)
		{
			Console.WriteLine(parameters.Length);
		}
	}
}
