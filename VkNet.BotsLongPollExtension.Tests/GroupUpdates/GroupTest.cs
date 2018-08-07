using System;
using System.IO;
using NUnit.Framework;
using VkNet.BotsLongPollExtension.Enums;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class GroupTest : BaseTest
	{
		public override string Folder { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json");
		public override string CurrentTestData { get; } = "Group";


		[Test]
		public void GroupChangePhotoTest()
		{
			var userId = 123;
			var groupId = 1234;
			var id = 4444;

			var updateJson = LoadJsonFromFile("group_change_photo");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.GroupChangePhoto.UserId);
			Assert.AreEqual(-groupId, update.GroupChangePhoto.Photo.OwnerId);
			Assert.AreEqual(id, update.GroupChangePhoto.Photo.Id);
		}


		[Test]
		public void GroupJoinTest()
		{
			var userId = 321;
			var groupId = 1234;
			var joinType = GroupJoinType.Join;

			var updateJson =
				LoadJsonFromFile("group_join");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.GroupJoin.UserId);
			Assert.AreEqual(joinType, update.GroupJoin.JoinType);
		}

		[Test]
		public void GroupLeaveTest()
		{
			var userId = 321;
			var groupId = 1234;

			var updateJson =
				LoadJsonFromFile("group_leave");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsFalse(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GroupLeaveSelfTest()
		{
			var userId = 321;
			var groupId = 1234;

			var updateJson =
				LoadJsonFromFile("group_leave_self");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsTrue(update.GroupLeave.IsSelf);
		}

		[Test]
		public void GroupOfficersEditTest()
		{
			var userId = 321;
			var adminId = 123;
			var groupId = 1234;

			var oldLevel = GroupOfficerLevel.Admin;
			var newLevel = GroupOfficerLevel.Editor;

			var updateJson =
				LoadJsonFromFile("group_officers_edit");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.GroupOfficersEdit.UserId);
			Assert.AreEqual(oldLevel, update.GroupOfficersEdit.LevelOld);
			Assert.AreEqual(newLevel, update.GroupOfficersEdit.LevelNew);
		}


		[Test]
		public void UserBlockTest()
		{
			var userId = 321;
			var groupId = 1234;
			var adminId = 123;
			var comment = "test";
			var reason = GroupUserBlockReason.Other;

			var updateJson =
				LoadJsonFromFile("user_block");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId, update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.IsNull(update.UserBlock.UnblockDate);
		}

		[Test]
		public void UserBlockTemporaryTest()
		{
			var userId = 321;
			var groupId = 1234;
			var adminId = 123;
			var comment = "test";
			var reason = GroupUserBlockReason.MessagesOffTopic;
			var unblockDate = new DateTime(2018, 8, 6, 21, 0, 0);

			var updateJson =
				LoadJsonFromFile("user_block_temporary");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId, update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.AreEqual(unblockDate, update.UserBlock.UnblockDate);
		}

		[Test]
		public void UserUnblockTest()
		{
			var userId = 321;
			var groupId = 1234;
			var adminId = 123;

			var updateJson =
				LoadJsonFromFile("user_unblock");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.UserUnblock.UserId);
			Assert.AreEqual(adminId, update.UserUnblock.AdminId);
			Assert.IsFalse(update.UserUnblock.ByEndDate);
		}

		[Test]
		public void UserUnblockByEndDateTest()
		{
			var userId = 321;
			var groupId = 1234;
			var adminId = 123;

			var updateJson =
				LoadJsonFromFile("user_unblock_by_end_date");

			var vkResponse = updateJson.ToVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserUnblock.UserId);
			Assert.AreEqual(adminId, update.UserUnblock.AdminId);
			Assert.IsTrue(update.UserUnblock.ByEndDate);
		}
	}
}