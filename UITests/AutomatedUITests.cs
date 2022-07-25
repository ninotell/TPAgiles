using System;
using System.Threading;
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
                .GoToUrl("https://wordleagiles.azurewebsites.net/");

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");
            
            _driver.FindElement(By.Id("Play"))
                .Click();
        }

        [Fact]
        public void PlayTest()
        {

            _driver.Navigate()
                .GoToUrl("https://wordleagiles.azurewebsites.net/");

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            _driver.FindElement(By.Id("Play"))
                .Click();

            _driver.FindElement(By.Id("palabra-intentada"))
                .SendKeys("pato");

            _driver.FindElement(By.Id("intentar-button"))
                .Click();

            _driver.FindElement(By.Id("palabra-intentada"))
                .SendKeys("pato");

            _driver.FindElement(By.Id("intentar-button"))
                .Click();
            
            _driver.FindElement(By.Id("palabra-intentada"))
                .SendKeys("pato");

            _driver.FindElement(By.Id("intentar-button"))
                .Click();

            Thread.Sleep(2000);

        }


    }
}