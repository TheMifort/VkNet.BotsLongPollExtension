using System;
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
				"{\r\n  \"type\": \"group_change_photo\",\r\n  \"object\": {\r\n    \"user_id\": 123,\r\n    \"photo\": {\r\n      \"id\": 4444,\r\n      \"album_id\": -6,\r\n      \"owner_id\": -1234,\r\n      \"user_id\": 100,\r\n      \"sizes\": [\r\n        {\r\n          \"type\": \"s\",\r\n          \"url\": \"https://sun1-2.userapi.com/c830609/v830609207/15e4db/SSBTALZRXxo.jpg\",\r\n          \"width\": 75,\r\n          \"height\": 75\r\n        },\r\n        {\r\n          \"type\": \"m\",\r\n          \"url\": \"https://sun1-15.userapi.com/c830609/v830609207/15e4dc/7bcKr5iiVis.jpg\",\r\n          \"width\": 130,\r\n          \"height\": 130\r\n        },\r\n        {\r\n          \"type\": \"x\",\r\n          \"url\": \"https://sun1-3.userapi.com/c830609/v830609207/15e4dd/WnLOfTavZ_Q.jpg\",\r\n          \"width\": 604,\r\n          \"height\": 604\r\n        },\r\n        {\r\n          \"type\": \"y\",\r\n          \"url\": \"https://sun1-3.userapi.com/c830609/v830609207/15e4de/JC1mkuarBog.jpg\",\r\n          \"width\": 807,\r\n          \"height\": 807\r\n        },\r\n        {\r\n          \"type\": \"z\",\r\n          \"url\": \"https://sun1-16.userapi.com/c830609/v830609207/15e4df/PnfylXt-aRs.jpg\",\r\n          \"width\": 1080,\r\n          \"height\": 1080\r\n        },\r\n        {\r\n          \"type\": \"w\",\r\n          \"url\": \"https://sun1-16.userapi.com/c830609/v830609207/15e4e0/TBkOlLB4R5g.jpg\",\r\n          \"width\": 1254,\r\n          \"height\": 1254\r\n        },\r\n        {\r\n          \"type\": \"o\",\r\n          \"url\": \"https://sun1-20.userapi.com/c830609/v830609207/15e4e1/8-OfmMzEIGU.jpg\",\r\n          \"width\": 130,\r\n          \"height\": 130\r\n        },\r\n        {\r\n          \"type\": \"p\",\r\n          \"url\": \"https://sun1-4.userapi.com/c830609/v830609207/15e4e2/j7V4wbUan7U.jpg\",\r\n          \"width\": 200,\r\n          \"height\": 200\r\n        },\r\n        {\r\n          \"type\": \"q\",\r\n          \"url\": \"https://sun1-12.userapi.com/c830609/v830609207/15e4e3/u7z-FuP33jg.jpg\",\r\n          \"width\": 320,\r\n          \"height\": 320\r\n        },\r\n        {\r\n          \"type\": \"r\",\r\n          \"url\": \"https://sun1-13.userapi.com/c830609/v830609207/15e4e4/RIvHkxHK9eo.jpg\",\r\n          \"width\": 510,\r\n          \"height\": 510\r\n        }\r\n      ],\r\n      \"text\": \"\",\r\n      \"date\": 1533589819,\r\n      \"post_id\": 12\r\n    }\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 123;
			var groupId = 1234;
			var id = 4444;

			var vkResponse = updateJson.GetVkResponse();

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
			var updateJson =
				"{\r\n  \"type\": \"group_join\",\r\n  \"object\": {\r\n    \"user_id\": 321,\r\n    \"join_type\": \"join\"\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var groupId = 1234;

			var joinType = GroupJoinType.Join;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId,update.GroupJoin.UserId);
			Assert.AreEqual(joinType,update.GroupJoin.JoinType);
		}

		[Test]
		public void GroupLeaveTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"group_leave\",\r\n  \"object\": {\r\n    \"user_id\": 321,\r\n    \"self\": 0\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var groupId = 1234;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsFalse(update.GroupLeave.IsSelf);

		}

		[Test]
		public void GroupLeaveSelfTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"group_leave\",\r\n  \"object\": {\r\n    \"user_id\": 321,\r\n    \"self\": 1\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var groupId = 1234;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserId);
			Assert.AreEqual(userId, update.GroupLeave.UserId);
			Assert.IsTrue(update.GroupLeave.IsSelf);
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
		public void UserBlockTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"user_block\",\r\n  \"object\": {\r\n    \"admin_id\": 123,\r\n    \"user_id\": 321,\r\n    \"unblock_date\": 0,\r\n    \"reason\": 0,\r\n    \"comment\": \"test\"\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var groupId = 1234;
			var adminId = 123;
			var comment = "test";
			var reason = GroupUserBlockReason.Other;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId,update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.IsNull(update.UserBlock.UnblockDate);
		}

		[Test]
		public void UserBlockTemporaryTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"user_block\",\r\n  \"object\": {\r\n    \"admin_id\": 123,\r\n    \"user_id\": 321,\r\n    \"unblock_date\": 1533589200,\r\n    \"reason\": 4,\r\n    \"comment\": \"test\"\r\n  },\r\n  \"group_id\": 1234\r\n}";

			var userId = 321;
			var groupId = 1234;
			var adminId = 123;
			var comment = "test";
			var reason = GroupUserBlockReason.MessagesOffTopic;
			var unblockDate = new DateTime(2018,8,6,21,0,0);

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(adminId, update.UserId);
			Assert.AreEqual(userId, update.UserBlock.UserId);
			Assert.AreEqual(adminId,update.UserBlock.AdminId);
			Assert.AreEqual(comment, update.UserBlock.Comment);
			Assert.AreEqual(reason, update.UserBlock.Reason);
			Assert.AreEqual(unblockDate, update.UserBlock.UnblockDate);
		}

		[Test]
		public void UserUnblockTest()
		{
			var updateJson =
				"{\r\n  \"type\": \"user_unblock\",\r\n  \"object\": {\r\n    \"admin_id\": 123,\r\n    \"user_id\": 321,\r\n    \"by_end_date\": 0\r\n  },\r\n  \"group_id\": 1234\r\n}";


			var userId = 321;
			var groupId = 1234;
			var adminId = 123;

			var vkResponse = updateJson.GetVkResponse();

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
			var updateJson =
				"{\r\n  \"type\": \"user_unblock\",\r\n  \"object\": {\r\n    \"admin_id\": 123,\r\n    \"user_id\": 321,\r\n    \"by_end_date\": 1\r\n  },\r\n  \"group_id\": 1234\r\n}";


			var userId = 321;
			var groupId = 1234;
			var adminId = 123;

			var vkResponse = updateJson.GetVkResponse();

			var update = GroupUpdate.FromJson(vkResponse);

			Assert.AreEqual(groupId, update.GroupId);
			Assert.AreEqual(userId, update.UserUnblock.UserId);
			Assert.AreEqual(adminId, update.UserUnblock.AdminId);
			Assert.IsTrue(update.UserUnblock.ByEndDate);
		}
	}
}