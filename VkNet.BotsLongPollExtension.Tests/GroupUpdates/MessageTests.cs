using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class MessageTests
	{
		[Test]
		public void NewMessageTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"message_new\",\r\n  \"object\": {\r\n    \"date\": 1533397795,\r\n    \"from_id\": 123,\r\n    \"id\": 829,\r\n    \"out\": 0,\r\n    \"peer_id\": 123,\r\n    \"text\": \"test\",\r\n    \"conversation_message_id\": 791,\r\n    \"fwd_messages\": [],\r\n    \"important\": false,\r\n    \"random_id\": 0,\r\n    \"attachments\": [],\r\n    \"is_hidden\": false\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId,update.UserId);
			Assert.AreEqual(userId,update.Message.FromId);
			Assert.AreEqual(groupId,update.GroupId);
			Assert.AreEqual(text,update.Message.Text);
		}

		[Test]
		public void EditMessageTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"message_edit\",\r\n  \"object\": {\r\n    \"date\": 1533397838,\r\n    \"from_id\": 123,\r\n    \"id\": 791,\r\n    \"out\": 1,\r\n    \"peer_id\": 123,\r\n    \"text\": \"test1\",\r\n    \"conversation_message_id\": 791,\r\n    \"fwd_messages\": [],\r\n    \"update_time\": 1533397838,\r\n    \"important\": false,\r\n    \"random_id\": 0,\r\n    \"attachments\": [],\r\n    \"is_hidden\": false\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void ReplyMessageTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"message_reply\",\r\n  \"object\": {\r\n    \"date\": 1533397818,\r\n    \"from_id\": 123,\r\n    \"id\": 830,\r\n    \"out\": 1,\r\n    \"peer_id\": 123,\r\n    \"text\": \"test\",\r\n    \"conversation_message_id\": 792,\r\n    \"fwd_messages\": [],\r\n    \"important\": false,\r\n    \"random_id\": 0,\r\n    \"attachments\": [],\r\n    \"admin_author_id\": 123,\r\n    \"is_hidden\": false\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void MessageAllowTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"message_allow\",\r\n  \"object\": {\r\n    \"user_id\": 123,\r\n    \"key\": \"123456\"\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var key = "123456";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MessageAllow.UserId);
			Assert.AreEqual(key, update.MessageAllow.Key);
			Assert.AreEqual(groupId, update.GroupId);
		}

		[Test]
		public void MessageDenyTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"message_deny\",\r\n  \"object\": {\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MessageDeny.UserId);
			Assert.AreEqual(groupId, update.GroupId);
		}
	}
}