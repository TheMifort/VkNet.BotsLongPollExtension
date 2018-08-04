using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к фотографии(PhotoCommentNew, PhotoCommentEdit, PhotoCommentRestore)
	/// </summary>
	[Serializable]
	public class PhotoComment
	{
		/// <summary>
		/// Коментарий
		/// </summary>
		public Comment Comment { get; set; }

		/// <summary>
		/// Идентификатор фотографии
		/// </summary>
		public ulong? PhotoId { get; set; }

		/// <summary>
		/// Идентификатор владельца фотографии
		/// </summary>
		public long? PhotoOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static PhotoComment FromJson(VkResponse response)
		{
			return new PhotoComment
			{
				Comment = response,
				PhotoId = response["photo_id"],
				PhotoOwnerId = response["photo_owner_id"]
			};
		}
	}
}