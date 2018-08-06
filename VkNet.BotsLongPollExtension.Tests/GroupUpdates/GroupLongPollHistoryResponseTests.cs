using NUnit.Framework;
using VkNet.BotsLongPollExtension.Exception;
using VkNet.BotsLongPollExtension.Model;

namespace VkNet.BotsLongPollExtension.Tests.GroupUpdates
{
	[TestFixture]
	public class GroupLongPollHistoryResponseTests
	{
		[Test]
		public void Failed1Test()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryOutdateException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed1TsTest()
		{
			var updateJson = "{\"failed\":1, \"ts\":10}";

			var vkResponse = updateJson.GetVkResponse();

			var ts = 10;

			try
			{
				GroupsLongPollHistoryResponse.FromJson(vkResponse);
				Assert.Fail();
			}
			catch (BotsLongPollHistoryOutdateException exception)
			{
				Assert.AreEqual(ts, exception.Ts);
			}
		}

		[Test]
		public void Failed2Test()
		{
			var updateJson = "{\"failed\":2}";

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryKeyExpiredException>(
				() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}

		[Test]
		public void Failed3Test()
		{
			var updateJson = "{\"failed\":3}";

			var vkResponse = updateJson.GetVkResponse();

			Assert.Throws<BotsLongPollHistoryInfoLostException>(() => GroupsLongPollHistoryResponse.FromJson(vkResponse)
			);
		}
	}
}