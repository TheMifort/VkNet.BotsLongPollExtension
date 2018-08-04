using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария на стене(WallReplyNew, WallReplyEdit, WallReplyRestore)
	/// </summary>
	[Serializable]
	public class WallReply
	{
		/// <summary>
		/// Коментарий
		/// </summary>
		public Comment Comment { get; set; }

		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор владельца записи
		/// </summary>
		public long? PostOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static WallReply FromJson(VkResponse response)
		{
			return new WallReply
			{
				Comment = response,
				PostId = response["post_id"],
				PostOwnerId = response["post_owner_id"]
			};
		}
	}
}