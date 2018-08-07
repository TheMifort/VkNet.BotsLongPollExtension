using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class VideoTests
	{
		[Test]
		public void VideoNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"video_new\",\r\n  \"object\": {\r\n    \"id\": 4444,\r\n    \"owner_id\": -1234,\r\n    \"title\": \"Test\",\r\n    \"duration\": 14,\r\n    \"description\": \"\",\r\n    \"date\": 1533402376,\r\n    \"comments\": 0,\r\n    \"views\": 1,\r\n    \"width\": 680,\r\n    \"height\": 720,\r\n    \"photo_130\": \"https://pp.userapi.com/c849028/v849028892/43296/cQDGL421aic.jpg\",\r\n    \"photo_320\": \"https://pp.userapi.com/c849028/v849028892/43294/uhE7yWEUJ6Y.jpg\",\r\n    \"photo_800\": \"https://pp.userapi.com/c849028/v849028892/43293/dEXbARrZQuE.jpg\",\r\n    \"repeat\": 1,\r\n    \"first_frame_800\": \"https://pp.userapi.com/c846320/v846320892/b3572/wVgFPd4YBsc.jpg\",\r\n    \"first_frame_320\": \"https://pp.userapi.com/c846320/v846320892/b3573/803qAiFud4o.jpg\",\r\n    \"first_frame_160\": \"https://pp.userapi.com/c846320/v846320892/b3574/cnHZIE4htwc.jpg\",\r\n    \"first_frame_130\": \"https://pp.userapi.com/c846320/v846320892/b3575/Vuo9kROpA5o.jpg\",\r\n    \"can_edit\": 1,\r\n    \"can_add\": 1\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var groupId = 1234;
			var id = 4444;
			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(-groupId, update.Video.OwnerId);
			Assert.AreEqual(id, update.Video.Id);
		}

		[Test]
		public void VideoCommentNewTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"video_comment_new\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533402417,\r\n    \"text\": \"test\",\r\n    \"video_owner_id\": -1234,\r\n    \"video_id\": 4444\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var videoId = 4444;
			var text = "test";

			var vkResponse = updateJson.GetVkResponse();

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
			var updateJson =
				"{\r\n  \"type\": \"video_comment_edit\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533402417,\r\n    \"text\": \"test1\",\r\n    \"video_owner_id\": -1234,\r\n    \"video_id\": 4444\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

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
			var updateJson =
				"{\r\n  \"type\": \"video_comment_restore\",\r\n  \"object\": {\r\n    \"id\": 1,\r\n    \"from_id\": 123,\r\n    \"date\": 1533402417,\r\n    \"text\": \"test1\",\r\n    \"video_owner_id\": -1234,\r\n    \"video_id\": 4444\r\n  },\r\n  \"group_id\": 1234\r\n}";
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var vkResponse = updateJson.GetVkResponse();

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
			var updateJson =
				"{\r\n  \"type\": \"video_comment_delete\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"id\": 4,\r\n    \"deleter_id\": 12345,\r\n    \"video_id\": 123456\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var groupId = 1234;
			var deleterId = 12345;
			var videoId = 123456;
			var id = 4;

			var vkResponse = updateJson.GetVkResponse();

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