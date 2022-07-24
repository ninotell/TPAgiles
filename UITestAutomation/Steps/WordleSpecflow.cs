using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace Wordle.UITestAutomation
{
    [Binding]
    public class WordleSpecflow
    {
        IWebDriver? driver;
        string? baseURL;
        JuegoWordle? juego;

        [BeforeScenario]
        public void TestInitialize()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers";
            //driver = new InternetExplorerDriver(path);
            driver = new ChromeDriver(path);
            baseURL = "http://localhost:39278/";
        }

        [Given(@"La palabra del Wordle es 'perro'")]
        public void GivenTheWordleWordIsPerro()
        {
            juego = new JuegoWordle("Juan", 5, 2);
            juego.palabra = "perro";
            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(5000);

            //var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            //txtPalabra.SendKeys("Ahorcado");

            //Thread.Sleep(1000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
        }

        [When(@"Ingreso 5 veces la palabra 'carro'")]
        public void WhenIEnterCarroAsTheWordFiveTimes()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            for (int i = 0; i < 7; i++)
            {
                letterTyped.SendKeys("X");
                Thread.Sleep(1000);
                btnInsertLetter.SendKeys(Keys.Enter);
            }
        }

        [Then(@"Debería perder la partida")]
        public void ThenIShouldBeToldThatILost()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Thread.Sleep(1000);
            Assert.IsTrue(loss);
            Thread.Sleep(1000);
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
