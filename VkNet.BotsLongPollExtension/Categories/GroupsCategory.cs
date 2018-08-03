using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.BotsLongPollExtension.Model;
using VkNet.BotsLongPollExtension.Model.RequestParams.Groups;
using VkNet.BotsLongPollExtension.Utils;
using VkNet.Utils;

namespace VkNet.BotsLongPollExtension.Categories
{
	public static class GroupsCategory
	{
		/// <summary>
		/// Возвращаем обновления событий группы
		/// </summary>
		/// <param name="groupsCategory">Категория для работы с группами</param>
		/// <param name="params">Параметры запроса</param>
		public static GroupsLongPollHistoryResponse GetGroupLongPollHistory(this IGroupsCategory groupsCategory,
			GroupsLongPollHistoryParams @params)
		{
			return ReflectionHelper.GetPrivateField<IVkApiInvoke>(groupsCategory,"_vk").CallLongPoll(@params.Server, GroupsLongPollHistoryParams.ToVkParameters(@params));
		}

		/// <summary>
		/// Возвращаем обновления событий группы
		/// </summary>
		/// <param name="params">Параметры запроса</param>
		/// <param name="groupsCategory">Категория для работы с группами</param>
		public static Task<GroupsLongPollHistoryResponse> GetGroupLongPollHistoryAsync(
			this IGroupsCategory groupsCategory, GroupsLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync<GroupsLongPollHistoryResponse>(func: () =>
				GetGroupLongPollHistory(groupsCategory, @params));
		}
	}
}