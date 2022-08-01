using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Threading;
using Xunit;

namespace UITests
{
    [TechTalk.SpecFlow.Binding]
    public class WordleSpecflow : IDisposable
    {

        public IWebDriver _driver;
        //String path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
        public String baseURL = "https://localhost:8080/";
        public WordleSpecflow() => _driver = new ChromeDriver();

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }


        [Fact]
        public void GivenIHaveEnteredJuanAsName()
        {
            _driver.Navigate()
                .GoToUrl(baseURL);

            Thread.Sleep(5000);

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("Play"))
                .Click();
        }

        [Fact]
        public void WhenIEnterJuanAsThePalabraIntentadaThreeTimes()
        {

            _driver.Navigate()
                .GoToUrl(baseURL);

            Thread.Sleep(5000);

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("Play"))
                .Click();

            var palabraIntentada = _driver.FindElement(By.Id("palabra-intentada"));
            var btnIntentar = _driver.FindElement(By.Id("intentar-button"));

            for (int i = 0; i < 3; i++)
            {
                palabraIntentada.SendKeys("juan");                
                btnIntentar.Click();
                Thread.Sleep(1000);
            }


        }
        [Fact]
        public void WinGame()
        {
            _driver.Navigate()
                .GoToUrl(baseURL);

            Thread.Sleep(5000);

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("Play"))
                .Click();

            var palabraIntentada = _driver.FindElement(By.Id("palabra-intentada"));
            var btnIntentar = _driver.FindElement(By.Id("intentar-button"));
            var juegoGanado = _driver.FindElement(By.Id("juego-ganado"));

            string[] palabras = new string[] { "CASA", "PATO", "LORO", "AUTO" };

            foreach (var palabra in palabras)
            {
                palabraIntentada.SendKeys(palabra);
                btnIntentar.Click();
                if (juegoGanado.GetAttribute("value") == "true") { Thread.Sleep(1000); break; }
                Thread.Sleep(1000);
            }

        }




    }
}