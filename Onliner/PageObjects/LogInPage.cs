using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Onliner.PageObjects
{
   public class LogInPage
   {
       [FindsBy(How = How.XPath, Using = "//div[@class='auth-form__field']//input[@type='text']")]
       private IWebElement _userNameTextBox;

       [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")]
       private IWebElement _passwordTextBox;

       [FindsBy(How = How.XPath, Using = "//div[@class='auth-form']//button[@type='submit']")]
       [CacheLookup]
       private IWebElement _submitButton;

        public void LoginToPage()
        {
            _userNameTextBox.SendKeys(ConfigurationManager.AppSettings["EMAIL"]);
            _passwordTextBox.SendKeys(ConfigurationManager.AppSettings["PASSWORD"]);
            _submitButton.Submit();
        }
    }
}
