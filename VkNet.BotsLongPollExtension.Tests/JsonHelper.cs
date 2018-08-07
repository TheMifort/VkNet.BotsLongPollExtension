using System;
using System.IO;
using Newtonsoft.Json.Linq;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Tests
{
	public static class JsonHelper
	{
		public static VkResponse ToVkResponse(this string update)
		{
			var json = JObject.Parse(update);

			var rawResponse = json.Root;

			return new VkResponse(rawResponse) {RawJson = update};
		}
	}
}