using System;
using Newtonsoft.Json;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Model.GroupHistoryModel;
using VkNet.BotsLongPollExtension.Utils.JsonConverter;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;
using MarketComment = VkNet.BotsLongPollExtension.Model.GroupHistoryModel.MarketComment;
using WallReply = VkNet.BotsLongPollExtension.Model.GroupHistoryModel.WallReply;

namespace VkNet.BotsLongPollExtension.Model
{
	/// <summary>
	/// Обновление группы
	/// </summary>
	[Serializable]
	public class GroupUpdate
	{
		/// <summary>
		/// Тип обновления
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(EnumJsonConverter))]
		public GroupLongPollUpdateType Type { get; set; }

		/// <summary>
		/// Сообщение для типов событий с сообщением в ответе(MessageNew, MessageEdit, MessageReply)
		/// </summary>
		public Message Message { get; set; }

		/// <summary>
		/// Фотография для типов событий с фотографией в ответе(PhotoNew)
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Аудиозапись
		/// </summary>
		public Audio Audio { get; set; }

		/// <summary>
		/// Видеозапись
		/// </summary>
		public Video Video { get; set; }


		/// <summary>
		/// Подписка на сообщения от сообщества
		/// </summary>
		public MessageAllow MessageAllow { get; set; }

		/// <summary>
		/// Новый запрет сообщений от сообщества(MessageDeny)
		/// </summary>
		public MessageDeny MessageDeny { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к фотографии(PhotoCommentNew, PhotoCommentEdit, PhotoCommentRestore)
		/// </summary>
		public PhotoComment PhotoComment { get; set; }

		/// <summary>
		/// Удаление комментария к фотографии(PhotoCommentDelete)
		/// </summary>
		public PhotoCommentDelete PhotoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к видео(VideoCommentNew, VideoCommentEdit, VideoCommentRestore)
		/// </summary>
		public VideoComment VideoComment { get; set; }

		/// <summary>
		/// Удаление комментария к видео(VideoCommentDelete)
		/// </summary>
		public VideoCommentDelete VideoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария в обсуждении(BoardPostNew, BoardPostEdit, BoardPostRestore)
		/// </summary>
		public BoardPost BoardPost { get; set; }

		/// <summary>
		/// Удаление комментария в обсуждении(BoardPostDelete)
		/// </summary>
		public BoardPostDelete BoardPostDelete { get; set; }

		/// <summary>
		/// Изменение главного фото
		/// </summary>
		public GroupChangePhoto GroupChangePhoto { get; set; }

		/// <summary>
		/// Добавление участника или заявки на вступление в сообщество
		/// </summary>
		public GroupJoin GroupJoin { get; set; }

		/// <summary>
		/// Удаление/выход участника из сообщества
		/// </summary>
		public GroupLeave GroupLeave { get; set; }

		/// <summary>
		/// Редактирование списка руководителей
		/// </summary>
		public GroupOfficersEdit GroupOfficersEdit { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к товару(MarketCommentNew, MarketCommentEdit, MarketCommentRestore)
		/// </summary>
		public MarketComment MarketComment { get; set; }

		/// <summary>
		/// Удаление комментария к товару(MarketCommentDelete)
		/// </summary>
		public MarketCommentDelete MarketCommentDelete { get; set; }

		/// <summary>
		/// Добавление голоса в публичном опросе
		/// </summary>
		public PollVoteNew PollVoteNew { get; set; }

		/// <summary>
		/// Добавление пользователя в чёрный список
		/// </summary>
		public UserBlock UserBlock { get; set; }

		/// <summary>
		/// Удаление пользователя из чёрного списка
		/// </summary>
		public UserUnblock UserUnblock { get; set; }

		/// <summary>
		/// Новая запись на стене(WallPost, WallRepost)
		/// </summary>
		public WallPost WallPost { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария на стене(WallReplyNew, WallReplyEdit, WallReplyRestore)
		/// </summary>
		public WallReply WallReply { get; set; }

		/// <summary>
		/// Удаление комментария к записи(WallReplyDelete)
		/// </summary>
		public WallReplyDelete WallReplyDelete { get; set; }

		/// <summary>
		/// ID группы
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupUpdate FromJson(VkResponse response)
		{
			var fromJson = JsonConvert.DeserializeObject<GroupUpdate>(response.ToString());

			var resObj = response["object"];

			switch (fromJson.Type)
			{
				case GroupLongPollUpdateType.MessageNew:
				case GroupLongPollUpdateType.MessageEdit:
				case GroupLongPollUpdateType.MessageReply:
					fromJson.Message = resObj;
					break;
				case GroupLongPollUpdateType.MessageAllow:
					fromJson.MessageAllow = MessageAllow.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.MessageDeny:
					fromJson.MessageDeny = MessageDeny.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.PhotoNew:
					fromJson.Photo = resObj;
					break;
				case GroupLongPollUpdateType.PhotoCommentNew:
				case GroupLongPollUpdateType.PhotoCommentEdit:
				case GroupLongPollUpdateType.PhotoCommentRestore:
					fromJson.PhotoComment = PhotoComment.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.PhotoCommentDelete:
					fromJson.PhotoCommentDelete = PhotoCommentDelete.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.AudioNew:
					fromJson.Audio = resObj;
					break;
				case GroupLongPollUpdateType.VideoNew:
					fromJson.Video = resObj;
					break;
				case GroupLongPollUpdateType.VideoCommentNew:
				case GroupLongPollUpdateType.VideoCommentEdit:
				case GroupLongPollUpdateType.VideoCommentRestore:
					fromJson.VideoComment = VideoComment.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.VideoCommentDelete:
					fromJson.VideoCommentDelete = VideoCommentDelete.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.WallPostNew:
				case GroupLongPollUpdateType.WallRepost:
					fromJson.WallPost = WallPost.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.WallReplyNew:
				case GroupLongPollUpdateType.WallReplyEdit:
				case GroupLongPollUpdateType.WallReplyRestore:
					fromJson.WallReply = WallReply.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.WallReplyDelete:
					fromJson.WallReplyDelete = WallReplyDelete.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.BoardPostNew:
				case GroupLongPollUpdateType.BoardPostEdit:
				case GroupLongPollUpdateType.BoardPostRestore:
					fromJson.BoardPost = BoardPost.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.BoardPostDelete:
					fromJson.BoardPostDelete = BoardPostDelete.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.MarketCommentNew:
				case GroupLongPollUpdateType.MarketCommentEdit:
				case GroupLongPollUpdateType.MarketCommentRestore:
					fromJson.MarketComment = MarketComment.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.MarketCommentDelete:
					fromJson.MarketCommentDelete = MarketCommentDelete.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.GroupLeave:
					fromJson.GroupLeave = GroupLeave.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.GroupJoin:
					fromJson.GroupJoin = GroupJoin.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.UserBlock:
					fromJson.UserBlock = UserBlock.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.UserUnblock:
					fromJson.UserUnblock = UserUnblock.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.PollVoteNew:
					fromJson.PollVoteNew = PollVoteNew.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.GroupChangePhoto:
					fromJson.GroupChangePhoto = GroupChangePhoto.FromJson(resObj);
					break;
				case GroupLongPollUpdateType.GroupOfficersEdit:
					fromJson.GroupOfficersEdit = GroupOfficersEdit.FromJson(resObj);
					break;
			}

			return fromJson;
		}
	}
}