using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases
{
    public class LikesCount : BaseTest
    {
        [Test]
        public void TechLikesCount()
        {
            Pages.Home.ChoiceLastTechnicalNews();
            Pages.NewsItem.CheckLikesNumber();
        }
    }
}
