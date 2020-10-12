using System;
using System.Collections.Generic;
using Onliner.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Onliner.PageObjects
{
    public class ComparePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Очистить сравнение')]")]
        private IWebElement _clearCompareButton;

        public int CountNumberOfBestSpec(string locator)
        {
            List<String> itemsForCompare = new List<String>();
            var titleElements = BrowserFactory.Driver.FindElements(By.XPath(locator));

            foreach (IWebElement webElement in titleElements)
            {
                itemsForCompare.Add(webElement.Text);
            }

            return itemsForCompare.Count;
        }

        public bool IsFirstPhoneBetter()
        {
            var firstPhoneSpec = CountNumberOfBestSpec("//td[3][contains (@class,'cell_accent')]");
            var secondPhoneSpec = CountNumberOfBestSpec("//td[4][contains (@class,'cell_accent')]");
            return firstPhoneSpec > secondPhoneSpec;
        }

        public void ClearComparePage()
        {
            _clearCompareButton.Click();
        }
    }
}