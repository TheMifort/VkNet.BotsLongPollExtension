using NUnit.Framework;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class GroupTests
	{
		[Test]
		public void GroupChangePhotoTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}


		[Test]
		public void GroupJoinTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}

		[Test]
		public void GroupLeaveTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}

		[Test]
		public void GroupOfficersEditTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"group_officers_edit\",\r\n  \"object\": {\r\n    \"admin_id\": 123,\r\n    \"user_id\": 321,\r\n    \"level_old\": 3,\r\n    \"level_new\": 2\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var adminId = 123;
			var groupId = 1234;

			var oldLevel = GroupOfficerLevel.Admin;
			var newLevel = GroupOfficerLevel.Editor;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.GroupOfficersEdit.UserId);
			Assert.AreEqual(oldLevel, update.GroupOfficersEdit.LevelOld);
			Assert.AreEqual(newLevel, update.GroupOfficersEdit.LevelNew);
		}

		[Test]
		public void GroupChangeSettingsTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}

		[Test]
		public void UserBlockTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}

		[Test]
		public void UserUnblockTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"poll_vote_new\",\r\n  \"object\": {\r\n    \"owner_id\": -1234,\r\n    \"poll_id\": 4444,\r\n    \"option_id\": 3333,\r\n    \"user_id\": 123\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}
	}
}