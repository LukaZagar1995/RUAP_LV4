using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace RUAP_LV4_Test_11
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            for (int i = 0; i < 20; i++)
            {
                driver.Navigate().GoToUrl("https://demo.opencart.com/");
                driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                driver.FindElement(By.LinkText("Login")).Click();
                driver.FindElement(By.Id("input-email")).Click();
                if(i == 0)
                    driver.FindElement(By.Id("input-email")).SendKeys("tatu@majstor.com");
                else
                    driver.FindElement(By.Id("input-email")).SendKeys("tatu" + i + "@majstor.com");
                driver.FindElement(By.Id("input-password")).SendKeys("1234");
                driver.FindElement(By.XPath("//input[@value='Login']")).Click();
                if ( i == 0)
                {
                    driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                    driver.FindElement(By.LinkText("Logout")).Click();
                }
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
