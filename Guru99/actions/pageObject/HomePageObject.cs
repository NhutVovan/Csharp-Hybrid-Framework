using Hybrid_Framework.actions.commons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hybrid_Framework.interfaces.pageUIs;

namespace Hybrid_Framework.actions.pageObject
{
    public class HomePageObject : BasePage
    {
        IWebDriver driver = null;
        
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public RegisterPageObject ClickToRegisterLink()
        {
            WaitForElementClickable(driver, HomePageUI.REGISTER_LINK);
            ClickToElement(driver, HomePageUI.REGISTER_LINK);
            return new RegisterPageObject(driver);
        }

        public Boolean IsMyAccountLinkDisplayed()
        {
            WaitForElementClickable(driver, HomePageUI.MY_ACCOUNT_LINK);
            return IsElementDisplayed(driver, HomePageUI.MY_ACCOUNT_LINK);
        }

        

    }
}
