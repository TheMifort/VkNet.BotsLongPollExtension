using System.IO;
using Newtonsoft.Json.Linq;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Tests
{
	public abstract class BaseTest
	{
		public abstract string Folder { get; }

		public abstract string CurrentTestData { get; }

		public string LoadJsonFromFile(string fileName)
		{
			var pathToFile =
				$"{Folder}{Path.DirectorySeparatorChar}{CurrentTestData}{Path.DirectorySeparatorChar}{fileName}.json";
			return File.ReadAllText(pathToFile);
		}
	}
}