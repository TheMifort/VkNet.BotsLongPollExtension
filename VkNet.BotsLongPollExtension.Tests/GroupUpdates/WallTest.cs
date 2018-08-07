using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class WallTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Wall";

		[Test]
		public void WallPostNewTest()
		{
			var userId = 123;
			var groupId = 1234;

			var updateJson = LoadJsonFromFile("wall_post_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallPost.FromId);
			Assert.AreEqual(-groupId, update.WallPost.OwnerId);
		}

		[Test]
		public void WallReplyNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";
			var postId = 6;

			var updateJson = LoadJsonFromFile("wall_reply_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
			Assert.AreEqual(postId, update.WallReply.PostId);
		}

		[Test]
		public void WallReplyEditTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("wall_reply_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void WallReplyRestoreTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("wall_reply_restore");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.WallReply.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.WallReply.Text);
			Assert.AreEqual(-groupId, update.WallReply.PostOwnerId);
		}

		[Test]
		public void WallReplyDeleteTest()
		{
			var groupId = 1234;
			var deleterId = 12345;
			var postId = 6;
			var id = 9;

			var updateJson = LoadJsonFromFile("wall_reply_delete");

			var vkResponse = updateJson.ToVkResponse();

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