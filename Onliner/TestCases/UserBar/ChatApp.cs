using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases.UserBar
{
    public class ChatApp : BaseTest
    {
        [Test]
        public void SendMessage()
        {
            Pages.Main.OpenChatAppPage("Aleksey_cosmos");
            Pages.Chat.SendMessage("What's up?");
            Assert.AreEqual("What's up?", Pages.Chat.CompareTxtMessage());
            Assert.IsTrue(Pages.Chat.IsStatusMessageSentDisplayed());
        }

        [TearDown]
        public void DeleteMessage()
        {
            Pages.Chat.DeleteChatMessage();
        }
    }
}
