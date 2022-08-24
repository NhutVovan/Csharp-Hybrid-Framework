using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Hybrid_Framework.actions.commons
{
    public class BaseTest
    {
        private IWebDriver driverBaseTest = null;
        protected IWebDriver GetBrowserDriver(String browserName)
        {
                       
            if (browserName.Equals("firefox"))
            {
                driverBaseTest = new FirefoxDriver(GlobalConstants.PROJECT_PATH + "\\browserDrivers");
            }
            else if (browserName.Equals("chrome"))
            {
                driverBaseTest = new ChromeDriver(GlobalConstants.PROJECT_PATH + "\\browserDrivers");
            }
            else if (browserName.Equals("edge"))
            {
                //
            }
            else if (browserName.Equals("opera"))
            {
                //
            }
            else if (browserName.Equals("ie"))
            {
                //
            }
            else
            {
                throw new Exception ("Browser name invalid.");
            }

            driverBaseTest.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driverBaseTest.Manage().Window.Maximize();

            return driverBaseTest;
        }


        public static int GetRandomNumber()
        {
            Random Rand = new Random();
            return Rand.Next(9999);

        }
    }
}
