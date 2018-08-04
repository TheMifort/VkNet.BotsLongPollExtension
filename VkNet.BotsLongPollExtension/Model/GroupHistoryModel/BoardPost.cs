using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария в обсуждении(BoardPostNew, BoardPostEdit, BoardPostRestore)
	/// </summary>
	[Serializable]
	public class BoardPost
	{
		/// <summary>
		/// Коментарий
		/// </summary>
		public CommentBoard CommentBoard { get; set; }

		/// <summary>
		/// Идентификатор обсуждения
		/// </summary>
		public ulong? TopicId { get; set; }

		/// <summary>
		/// Идентификатор владельца обсуждения
		/// </summary>
		public long? TopicOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static BoardPost FromJson(VkResponse response)
		{
			return new BoardPost
			{
				CommentBoard = response,
				TopicId = response["topic_id"],
				TopicOwnerId = response["topic_owner_id"]
			};
		}
	}
}