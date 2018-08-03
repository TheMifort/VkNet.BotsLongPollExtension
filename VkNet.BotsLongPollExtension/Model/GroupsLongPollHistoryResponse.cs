using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Utils;
using VkNet.BotsLongPollExtension.Utils.JsonConverter;
using VkNet.Model;
using VkNet.Model.Attachments;
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
		public List<GroupUpdate> Updates { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupsLongPollHistoryResponse FromJson(VkResponse response)
		{
			var fromJson = new GroupsLongPollHistoryResponse
			{
				Ts = response["ts"],
			};

			VkResponseArray updates = response[key: "updates"];
			fromJson.Updates = new List<GroupUpdate>();
			foreach (var update in updates)
			{
				fromJson.Updates.Add(GroupUpdate.FromJson(update));
			}

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
		/// Сообщение для типов событий с сообщением в ответе
		/// </summary>
		public Message Message { get; set; }

		/// <summary>
		/// Фотография для типов событий с фотографией в ответе
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Комментарий для типов событий с комментарием в ответе
		/// </summary>
		public Comment Comment { get; set; }

		/// <summary>
		/// Комментарий для обсуждения
		/// </summary>
		public CommentBoard CommentBoard { get; set; }

		/// <summary>
		/// Аудиозапись
		/// </summary>
		public Audio Audio { get; set; }

		/// <summary>
		/// Видеозапись
		/// </summary>
		public Video Video { get; set; }

		/// <summary>
		/// Пост на стене
		/// </summary>
		public Post Post { get; set; }

		/// <summary>
		/// ID группы
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// ID пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Параметр, переданный в методе messages.allowMessagesFromGroup.
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// ID фотографии
		/// </summary>
		public ulong? PhotoId { get; set; }

		/// <summary>
		/// ID владельца фотографии
		/// </summary>
		public long? PhotoOwnerId { get; set; }

		/// <summary>
		/// Id комментария
		/// </summary>
		public ulong? Id { get; set; }

		/// <summary>
		/// Id пользователя, который удалил комментарий
		/// </summary>
		public ulong? DeleterId { get; set; }

		/// <summary>
		/// ID видеозаписи
		/// </summary>
		public long? VideoId { get; set; }

		/// <summary>
		/// ID владельца видео
		/// </summary>
		public long? VideoOwnerId { get; set; }

		/// <summary>
		/// Id владельца комментария
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Id отложенной записи
		/// </summary>
		public long? PosponedId { get; set; }

		/// <summary>
		/// Id пользователя, от кого размещена запись
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// ID записи на стене
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// ID владельца записи
		/// </summary>
		public long? PostOwnerId { get; set; }

		public long? TopicId { get; set; }
		public long? TopicOwnerId { get; set; }

		public long? MarketOwnerId { get; set; }
		public long? ItemId { get; set; }

		public bool? Self { get; set; }

		public string JoinType { get; set; }

		public long? AdminId { get; set; }

		public ulong? UnblockDate { get; set; }

		public int? Reason { get; set; }

		public string AdminComment { get; set; }

		public bool? IsBlockDateEnded { get; set; }

		public long? PollId { get; set; }

		public long? OptionId { get; set; }

		public int? OldLevel { get; set; }
		public int? NewLevel { get; set; }

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
				case GroupLongPollUpdateType.MessageDeny:
					fromJson.UserId = resObj["user_id"];
					fromJson.Key = resObj["key"];
					break;
				case GroupLongPollUpdateType.PhotoNew:
					fromJson.Photo = resObj;
					break;
				case GroupLongPollUpdateType.PhotoCommentNew:
				case GroupLongPollUpdateType.PhotoCommentEdit:
				case GroupLongPollUpdateType.PhotoCommentRestore:
					fromJson.Comment = resObj;
					fromJson.PhotoId = resObj["photo_id"];
					fromJson.PhotoOwnerId = resObj["photo_owner_id"];
					break;
				case GroupLongPollUpdateType.PhotoCommentDelete:
					fromJson.OwnerId = resObj["owner_id"];
					fromJson.Id = resObj["id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.DeleterId = resObj["deleter_id"];
					fromJson.PhotoId = resObj["photo_id"];
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
					fromJson.Comment = resObj;
					fromJson.VideoId = resObj["video_id"];
					fromJson.VideoOwnerId = resObj["video_owner_id"];
					break;
				case GroupLongPollUpdateType.VideoCommentDelete:
					fromJson.OwnerId = resObj["owner_id"];
					fromJson.Id = resObj["id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.DeleterId = resObj["deleter_id"];
					fromJson.PhotoId = resObj["video_id"];
					break;
				case GroupLongPollUpdateType.WallPostNew:
				case GroupLongPollUpdateType.WallRepost:
					fromJson.Post = resObj;
					fromJson.PosponedId = resObj["postponed_id"];
					fromJson.FromId = resObj["from_id"];
					break;
				case GroupLongPollUpdateType.WallReplyNew:
				case GroupLongPollUpdateType.WallReplyEdit:
				case GroupLongPollUpdateType.WallReplyRestore:
					fromJson.Comment = resObj;
					fromJson.PostId = resObj["post_id"];
					fromJson.PostOwnerId = resObj["post_owner_id"];
					break;
				case GroupLongPollUpdateType.WallReplyDelete:
					fromJson.OwnerId = resObj["owner_id"];
					fromJson.Id = resObj["id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.DeleterId = resObj["deleter_id"];
					fromJson.PostId = resObj["post_id"];
					break;
				case GroupLongPollUpdateType.BoardPostNew:
				case GroupLongPollUpdateType.BoardPostEdit:
				case GroupLongPollUpdateType.BoardPostRestore:
					fromJson.CommentBoard = resObj;
					fromJson.TopicId = resObj["topic_id"];
					fromJson.TopicOwnerId = resObj["topic_owner_id"];
					break;
				case GroupLongPollUpdateType.BoardPostDelete:
					fromJson.TopicOwnerId = resObj["topic_owner_id"];
					fromJson.TopicId = resObj["topic_id"];
					fromJson.Id = resObj["id"];
					break;
				case GroupLongPollUpdateType.MarketCommentNew:
				case GroupLongPollUpdateType.MarketCommentEdit:
				case GroupLongPollUpdateType.MarketCommentRestore:
					fromJson.Comment = resObj;
					fromJson.MarketOwnerId = resObj["market_owner_id"];
					fromJson.ItemId = resObj["item_id"];
					break;
				case GroupLongPollUpdateType.MarketCommentDelete:
					fromJson.OwnerId = resObj["owner_id"];
					fromJson.Id = resObj["id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.DeleterId = resObj["deleter_id"];
					fromJson.PostId = resObj["item_id"];
					break;
				case GroupLongPollUpdateType.GroupLeave:
					fromJson.UserId = resObj["user_id"];
					fromJson.Self = resObj["self"];
					break;
				case GroupLongPollUpdateType.GroupJoin:
					fromJson.UserId = resObj["user_id"];
					fromJson.JoinType = resObj["join_type"];
					break;
				case GroupLongPollUpdateType.UserBlock:
					fromJson.AdminId = resObj["admin_id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.UnblockDate = resObj["unblock_date"];
					fromJson.Reason = resObj["reason"];
					fromJson.Comment = resObj["comment"];
					break;
				case GroupLongPollUpdateType.UserUnblock:
					fromJson.AdminId = resObj["admin_id"];
					fromJson.UserId = resObj["user_id"];
					fromJson.IsBlockDateEnded = resObj["by_end_date"];
					break;
				case GroupLongPollUpdateType.PollVoteNew:
					fromJson.OwnerId = resObj["owner_id"];
					fromJson.PollId = resObj["poll_id"];
					fromJson.OptionId = resObj["option_id"];
					fromJson.UserId = resObj["user_id"];
					break;
			}

			return fromJson;
		}
	}
}