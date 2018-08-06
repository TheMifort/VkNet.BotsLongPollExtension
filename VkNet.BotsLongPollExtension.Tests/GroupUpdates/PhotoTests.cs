using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class PhotoTests
	{
		[Test]
		public void PhotoNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"photo_new\",\r\n  \"object\": {\r\n    \"id\": 123456,\r\n    \"album_id\": 1234,\r\n    \"owner_id\": -1234,\r\n    \"user_id\": 100,\r\n    \"sizes\": [\r\n      {\r\n        \"type\": \"s\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a000/lUOsa955-jY.jpg\",\r\n        \"width\": 75,\r\n        \"height\": 75\r\n      },\r\n      {\r\n        \"type\": \"m\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a001/iuKZIHc3wZQ.jpg\",\r\n        \"width\": 130,\r\n        \"height\": 130\r\n      },\r\n      {\r\n        \"type\": \"x\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a002/d6OlNoaopNU.jpg\",\r\n        \"width\": 604,\r\n        \"height\": 604\r\n      },\r\n      {\r\n        \"type\": \"y\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a003/_iE5hSNLl9U.jpg\",\r\n        \"width\": 807,\r\n        \"height\": 807\r\n      },\r\n      {\r\n        \"type\": \"z\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a004/33LbnCgpeIc.jpg\",\r\n        \"width\": 1024,\r\n        \"height\": 1024\r\n      },\r\n      {\r\n        \"type\": \"o\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a005/5IQIvtzM6VA.jpg\",\r\n        \"width\": 130,\r\n        \"height\": 130\r\n      },\r\n      {\r\n        \"type\": \"p\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a006/V6YM6vKahbw.jpg\",\r\n        \"width\": 200,\r\n        \"height\": 200\r\n      },\r\n      {\r\n        \"type\": \"q\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a007/ijJML7x7aKo.jpg\",\r\n        \"width\": 320,\r\n        \"height\": 320\r\n      },\r\n      {\r\n        \"type\": \"r\",\r\n        \"url\": \"https://pp.userapi.com/c840134/v840134869/5a008/rqmyhuQ57ic.jpg\",\r\n        \"width\": 510,\r\n        \"height\": 510\r\n      }\r\n    ],\r\n    \"text\": \"\",\r\n    \"date\": 1533399738\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var groupId = 1234;
			var photoId = 123456;
			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(-groupId, update.Photo.OwnerId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(photoId, update.Photo.Id);
		}

		[Test]
		public void PhotoCommentNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"photo_comment_new\",\r\n  \"object\": {\r\n    \"id\": 4,\r\n    \"from_id\": 123,\r\n    \"date\": 1533399764,\r\n    \"text\": \"test\",\r\n    \"photo_owner_id\": -1234,\r\n    \"photo_id\": 123456\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test";
			var photoId = 123456;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Comment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
			Assert.AreEqual(photoId, update.PhotoComment.PhotoId);
		}

		[Test]
		public void PhotoCommentEditTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"photo_comment_edit\",\r\n  \"object\": {\r\n    \"id\": 4,\r\n    \"from_id\": 123,\r\n    \"date\": 1533399764,\r\n    \"text\": \"test1\",\r\n    \"photo_owner_id\": -1234,\r\n    \"photo_id\": 456239020\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Comment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void PhotoCommentRestoreTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"photo_comment_restore\",\r\n  \"object\": {\r\n    \"id\": 4,\r\n    \"from_id\": 123,\r\n    \"date\": 1533399764,\r\n    \"text\": \"test1\",\r\n    \"photo_owner_id\": -1234,\r\n    \"photo_id\": 456239020\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PhotoComment.Comment.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.PhotoComment.Comment.Text);
			Assert.AreEqual(-groupId, update.PhotoComment.PhotoOwnerId);
		}

		[Test]
		public void PhotoCommentDeleteTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"photo_comment_delete\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"id\": 4,\r\n    \"deleter_id\": 12345,\r\n    \"photo_id\": 123456,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var deleterId = 12345;
			var groupId = 1234;
			var photoId = 123456;
			var id = 4;

			var vkResponse = updateJson.GetVkResponse();

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