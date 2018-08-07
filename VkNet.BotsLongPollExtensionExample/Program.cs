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

			ulong groupId = 123;

			vkApi.Authorize(new ApiAuthParams
			{
				AccessToken = "token"
			});

			var server = vkApi.Groups.GetLongPollServer(groupId);

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
						server = vkApi.Groups.GetLongPollServer(groupId);
						ts = server.Ts;
					}
				}
			}
		}
	}
}