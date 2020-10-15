using System;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class NewsItemPage
   {
       [FindsBy(How = How.XPath, Using = "//div[@data-reaction='slight_smile']//span[@class='st-count']")]
       private IWebElement _slightSmileButton;

       [FindsBy(How = How.XPath, Using = "//div[contains(@class,'sharethis')]")]
       private IWebElement _shareThisBlock;

       public void CheckLikesCount()
       {
           Actions actions = new Actions(BrowserFactory.Driver);
           actions.MoveToElement(_shareThisBlock).Build().Perform();
           var countLike = _slightSmileButton.Text;
           Console.WriteLine("Number of people who liked news are " + countLike);
       }
    }
}
