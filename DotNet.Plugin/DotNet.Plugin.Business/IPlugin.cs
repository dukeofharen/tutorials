namespace DotNet.Plugin.Business
{
	public interface IPlugin
	{
		string Name { get; }
		string Explanation { get; }
		void Go(string parameters);
	}
}

