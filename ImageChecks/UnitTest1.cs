using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;

namespace ImageChecks
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }


        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys("an image" + Keys.Enter);
            driver.FindElement(By.XPath("//a[@data-hveid='CAEQAw']")).Click();
            var images = driver.FindElements(By.XPath("//img[@class='rg_i Q4LuWd']"));

            foreach (var image in images)
            {
               Assert.IsNotNull(image.GetAttribute("src"));
            }
                       
        }

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
