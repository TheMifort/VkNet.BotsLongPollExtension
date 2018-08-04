﻿namespace VkNet.BotsLongPollExtension.Enums
{
	/// <summary>
	/// Тип вступления в группу
	/// </summary>
	public enum GroupJoinType
	{
		/// <summary>
		/// Пользователь вступил в группу или мероприятие (подписался на публичную страницу)
		/// </summary>
		Join,
		/// <summary>
		///  Для мероприятий: пользователь выбрал вариант «Возможно, пойду»
		/// </summary>
		Unsure,
		/// <summary>
		/// Пользователь принял приглашение в группу или на мероприятие
		/// </summary>
		Accepted,
		/// <summary>
		/// Заявка на вступление в группу/мероприятие была одобрена руководителем сообщества
		/// </summary>
		Approved,
		/// <summary>
		/// Пользователь подал заявку на вступление в сообщество
		/// </summary>
		Request
	}
}