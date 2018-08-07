using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class GroupLongPollHistoryResponseTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; }

		[Test]
		public void Failed1Test()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.ToVkResponse();

			Assert.Throws<BotsLongPollHistoryOutdateException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed1TsTest()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.ToVkResponse();

			var ts = 10;

			try
			{
				GroupsLongPollHistoryResponse.FromJson(vkResponse);
				Assert.Fail();
			}
			catch (BotsLongPollHistoryOutdateException exception)
			{
				Assert.AreEqual(ts, exception.Ts);
			}
		}

		[Test]
		public void Failed2Test()
		{
			var updateJson = "{\"failed\":2}";

			var vkResponse = updateJson.ToVkResponse();

			Assert.Throws<BotsLongPollHistoryKeyExpiredException>(
				() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed3Test()
		{
			var updateJson = "{\"failed\":3}";

			var vkResponse = updateJson.ToVkResponse();

			Assert.Throws<BotsLongPollHistoryInfoLostException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void UpdatesTest()
		{
			var ts = 713;
			var userId = 123;
			var groupId = 1234;
			var type = GroupLongPollUpdateType.MessageNew;
			var updateCount = 2;

			var updateJson = LoadJsonFromFile("history");

			var vkResponse = updateJson.ToVkResponse();

			var history = GroupsLongPollHistoryResponse.FromJson(vkResponse);
			var updates = history.Updates.ToArray();

			Assert.AreEqual(ts, history.Ts);
			Assert.AreEqual(updateCount, updates.Length);
			Assert.AreEqual(type, updates[0].Type);
			Assert.AreEqual(type, updates[1].Type);
			Assert.AreEqual(userId, updates[0].UserId);
			Assert.AreEqual(userId, updates[1].UserId);
			Assert.AreEqual(groupId, updates[1].GroupId);
		}
	}
}