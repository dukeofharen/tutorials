using System;
using System.Linq;
using DotNet.Plugin.Business;

namespace DotNet.Plugin
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Started plugin app..");
			try
			{
				PluginLoader loader = new PluginLoader();
				loader.LoadPlugins();
			}
			catch(Exception e)
			{
				Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", e.Message));
				Console.WriteLine("Press any key to exit...");
				Console.ReadKey();
				Environment.Exit(0);
			}
            while (true)
			{
				try
				{
					//Let the user fill in an plugin name
					Console.Write("> ");
					string line = Console.ReadLine();
					string name = line.Split(new char[] { ' ' }).FirstOrDefault();
					if (line == "exit")
					{
						Environment.Exit(0);
					}
					IPlugin plugin = PluginLoader.Plugins.Where(p => p.Name == name).FirstOrDefault();
					if (plugin != null)
					{
						//If the plugin is found, execute it
						string parameters = line.Replace(string.Format("{0} ", name), string.Empty);
						plugin.Go(parameters);
					}
					else
					{
						Console.WriteLine(string.Format("No plugin found with name '{0}'", name));
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(string.Format("Caught exception: {0}", e.Message));
				}
			}
		}
	}
}
