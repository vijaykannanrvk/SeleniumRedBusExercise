using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace SeleniumRedBusExercise
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions chrome_options = new ChromeOptions();
            chrome_options.AddArgument("--disable-notifications");
            ChromeDriver driver = new ChromeDriver(chrome_options);
            driver.Url = "https://www.redbus.in/";
            driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//label[text()='From']/..//input")).SendKeys("Madurai");
            driver.FindElement(By.XPath("//label[text()='To']/..//input")).SendKeys("Chennai");
            driver.FindElement(By.XPath("//div/span[text()='Date']")).Click();
            driver.FindElement(By.XPath("//div/span[contains(@class,'CalendarDaysSpan') and text()='12']")).Click();
            Thread.Sleep(2000);
            IWebElement element=driver.FindElement(By.Id("search_button"));
            element.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Build().Perform();
            driver.FindElement(By.XPath("//label[contains(@for,'SLEEPER')]")).Click();
            driver.FindElement(By.XPath("//a[text()='Departure']")).Click();
            driver.FindElement(By.XPath("//div[text()='View Seats']")).Click();
        }
    }
}
