using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class MarketTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Market";

		[Test]
		public void MarketCommentNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var updateJson =
				LoadJsonFromFile("market_comment_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}


		[Test]
		public void MarketCommentEditTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson =
				LoadJsonFromFile("market_comment_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void MarketCommentRestoreTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson =
				LoadJsonFromFile("market_comment_restore");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MarketComment.FromId);
			Assert.AreEqual(text, update.MarketComment.Text);
			Assert.AreEqual(-groupId, update.MarketComment.MarketOwnerId);
		}

		[Test]
		public void MarketCommentDeleteTest()
		{
			var deleterId = 123;
			var groupId = 1234;
			var itemId = 4444;
			var id = 1;

			var updateJson =
				LoadJsonFromFile("market_comment_delete");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.MarketCommentDelete.OwnerId);
			Assert.AreEqual(deleterId, update.MarketCommentDelete.DeleterId);
			Assert.AreEqual(itemId, update.MarketCommentDelete.ItemId);
			Assert.AreEqual(id, update.MarketCommentDelete.Id);
		}
	}
}