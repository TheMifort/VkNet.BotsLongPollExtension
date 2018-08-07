using System.Linq;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class GroupLongPollHistoryResponseTests
	{
		[Test]
		public void Failed1Test()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryOutdateException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed1TsTest()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.GetVkResponse();

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

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryKeyExpiredException>(
				() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed3Test()
		{
			var updateJson = "{\"failed\":3}";

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryInfoLostException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void UpdatesTest()
		{
			var updateJson =
				"{\r\n  \"ts\": \"713\",\r\n  \"updates\": [\r\n    {\r\n      \"type\": \"message_new\",\r\n      \"object\": {\r\n        \"date\": 1533632855,\r\n        \"from_id\": 15864424,\r\n        \"id\": 858,\r\n        \"out\": 0,\r\n        \"peer_id\": 15864424,\r\n        \"text\": \"test\",\r\n        \"conversation_message_id\": 820,\r\n        \"fwd_messages\": [],\r\n        \"important\": false,\r\n        \"random_id\": 0,\r\n        \"attachments\": [],\r\n        \"is_hidden\": false\r\n      },\r\n      \"group_id\": 155242696\r\n    },\r\n\t{\r\n\t  \"type\": \"message_new\",\r\n\t  \"object\": {\r\n\t\t\"date\": 1533460380,\r\n\t\t\"from_id\": 15864424,\r\n\t\t\"id\": 853,\r\n\t\t\"out\": 0,\r\n\t\t\"peer_id\": 15864424,\r\n\t\t\"text\": \"0\",\r\n\t\t\"conversation_message_id\": 815,\r\n\t\t\"fwd_messages\": [],\r\n\t\t\"important\": false,\r\n\t\t\"random_id\": 0,\r\n\t\t\"attachments\": [],\r\n\t\t\"is_hidden\": false\r\n\t},\r\n\t\"group_id\": 155242696\r\n   }\r\n  ]\r\n}";

			var ts = 713;
			var userId = 15864424;
			var groupId = 155242696;
			var type = GroupLongPollUpdateType.MessageNew;
			var updateCount = 2;

			var vkResponse = updateJson.GetVkResponse();

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