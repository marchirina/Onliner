using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases
{
    public class SingIn : BaseTest
    {
        [Test]
        public void CheckChatItem()
        {
            Pages.Main.IsVisibleChatItem();
        }
    }
}
