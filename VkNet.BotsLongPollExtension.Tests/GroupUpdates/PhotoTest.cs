using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class PhotoTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Photo";

		[Test]
		public void PhotoNewTest()
		{
			var groupId = 1234;
			var photoId = 123456;

			var updateJson = LoadJsonFromFile("photo_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(-groupId, update.Photo.OwnerId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(photoId, update.Photo.Id);
		}

		[Test]
		public void PhotoCommentNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";
			var photoId = 123456;

			var updateJson = LoadJsonFromFile("photo_comment_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
			Assert.AreEqual(photoId, update.PhotoComment.PhotoId);
		}

		[Test]
		public void PhotoCommentEditTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("photo_comment_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void PhotoCommentRestoreTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("photo_comment_restore");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void PhotoCommentDeleteTest()
		{
			var userId = 123;
			var deleterId = 12345;
			var groupId = 1234;
			var photoId = 123456;
			var id = 4;

			var updateJson = LoadJsonFromFile("photo_comment_delete");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(deleterId, update.UserId);
			Assert.AreEqual(deleterId, update.PhotoCommentDelete.DeleterId);
			Assert.AreEqual(userId, update.PhotoCommentDelete.UserId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.PhotoCommentDelete.OwnerId);
			Assert.AreEqual(photoId, update.PhotoCommentDelete.PhotoId);
			Assert.AreEqual(id, update.PhotoCommentDelete.Id);
		}
	}
}