using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace Onliner.WrapperFactory
{
    public static class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException(
                        "The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set { driver = value; }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }

                    break;

                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                    }

                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(@"C:\PathTo\CHDriverServer");
                        Drivers.Add("Chrome", Driver);
                    }

                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void OpenFullScreen()
        {
            Driver.Manage().Window.Maximize();
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds = 30)
        {
            var wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            wait.Until(d => d.FindElement(by).Displayed && d.FindElement(by).Enabled);
            return driver.FindElement(by);
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
