﻿using System;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Model.GroupHistoryModel
{
	/// <summary>
	/// Удаление/выход участника из сообщества
	/// </summary>
	[Serializable]
	public class GroupLeave
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public ulong? UserId { get; set; }

		/// <summary>
		/// Самостояльный ли был выход
		/// </summary>
		public bool? IsSelf { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static GroupLeave FromJson(VkResponse response)
		{
			return new GroupLeave {UserId = response["user_id"], IsSelf = response["self"]};
		}
	}
}