using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class PollVoteTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "PollVote";

		[Test]
		public void PollVoteNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var optionId = 3333;
			var pollId = 4444;

			var updateJson = LoadJsonFromFile("poll_vote_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.PollVoteNew.UserId);
			Assert.AreEqual(optionId, update.PollVoteNew.OptionId);
			Assert.AreEqual(pollId, update.PollVoteNew.PollId);
		}
	}
}