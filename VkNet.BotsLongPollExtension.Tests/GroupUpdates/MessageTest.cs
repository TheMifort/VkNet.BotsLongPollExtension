using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class MessageTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Message";

		[Test]
		public void MessageNewTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var updateJson = LoadJsonFromFile("message_new");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void MessageEditTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test1";

			var updateJson = LoadJsonFromFile("message_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void MessageReplyTest()
		{
			var userId = 123;
			var groupId = 1234;
			var text = "test";

			var updateJson = LoadJsonFromFile("message_reply");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.Message.FromId);
			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(text, update.Message.Text);
		}

		[Test]
		public void MessageAllowTest()
		{
			var userId = 123;
			var groupId = 1234;
			var key = "123456";

			var updateJson = LoadJsonFromFile("message_allow");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MessageAllow.UserId);
			Assert.AreEqual(key, update.MessageAllow.Key);
			Assert.AreEqual(groupId, update.GroupId);
		}

		[Test]
		public void MessageDenyTest()
		{
			var userId = 123;
			var groupId = 1234;

			var updateJson = LoadJsonFromFile("message_deny");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.MessageDeny.UserId);
			Assert.AreEqual(groupId, update.GroupId);
		}
	}
}