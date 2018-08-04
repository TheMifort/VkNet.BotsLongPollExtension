using System;
using System.Linq;
using System.Threading;
using VkNet.Abstractions;
using VkNet.BotsLongPollExtension.Categories;
using VkNet.BotsLongPollExtension.Model.RequestParams.Groups;
using VkNet.Model;

namespace VkNet.BotsLongPollExtentionExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var vkApi = new VkApi();

			vkApi.Authorize(new ApiAuthParams
			{
				AccessToken = "0e079922e65573cf43323b974130af5b534b8496837af34ab16ad4fde641c97b6196f6e20267b1f7c6d71"
			});

			var server = vkApi.Groups.GetLongPollServer(155242696);

			HistoryListner(vkApi, server);
		}

		static void HistoryListner(IVkApi api, LongPollServerResponse server)
		{
			var ts = server.Ts;
			while (true)
			{
				var history = api.Groups.GetGroupLongPollHistory(new GroupsLongPollHistoryParams
				{
					Key = server.Key,
					Server = server.Server,
					Ts = ts,
					Wait = 25
				});
				ts = history.Ts;
				Console.WriteLine(history.Updates.Count());
				foreach (var update in history.Updates)
				{
					Console.WriteLine(update.Type);
				}
				Thread.Sleep(100);
			}
		}
	}
}