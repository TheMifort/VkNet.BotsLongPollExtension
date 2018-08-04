using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Новая запись на стене(WallPost, WallRepost)
	/// </summary>
	[Serializable]
	public class WallPost
	{
		/// <summary>
		/// Пост на стене
		/// </summary>
		public Post Post { get; set; }

		/// <summary>
		/// Id отложенной записи
		/// </summary>
		public long? PostponedId { get; set; }

		/// <summary>
		/// Id пользователя, от кого размещена запись
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static WallPost FromJson(VkResponse response)
		{
			return new WallPost
			{
				Post = response,
				PostponedId = response["postponed_id"],
				FromId = response["from_id"]
			};
		}
	}
}