using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases.Authorization
{
    public class SignIn : BaseTest
    {
        [Test]
        public void VerifySignInSuccessful()
        {
            Assert.IsTrue(Pages.Main.IsChatItemDisplayed());
        }
    }
}
