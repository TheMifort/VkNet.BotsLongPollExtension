using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Abstractions.Utils;
using VkNet.BotsLongPollExtension.Categories;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Model.RequestParams.Groups;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtensionExample
{
	static class Program
	{
		static void Main()
		{
			var vkApi = new VkApi(new ServiceCollection().AddSingleton<IRestClient, RestClient>());

			vkApi.Authorize(new ApiAuthParams
			{
				AccessToken = "0e079922e65573cf43323b974130af5b534b8496837af34ab16ad4fde641c97b6196f6e20267b1f7c6d71"
			});

			var server = vkApi.Groups.GetLongPollServer(155242696);

			var ts = server.Ts;
			while (true)
			{
				try
				{
					var history = vkApi.Groups.GetGroupLongPollHistory(new GroupsLongPollHistoryParams
					{
						Key = server.Key,
						Server = server.Server,
						Ts = ts,
						Wait = 25
					});
					ts = history.Ts;
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
						server = vkApi.Groups.GetLongPollServer(155242696);
						ts = server.Ts;
					}
				}
			}
		}
	}
}