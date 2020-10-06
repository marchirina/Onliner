using System;
using System.Configuration;
using NUnit.Framework;
using Onliner.WrapperFactory;

namespace Onliner.TestCases
{
   public class BaseTest
    {
        [SetUp]
        public void SetUpTest()
        {

            BrowserFactory.InitBrowser("Firefox");
            BrowserFactory.OpenFullScreen();
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);
            BrowserFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        }

        [TearDown]
        public void TearDownTest()
        {
            BrowserFactory.CloseAllDrivers();
        }
    }
}
