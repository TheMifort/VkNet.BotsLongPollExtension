using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к видео(VideoCommentNew, VideoCommentEdit, VideoCommentRestore)
	/// </summary>
	[Serializable]
	public class VideoComment
	{
		/// <summary>
		/// Коментарий
		/// </summary>
		public Comment Comment { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи
		/// </summary>
		public ulong? VideoId { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи
		/// </summary>
		public long? VideoOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static VideoComment FromJson(VkResponse response)
		{
			return new VideoComment
			{
				Comment = response,
				VideoId = response["video_id"],
				VideoOwnerId = response["video_owner_id"]
			};
		}
	}
}