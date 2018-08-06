using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Utils;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model
{
	/// <summary>
	/// Обновление в событиях группы
	/// </summary>
	[Serializable]
	public class GroupsLongPollHistoryResponse
	{
		/// <summary>
		/// Номер последнего события, начиная с которого нужно получать данные;
		/// </summary>
		[JsonProperty("ts")]
		public ulong Ts { get; set; }

		/// <summary>
		/// Обновления группы
		/// </summary>

		[JsonProperty("updates")]
		public IEnumerable<GroupUpdate> Updates { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupsLongPollHistoryResponse FromJson(VkResponse response)
		{
			if (response.ContainsKey("failed"))
			{
				int code = response["failed"];
				if(code == 1) throw new BotsLongPollHistoryOutdateException(response["ts"]);
				if(code == 2) throw new BotsLongPollHistoryKeyExpiredException();
				if(code == 3) throw new BotsLongPollHistoryInfoLostException();
			}

			var fromJson = new GroupsLongPollHistoryResponse
			{
				Ts = response["ts"],
			};

			VkResponseArray updates = response[key: "updates"];
			var updateList = new List<GroupUpdate>();
			foreach (var update in updates)
			{
				updateList.Add(GroupUpdate.FromJson(update));
			}

			fromJson.Updates = updateList;
			return fromJson;
		}
		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupsLongPollHistoryResponse(VkResponse response)
		{
			var token = ReflectionHelper.GetPrivateField<JToken>(response, "_token");
			return token == null || !token.HasValues ? null : FromJson(response: response);
		}
	}
}