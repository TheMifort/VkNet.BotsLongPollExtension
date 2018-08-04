using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Добавление/редактирование/восстановление комментария к товару(MarketCommentNew, MarketCommentEdit, MarketCommentRestore)
	/// </summary>
	[Serializable]
	public class MarketComment
	{
		/// <summary>
		/// Коментарий
		/// </summary>
		public Comment Comment { get; set; }

		/// <summary>
		/// Идентификатор товара
		/// </summary>
		public ulong? ItemId { get; set; }

		/// <summary>
		/// Идентификатор владельца товара
		/// </summary>
		public long? MarketOwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static MarketComment FromJson(VkResponse response)
		{
			return new MarketComment
			{
				Comment = response,
				ItemId = response["item_id"],
				MarketOwnerId = response["market_owner_id"]
			};
		}
	}
}