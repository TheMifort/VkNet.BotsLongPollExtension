using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using NLog;
using VkNet.Abstractions;
using VkNet.BotsLongPollExtension.Utils;
using VkNet.Exception;
using VkNet.Utils;
using RestClient = VkNet.BotsLongPollExtension.Utils.RestClient;

namespace VkNet.BotsLongPollExtension
{
	/// <summary>
	/// Расширение для VkApiExtension
	/// </summary>
	public static class VkApiExtension
	{
		/// <summary>
		/// Вызвать LongPoll запрос обновления группы.
		/// </summary>
		/// <param name="vkApi">VkNet Api</param>
		/// <param name="server">Сервер</param>
		/// <param name="parameters"> Параметры. </param>
		public static VkResponse CallLongPoll(this IVkApiInvoke vkApi, string server, VkParameters parameters)
		{
			var answer = CallBase((VkApi) vkApi, parameters, server);

			var json = JObject.Parse(json: answer);

			var rawResponse = json.Root;

			var poll = new VkResponse(token: rawResponse) {RawJson = answer};

			VkResponseArray updates = poll[key: "updates"];
			if (updates != null)
				foreach (var update in updates)
				{
					LogToFile(update["type"], update.ToString());
				}

			return poll;
		}

		private static void LogToFile(string type, string answer)
		{
			var directory =
				$"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}Json{Path.DirectorySeparatorChar}";
			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);
			var unixTimestamp = (int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			using (var sw = new StreamWriter(directory + type + unixTimestamp + ".json"))
			{
				sw.Write(answer);
			}
		}

		/// <summary>
		/// Базовое обращение к vk.com
		/// </summary>
		/// <param name="vkApi">VkNet Api</param>
		/// <param name="parameters"> Параметры запроса </param>
		/// <param name="server">Сервер запроса</param>
		/// <returns> Ответ от vk.com в формате json </returns>
		/// <exception cref="CaptchaNeededException"> Требуется ввести капчу </exception>
		private static string CallBase(VkApi vkApi, VkParameters parameters, string server)
		{
			if (!parameters.ContainsKey(key: "v"))
			{
				parameters.Add(name: "v", value: vkApi.VkApiVersion.Version);
			}

			ReflectionHelper.GetPrivateField<ILogger>(vkApi, "_logger")?.Debug(message:
				$"Вызов GetBotsLongPollHistory, с параметрами {string.Join(separator: ",", values: parameters.Select(selector: x => $"{x.Key}={x.Value}"))}");

			//No captcha for bot api? TODO if needed
			return InvokeGetLongPollHistory(vkApi, parameters: parameters, server: server);
		}

		/// <summary>
		/// Получение истории обновлений группы
		/// </summary>
		/// <param name="vkApi">VkNet Api</param>
		/// <param name="parameters"> Вход. параметры метода. </param>
		/// <param name="server">Сервер для запроса</param>
		/// <exception cref="AccessTokenInvalidException"> </exception>
		/// <returns> Ответ сервера в формате JSON. </returns>
		public static string InvokeGetLongPollHistory(VkApi vkApi, IDictionary<string, string> parameters,
			string server)
		{
			var logger = ReflectionHelper.GetPrivateField<ILogger>(vkApi, "_logger");
			if (string.IsNullOrEmpty(server))
			{
				var message = $"Сервер не должен быть пустым или null";
				logger?.Error(message: message);

				throw new AccessTokenInvalidException(message: message);
			}

			//TODO Request limits

			var response = vkApi.RestClient
				.PostAsync(new Uri(server),
					parameters).ConfigureAwait(false).GetAwaiter().GetResult();

			var answer = response.Value ?? response.Message;

			logger?.Trace(message: $"Uri = \"{server}\"");
			logger?.Trace(message: $"Json ={Environment.NewLine}{Utilities.PreetyPrintJson(json: answer)}");

			VkErrors.IfErrorThrowException(json: answer);

			return answer;
		}
	}
}