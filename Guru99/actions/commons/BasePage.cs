using Hybrid_Framework.actions.commons;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Hybrid_Framework.actions.commons
{
    public class BasePage
    {
        public static BasePage GetBasePageObject()
        {
            return new BasePage();
        }

        public void OpenPageUrl(IWebDriver driver, String Url)
        {
           driver.Url = Url;
        }

        public String GetPageTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        public String GetPageSource(IWebDriver driver)
        {
            return driver.PageSource;
        }

        public void BackToPage(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public void ForwardToPage(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        public void RefreshCurrentPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public IAlert WaitForAlertPresence(IWebDriver driver)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            return explicitWait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = WaitForAlertPresence(driver);
            alert.Accept();
        }

        public void CancelAlert(IWebDriver driver)
        {
            IAlert alert = WaitForAlertPresence(driver);
            alert.Dismiss();
        }

        public String GetAlertText(IWebDriver driver)
        {
            IAlert alert = WaitForAlertPresence(driver);
            return alert.Text;
        }

        public void SendkeyToAlert(IWebDriver driver, String textVale)
        {
            IAlert alert = WaitForAlertPresence(driver);
            alert.SendKeys(textVale);
        }

        public void SwichToWindowByID(IWebDriver driver, String windowID)
        {
            ReadOnlyCollection<String> allWindowIDs = driver.WindowHandles;

            foreach (String id in allWindowIDs)
            {
                if (!id.Equals(windowID))
                {
                    driver.SwitchTo().Window(id);
                    break;
                }
            }
        }

        public void SwichToWindowByTitle(IWebDriver driver, String tabTitle)
        {
            ReadOnlyCollection<String> allWindowIDs = driver.WindowHandles;

            foreach (String id in allWindowIDs)
            {
                driver.SwitchTo().Window(id);
                String actualTitle = driver. Title;
                if (actualTitle.Equals(tabTitle))
                {
                    break;
                }
            }
        }

        public void CloseAllTabWithoutParent(IWebDriver driver, String parentID)
        {
            ReadOnlyCollection<String> allWindowIDs = driver.WindowHandles;

            foreach (String id in allWindowIDs)
            {
                if (!id.Equals(parentID))
                {
                    driver.SwitchTo().Window(parentID);
                    driver.Close();
                }
                driver.SwitchTo().Window(parentID);
            }
        }

        public void WaitForElementVisibleCssSelector(IWebDriver driver, String cssLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssLocator)));
        }

        private By GetByXpath(String xpathLocator)
        {
            return By.XPath(xpathLocator);
        }

        private String GetDynamicXpath(String xpathLocator, String? dynamicValues)
        {
            xpathLocator = String.Format(xpathLocator, dynamicValues);
            return xpathLocator;
        }

        protected IWebElement GetWebElement(IWebDriver driver, String xpathLocator)
        {
            return driver.FindElement(GetByXpath(xpathLocator));
        }

        public ReadOnlyCollection<IWebElement> GetListWebElement(IWebDriver driver, String xpathLocator)
        {
            return driver.FindElements(GetByXpath(xpathLocator));
        }

        public void ClickToElement(IWebDriver driver, String xpathLocator)
        {
            GetWebElement(driver, xpathLocator).Click();
        }

        public void ClickToElement(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)).Click();
        }

        public void SendkeyToElement(IWebDriver driver, String xpathLocator, String textValue)
        {
            IWebElement element = GetWebElement(driver, xpathLocator);
            element.Clear();
            element.SendKeys(textValue);
        }

        public void SendkeyToElement(IWebDriver driver, String xpathLocator, String textValue, String? dynamicValues)
        {
            IWebElement element = GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues));
            element.Clear();
            element.SendKeys(textValue);
        }

        public void SelectItemInDefaultDropdown(IWebDriver driver, String xpathLocator, String textItem)
        {
            SelectElement select = new SelectElement(GetWebElement(driver, xpathLocator));
            select.SelectByText(textItem);
        }

        public void SelectItemInDefaultDropdown(IWebDriver driver, String xpathLocator, String textItem, String? dynamicValues)
        {
            SelectElement select = new SelectElement(GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)));
            select.SelectByText(textItem);
        }

        public Boolean IsDropdownMultiple(IWebDriver driver, String xpathLocator)
        {
            SelectElement select = new SelectElement(GetWebElement(driver, xpathLocator));
            return select.IsMultiple;
        }

        public void SelectItemInCustomDropdown(IWebDriver driver, String parentXpath, String childXpath, String expectedTextItem)
        {
            GetWebElement(driver, parentXpath).Click();
            SleepInSecond(1);

            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));

            ReadOnlyCollection<IWebElement> allItems = explicitWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetByXpath(childXpath)));
            foreach (IWebElement item in allItems)
            {
                if (item.Text.Trim().Equals(expectedTextItem))
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", item);
                    SleepInSecond(1);
                    item.Click();
                    break;
                }
            }
        }

        public void SleepInSecond(long second)
        {
            Thread.Sleep(TimeSpan.FromSeconds(second));
        }

        public String GetElementAttribute(IWebDriver driver, String xpathLocator, String AttributeName)
        {
            return GetWebElement(driver, xpathLocator).GetAttribute(AttributeName);
        }

        public String GetElementAttribute(IWebDriver driver, String xpathLocator, String AttributeName, String? dynamicValues)
        {
            return GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)).GetAttribute(AttributeName);
        }

        public String GetElementText(IWebDriver driver, String xpathLocator)
        {
            return GetWebElement(driver, xpathLocator).Text;
        }

        public String GetElementText(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            return GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)).Text;
        }

        public String GetCssValue(IWebDriver driver, String xpathLocator, String PropertyName)
        {
            return GetWebElement(driver, xpathLocator).GetCssValue(PropertyName);
        }

        public int GetElementSize(IWebDriver driver, String xpathLocator)
        {
            return GetListWebElement(driver, xpathLocator).Count;
        }

        public int GetElementSize(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            return GetListWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)).Count;
        }

        public void CheckToDefaultCheckboxOrRadio(IWebDriver driver, String xpathLocator)
        {
            IWebElement element = GetWebElement(driver, xpathLocator);
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void CheckToDefaultCheckboxOrRadio(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            IWebElement element = GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues));
            if (!element. Selected)
            {
                element.Click();
            }
        }

        public void UncheckToDefaultCheckbox(IWebDriver driver, String xpathLocator)
        {
            IWebElement element = GetWebElement(driver, xpathLocator);
            if (element.Selected)
            {
                element.Click();
            }
        }

        public void UncheckToDefaultCheckbox(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            IWebElement element = GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues));
            if (element.Selected)
            {
                element.Click();
            }
        }

        public Boolean IsElementDisplayed(IWebDriver driver, String xpathLocator)
        {
            return GetWebElement(driver, xpathLocator).Displayed;
        }

        public Boolean IsElementDisplayed(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            return GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)).Displayed;
        }

        public void OverrideImplicitTimeout(IWebDriver driver, long timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public Boolean IsElementUndisplayed(IWebDriver driver, String xpathLocator)
        {
            OverrideImplicitTimeout(driver, GlobalConstants.SHORT_TIMEOUT);
            ReadOnlyCollection<IWebElement> elements = GetListWebElement(driver, xpathLocator);
            OverrideImplicitTimeout(driver, GlobalConstants.LONG_TIMEOUT);
            if (elements.Count == 0)
            {
                return true;
            }
            else if (elements.Count > 0 && !elements.First().Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsElementUndisplayed(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            OverrideImplicitTimeout(driver, GlobalConstants.SHORT_TIMEOUT);
            ReadOnlyCollection<IWebElement> elements = GetListWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues));
            OverrideImplicitTimeout(driver, GlobalConstants.LONG_TIMEOUT);
            if (elements.Count == 0)
            {
                return true;
            }
            else if (elements.Count > 0 && !elements.First().Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsElementEnabled(IWebDriver driver, String xpathLocator)
        {
            return GetWebElement(driver, xpathLocator).Enabled;
        }

        public Boolean IsElementSelected(IWebDriver driver, String xpathLocator)
        {
            return GetWebElement(driver, xpathLocator).Selected;
        }

        public void SwitchToFrameIframe(IWebDriver driver, String xpathLocator)
        {
            driver.SwitchTo().Frame(GetWebElement(driver, xpathLocator));
        }

        public void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public void HoverMouseToElement(IWebDriver driver, String xpathLocator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(GetWebElement(driver, xpathLocator)).Perform();
        }

        public void PressKeyToElement(IWebDriver driver, String xpathLocator, String key)
        {
            Actions action = new Actions(driver);
            action.SendKeys(GetWebElement(driver, xpathLocator), key).Perform();
        }

        public void PressKeyToElement(IWebDriver driver, String xpathLocator, String key, String? dynamicValues)
        {
            Actions action = new Actions(driver);
            action.SendKeys(GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)), key).Perform();
        }

        public void ScrollToBottomPage(IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        }

        public void HightlightElement(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IWebElement element = GetWebElement(driver, xpathLocator);
            String hightlightStyle = "border: 2px solid red; border-style:dashed";
            String originalStyle = element.GetAttribute("style");
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", element, hightlightStyle);
            SleepInSecond(1);
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", element, originalStyle);
        }

        public void HightlightElement(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IWebElement element = GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues));
            String hightlightStyle = "border: 2px solid red; border-style:dashed";
            String originalStyle = element.GetAttribute("style");
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", element, "style", hightlightStyle);
            SleepInSecond(1);
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", element, "style", originalStyle);
        }

        public void ClickToElementByJS(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", GetWebElement(driver, xpathLocator));
        }

        public void ScrollToElement(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetWebElement(driver, xpathLocator));
        }

        public String GetElementValueByJS(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return (String)jsExecutor.ExecuteScript("return $(document.evaluate(\"" + xpathLocator + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue).val()");
        }

        public void RemoveAttributeInDOM(IWebDriver driver, String xpathLocator, String AttributeRemove)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].removeAttribute('" + AttributeRemove + "');", GetWebElement(driver, xpathLocator));
        }

        public String GetElementValidationMessage(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return (String)jsExecutor.ExecuteScript("arguments[0].validationMessage;", GetWebElement(driver, xpathLocator));
        }

        public Boolean IsImageLoaded(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            Boolean status = (Boolean)jsExecutor.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", GetWebElement(driver, xpathLocator));
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsImageLoaded(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            Boolean status = (Boolean)jsExecutor.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", GetWebElement(driver, GetDynamicXpath(xpathLocator, dynamicValues)));
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WaitForElementVisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(GetByXpath(xpathLocator)));
        }

        public void WaitForElementVisible(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(GetByXpath(GetDynamicXpath(xpathLocator, dynamicValues))));
        }

        public void WaitForAllElementVisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetByXpath(xpathLocator)));
        }

        public void WaitForAllElementVisible(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetByXpath(GetDynamicXpath(xpathLocator, dynamicValues))));
        }

        public void WaitForElementInvisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(GetByXpath(xpathLocator)));
        }

        public void WaitForElementInvisible(IWebDriver driver, String xpathLocator, String? dynamicValues)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(GetByXpath(GetDynamicXpath(xpathLocator, dynamicValues))));
        }

        public void WaitForElementUndisplyed(IWebDriver driver, String xpathLocator)
        {
            //Wait for element un-displayed in DOM or not in DOM and override implicit timeout
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.SHORT_TIMEOUT));
            OverrideImplicitTimeout(driver, GlobalConstants.SHORT_TIMEOUT);
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(GetByXpath(xpathLocator)));
            OverrideImplicitTimeout(driver, GlobalConstants.LONG_TIMEOUT);
        }

        public void WaitForElementClickable(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetByXpath(xpathLocator)));
        }

        public void waitForElementClickable(WebDriver driver, String xpathLocator, String? dynamicValues)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalConstants.LONG_TIMEOUT));
            explicitWait.Until(ExpectedConditions.ElementToBeClickable(GetByXpath(GetDynamicXpath(xpathLocator, dynamicValues))));
        }

        public int GetRandomNumber()
        {
            Random Rand = new Random();
            return Rand.Next(9999);
        }

    }
}
