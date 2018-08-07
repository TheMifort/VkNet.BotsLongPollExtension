using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class BoardPostTests
	{
		[Test]
		public void BoardPostNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"board_post_new\",\r\n  \"object\": {\r\n    \"id\": 3,\r\n    \"from_id\": 123,\r\n    \"date\": 1533404752,\r\n    \"text\": \"test\",\r\n    \"topic_owner_id\": -1234,\r\n    \"topic_id\": 38446232\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var vkResponse = updateJson.GetVkResponse();
			var text = "test";
			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void BoardPostNewFirstTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"board_post_new\",\r\n  \"object\": {\r\n    \"id\": 2,\r\n    \"from_id\": -1234,\r\n    \"date\": 1533404708,\r\n    \"text\": \"test\",\r\n    \"topic_owner_id\": -1234,\r\n    \"topic_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var groupId = 1234;
			var text = "test";
			var topicId = 6;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
			Assert.AreEqual(topicId, update.BoardPost.TopicId);
		}

		[Test]
		public void BoardPostEditTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"board_post_edit\",\r\n  \"object\": {\r\n    \"id\": 2,\r\n    \"from_id\": -1234,\r\n    \"date\": 1533404708,\r\n    \"text\": \"test1\",\r\n    \"topic_owner_id\": -1234,\r\n    \"topic_id\": 38446232\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void BoardPostRestoreTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"board_post_restore\",\r\n  \"object\": {\r\n    \"id\": 3,\r\n    \"from_id\": 123,\r\n    \"date\": 1533404752,\r\n    \"text\": \"test\",\r\n    \"topic_owner_id\": -1234,\r\n    \"topic_id\": 38446232\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void BoardPostDeleteTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"board_post_delete\",\r\n  \"object\": {\r\n    \"topic_owner_id\": -1234,\r\n    \"id\": 3,\r\n    \"topic_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var groupId = 1234;
			var topicId = 6;
			var id = 3;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.BoardPostDelete.TopicOwnerId);
			Assert.AreEqual(topicId, update.BoardPostDelete.TopicId);
			Assert.AreEqual(id, update.BoardPostDelete.Id);
		}
	}
}