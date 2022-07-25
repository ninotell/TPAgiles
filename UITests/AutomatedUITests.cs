using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace UITests
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests() => _driver = new ChromeDriver();
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void LogInTest()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44321/Home/Index");
            
            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");
            
            _driver.FindElement(By.Id("Play"))
                .Click();

            Assert.Equal("Wordle", _driver.Title);
        }
    }
}