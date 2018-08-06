using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class MarketTests
	{
		[Test]
		public void MarketCommentNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"market_comment_new\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533405772,\r\n    \"text\": \"test\",\r\n    \"market_owner_id\": -1234,\r\n    \"item_id\": 1686058\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var vkResponse = updateJson.GetVkResponse();
			
			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.Comment.FromId);
			Assert.AreEqual(text, update.MarketComment.Comment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}


		[Test]
		public void MarketCommentEditTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"market_comment_edit\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533405772,\r\n    \"text\": \"test1\",\r\n    \"market_owner_id\": -1234,\r\n    \"item_id\": 1686058\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.Comment.FromId);
			Assert.AreEqual(text, update.MarketComment.Comment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void MarketCommentRestoreTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"market_comment_restore\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533405772,\r\n    \"text\": \"test1\",\r\n    \"market_owner_id\": -1234,\r\n    \"item_id\": 1686058\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.Comment.FromId);
			Assert.AreEqual(text, update.MarketComment.Comment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void MarketCommentDeleteTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"market_comment_delete\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"id\": 1,\r\n    \"deleter_id\": 123,\r\n    \"item_id\": 4444\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var deleterId = 123;
			var groupId = 1234;
			var itemId = 4444;
			var id = 1;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.MarketCommentDelete.OwnerId);
			Assert.AreEqual(deleterId, update.MarketCommentDelete.DeleterId);
			Assert.AreEqual(itemId, update.MarketCommentDelete.ItemId);
			Assert.AreEqual(id, update.MarketCommentDelete.Id);
		}
	}
}