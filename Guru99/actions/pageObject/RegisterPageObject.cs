using Hybrid_Framework.actions.commons;
using Hybrid_Framework.interfaces.pageUIs;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid_Framework.actions.pageObject
{
    public class RegisterPageObject : BasePage
    {
        private IWebDriver driver = null;
      
        public RegisterPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePageObject ClickToRegisterButton()
        {
            WaitForElementClickable(driver, RegisterPageUI.REGISTER_BUTTON);
            ClickToElement(driver, RegisterPageUI.REGISTER_BUTTON);
            return new HomePageObject(driver);
        }

        public String GetErrorMessageAtFirstnameTextbox()
        {
            WaitForElementVisible(driver, RegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
        }

        public String GetErrorMessageAtLastnameTextbox()
        {
            WaitForElementVisible(driver, RegisterPageUI.LAST_NAME_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.LAST_NAME_ERROR_MESSAGE);
        }

        public String GetErrorMessageAtEmailTextbox()
        {
            WaitForElementVisible(driver, RegisterPageUI.EMAIL_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.EMAIL_ERROR_MESSAGE);
        }

        public String GetErrorMessageAtPasswordTextbox()
        {
            WaitForElementVisible(driver, RegisterPageUI.PASSWORD_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.PASSWORD_ERROR_MESSAGE);
        }

        public String GetErrorMessageAtConfirmPasswordTextbox()
        {
            WaitForElementVisible(driver, RegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
        }

        public void InputToFirstnameTextbox(String firstName)
        {
            WaitForElementVisible(driver, RegisterPageUI.FIRST_NAME_TEXTBOX);
            SendkeyToElement(driver, RegisterPageUI.FIRST_NAME_TEXTBOX, firstName);
        }

        public void InputToLastnameTextbox(String lastName)
        {
            WaitForElementVisible(driver, RegisterPageUI.LAST_NAME_TEXTBOX);
            SendkeyToElement(driver, RegisterPageUI.LAST_NAME_TEXTBOX, lastName);

        }

        public void InputToEmailTextbox(String email)
        {
            WaitForElementVisible(driver, RegisterPageUI.EMAIL_TEXTBOX);
            SendkeyToElement(driver, RegisterPageUI.EMAIL_TEXTBOX, email);

        }

        public void InputToPasswordTextbox(String password)
        {
            WaitForElementVisible(driver, RegisterPageUI.PASSWORD_TEXTBOX);
            SendkeyToElement(driver, RegisterPageUI.PASSWORD_TEXTBOX, password);

        }

        public void InputToConfirmPasswordTextbox(String confirmPassword)
        {
            WaitForElementVisible(driver, RegisterPageUI.CONFIRM_PASSWORD_TEXTBOX);
            SendkeyToElement(driver, RegisterPageUI.CONFIRM_PASSWORD_TEXTBOX, confirmPassword);

        }

        public String GetRegisterSuccessMessage()
        {
            WaitForElementVisible(driver, RegisterPageUI.REGISTER_SUCCESS_MESSAGE);
            return GetElementText(driver, RegisterPageUI.REGISTER_SUCCESS_MESSAGE);
        }

        public HomePageObject ClickToLogoutLink()
        {
            WaitForElementVisible(driver, RegisterPageUI.LOGOUT_LINK);
            ClickToElement(driver, RegisterPageUI.LOGOUT_LINK);
            return new HomePageObject(driver);
        }

        public String GetErrorExistingEmailMessage()
        {
            WaitForElementVisible(driver, RegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE);
            return GetElementText(driver, RegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE);
        }

    }
}
