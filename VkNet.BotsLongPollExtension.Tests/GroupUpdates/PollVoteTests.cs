using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class PollVoteTests
	{
		[Test]
		public void PollVoteNewTest()
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