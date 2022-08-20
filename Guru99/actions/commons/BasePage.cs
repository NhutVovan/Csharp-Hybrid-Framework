using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HybridFramework.actions.commons
{
    internal class BasePage
    {
        public static BasePage getBasePageObject()
        {
            return new BasePage();
        }

        public void openPageUrl(WebDriver driver, String Url)
        {
           driver.Url = Url;
        }

        public String getPageTitle(WebDriver driver)
        {
            return driver.Title;
        }

        public String getPageSource(WebDriver driver)
        {
            return driver.PageSource;
        }

        public void backToPage(WebDriver driver)
        {
            driver.Navigate().Back();
        }

        public void forwardToPage(WebDriver driver)
        {
            driver.Navigate().Forward();
        }





        private By getByXpath(String xpathLocator)
        {

            return By.XPath(xpathLocator);
        }

        public void waitForElementVisible(WebDriver driver, String cssLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var element = explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssLocator)));
        }

    }
}
