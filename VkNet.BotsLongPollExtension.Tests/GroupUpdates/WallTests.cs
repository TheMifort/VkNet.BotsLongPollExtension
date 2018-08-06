using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class WallTests
	{
		[Test]
		public void WallPostNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"wall_post_new\",\r\n  \"object\": {\r\n    \"id\": 6,\r\n    \"from_id\": 123,\r\n    \"owner_id\": -1234,\r\n    \"date\": 1533403316,\r\n    \"marked_as_ads\": 0,\r\n    \"post_type\": \"post\",\r\n    \"text\": \"test\",\r\n    \"can_edit\": 1,\r\n    \"created_by\": 123,\r\n    \"can_delete\": 1,\r\n    \"comments\": {\r\n      \"count\": 0\r\n    }\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallPost.FromId);
			Assert.AreEqual(-groupId, update.WallPost.Post.OwnerId);
		}

		[Test]
		public void WallReplyNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"wall_reply_new\",\r\n  \"object\": {\r\n    \"id\": 9,\r\n    \"from_id\": 123,\r\n    \"date\": 1533403427,\r\n    \"text\": \"test\",\r\n    \"post_owner_id\": -1234,\r\n    \"post_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test";
			var postId = 6;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Comment.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
			Assert.AreEqual(postId, update.WallReply.PostId);
		}

		[Test]
		public void WallReplyEditTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"wall_reply_edit\",\r\n  \"object\": {\r\n    \"id\": 9,\r\n    \"from_id\": 123,\r\n    \"date\": 1533403427,\r\n    \"text\": \"test1\",\r\n    \"post_owner_id\": -1234,\r\n    \"post_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Comment.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void WallReplyRestoreTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"wall_reply_restore\",\r\n  \"object\": {\r\n    \"id\": 9,\r\n    \"from_id\": 123,\r\n    \"date\": 1533403427,\r\n    \"text\": \"test1\",\r\n    \"post_owner_id\": -1234,\r\n    \"post_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Comment.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void WallReplyDeleteTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"wall_reply_delete\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"id\": 9,\r\n    \"deleter_id\": 12345,\r\n    \"post_id\": 6\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var groupId = 1234;
			var deleterId = 12345;
			var postId = 6;
			var id = 9;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(deleterId, update.UserId);
			Assert.AreEqual(deleterId, update.WallReplyDelete.DeleterId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.WallReplyDelete.OwnerId);
			Assert.AreEqual(postId, update.WallReplyDelete.PostId);
			Assert.AreEqual(id, update.WallReplyDelete.Id);
		}
	}
}