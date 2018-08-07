using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class BoardPostTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Board";

		[Test]
		public void BoardPostNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var updateJson = LoadJsonFromFile("board_post_new");

			var vkResponse = updateJson.ToVkResponse();

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
			var groupId = 1234;
			var text = "test";
			var topicId = 6;

			var updateJson = LoadJsonFromFile("board_post_new_first");

			var vkResponse = updateJson.ToVkResponse();

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
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("board_post_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(-groupId, update.BoardPost.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.BoardPost.Text);
			Assert.AreEqual(-groupId, update.BoardPost.TopicOwnerId);
		}

		[Test]
		public void BoardPostRestoreTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var updateJson = LoadJsonFromFile("board_post_restore");

			var vkResponse = updateJson.ToVkResponse();

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
			var groupId = 1234;
			var topicId = 6;
			var id = 3;

			var updateJson = LoadJsonFromFile("board_post_delete");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.BoardPostDelete.TopicOwnerId);
			Assert.AreEqual(topicId, update.BoardPostDelete.TopicId);
			Assert.AreEqual(id, update.BoardPostDelete.Id);
		}
	}
}