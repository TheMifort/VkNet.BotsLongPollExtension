using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class VideoTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Video";

		[Test]
		public void VideoNewTest()
		{
			var groupId = 1234;
			var id = 4444;

			var updateJson = LoadJsonFromFile("video_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.Video.OwnerId);
			Assert.AreEqual(id, update.Video.Id);
		}

		[Test]
		public void VideoCommentNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var videoId = 4444;
			var text = "test";

			var updateJson = LoadJsonFromFile("video_comment_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
			Assert.AreEqual(videoId, update.VideoComment.VideoId);
		}

		[Test]
		public void VideoCommentEditTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("video_comment_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void VideoCommentRestoreTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("video_comment_restore");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.VideoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.VideoComment.Text);
			Assert.AreEqual(-groupId, update.VideoComment.VideoOwnerId);
		}

		[Test]
		public void VideoCommentDeleteTest()
		{
			var groupId = 1234;
			var deleterId = 12345;
			var videoId = 123456;
			var id = 4;

			var updateJson = LoadJsonFromFile("video_comment_delete");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(deleterId, update.UserId);
			Assert.AreEqual(deleterId, update.VideoCommentDelete.DeleterId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.VideoCommentDelete.OwnerId);
			Assert.AreEqual(videoId, update.VideoCommentDelete.VideoId);
			Assert.AreEqual(id, update.VideoCommentDelete.Id);
		}
	}
}