using Newtonsoft.Json.Linq;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Tests
{
	public static class VkResponseHelper
	{
		public static VkResponse GetVkResponse(this string update)
		{
			var json = JObject.Parse(update);

			var rawResponse = json.Root;

			return new VkResponse(rawResponse) {RawJson = update};
		}
	}
}