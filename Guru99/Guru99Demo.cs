using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework
{
    internal class Guru99Demo
    {
        IWebDriver driver = null;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\vovan\\source\\repos\\Guru99\\browserDrivers");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.google.com";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }

    
}
