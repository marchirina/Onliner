using NUnit.Framework;
using Onliner.PageObjects;

namespace Onliner.TestCases.News
{
    public class LikesCount : BaseTest
    {
        [Test]
        public void CheckLikesCountForTechNews()
        {
            Pages.Main.SelectLatestTechnicalNews();
            Pages.NewsItem.CheckLikesCount();
        }
    }
}
