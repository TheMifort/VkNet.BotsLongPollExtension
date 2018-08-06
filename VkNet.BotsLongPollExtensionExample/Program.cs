using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Abstractions;
using VkNet.Abstractions.Utils;
using VkNet.BotsLongPollExtension.Categories;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Model.RequestParams.Groups;
using VkNet.BotsLongPollExtension.Utils;
using VkNet.Model;

namespace VkNet.BotsLongPollExtensionExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var vkApi = new VkApi(new ServiceCollection().AddSingleton<IRestClient,RestClient>());

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
				try
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
				catch (BotsLongPollHistoryException exception)
				{
					if (exception is BotsLongPollHistoryOutdateException outdateException)
						ts = outdateException.Ts;
					else
					{
						server = api.Groups.GetLongPollServer(155242696);
						ts = server.Ts;
					}
				}
			}
		}
	}
}