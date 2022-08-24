using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid_Framework.interfaces.pageUIs
{
    public class RegisterPageUI
    {
        public static  String FIRST_NAME_TEXTBOX = "//input[@id='FirstName']";
		public static  String LAST_NAME_TEXTBOX = "//input[@id='LastName']";
		public static  String EMAIL_TEXTBOX = "//input[@id='Email']";
		public static  String PASSWORD_TEXTBOX = "//input[@id='Password']";
		public static  String CONFIRM_PASSWORD_TEXTBOX = "//input[@id='ConfirmPassword']";
	
		public static  String REGISTER_BUTTON = "//button[@id='register-button']";
		
		public static  String FIRST_NAME_ERROR_MESSAGE = "//span[@id='FirstName-error']";
		public static  String LAST_NAME_ERROR_MESSAGE = "//span[@id='LastName-error']";
		public static  String EMAIL_ERROR_MESSAGE = "//span[@id='Email-error']";
		public static  String PASSWORD_ERROR_MESSAGE = "//span[@id='Password-error']";
		public static  String CONFIRM_PASSWORD_ERROR_MESSAGE = "//span[@id='ConfirmPassword-error']";
	
		public static  String REGISTER_SUCCESS_MESSAGE = "//div[@class='result']";
		public static  String LOGOUT_LINK = "//a[@class='ico-logout']";
		public static  String EXISTING_EMAIL_ERROR_MESSAGE = "//div[contains(@class,'message-error')]//li";
	
    }
}
