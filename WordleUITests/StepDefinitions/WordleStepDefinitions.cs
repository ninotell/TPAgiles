using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WordleUITests.StepDefinitions
{
    [Binding]
    public sealed class WordleStepDefinitions
    {
        private int time = 6000;
        IWebDriver _driver;
        String baseURL;

        [BeforeScenario]
        public void TestInitialize()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Drivers";
            //driver = new InternetExplorerDriver(path);
            _driver = new ChromeDriver(path);
            baseURL = "https://wordleagiles.azurewebsites.net/";
        }

        [Given("I have entered Juan as name")]
        public void GivenIHaveEnteredJuanAsName()
        {
            _driver.Navigate()
                .GoToUrl(baseURL);

            Thread.Sleep(time);

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            Thread.Sleep(1000);

        }

        [When("I click on button Jugar Ahora")]
        public void WhenIEnterJuanAsTheName()
        {
            _driver.FindElement(By.Id("Play"))
                .Click();

            Thread.Sleep(1000);
        }

        [Then("I should be told Bienvenido Juan")]
        public void ThenIShouldBeToldBienvenidoJUAN()
        {
            var bienvenida = _driver.FindElement(By.Id("nametag"));

            Assert.AreEqual("Bienvenido Juan!", _driver.FindElement(By.Id("nametag")).GetAttribute("innerHTML"));
            _driver.Quit();
        }

        [Given("I am logged as Juan")]
        public void GivenIAmLoggedAsJuan()
        {
            _driver.Navigate()
                .GoToUrl(baseURL);

            Thread.Sleep(time);

            _driver.FindElement(By.Id("Name"))
                .SendKeys("Juan");

            Thread.Sleep(1000);

            _driver.FindElement(By.Id("Play"))
                .Click();
        }

        [When("I enter MANO as the word to guess and click the button Intentar Palabra")]
        public void WhenIEnterMANOAsTheWordToGuessAndClickTheButtonIntentarPalabra()
        {
            var palabraIntentada = _driver.FindElement(By.Id("palabra-intentada"));
            var btnIntentar = _driver.FindElement(By.Id("intentar-button"));

            string palabra = "MANO";

            Thread.Sleep(time);

            palabraIntentada.SendKeys(palabra);
            Thread.Sleep(500);
            btnIntentar.Click();
        }


        [Then("I should see the word MANO in the words section")]
        public void ThenIShouldSeeTheWordMANOInTheWordsSection()
        {
            string palabra = "MANO";
            Thread.Sleep(1000);

            for (int i = 0; i < palabra.Length; i++)
            {
                string letra = _driver.FindElement(By.Id("0" + i)).GetAttribute("innerHTML");
                Assert.AreEqual(letra, Char.ToString(palabra[i]));
            }

            _driver.Quit();
        }


        [When("I enter MANO as the word to guess 4 times")]
        public void WhenIEnterMANOAsTheWordToGuess4Times()
        {
            var palabraIntentada = _driver.FindElement(By.Id("palabra-intentada"));
            var btnIntentar = _driver.FindElement(By.Id("intentar-button"));

            Thread.Sleep(time);

            string palabra = "MANO";

            ((IJavaScriptExecutor)_driver).ExecuteScript("document.getElementById('intentar-button').style.display='block';");

            for (int i = 0; i < 4; i++)
            {
                palabraIntentada.SendKeys(palabra);
                Thread.Sleep(500);
                btnIntentar.Click();
                Thread.Sleep(500);
            }

            Thread.Sleep(1000);
        }

        [Then("I should be told that I lost")]
        public void ThenIShouldBeToldThatILost()
        {
            var juegoGanado = _driver.FindElement(By.Id("juego-ganado"));
            Assert.AreEqual("false", juegoGanado.GetAttribute("value"));
            _driver.Quit();
        }

        [When("I enter the correct word")]
        public void WhenIEnterTheCorrectWord()
        {
            var palabraIntentada = _driver.FindElement(By.Id("palabra-intentada"));
            var btnIntentar = _driver.FindElement(By.Id("intentar-button"));
            var juegoGanado = _driver.FindElement(By.Id("juego-ganado"));

            string[] palabras = new string[] { "CASA", "PATO", "LORO", "AUTO" };

            ((IJavaScriptExecutor)_driver).ExecuteScript("document.getElementById('intentar-button').style.display='block';");


            foreach (var palabra in palabras)
            {
                palabraIntentada.SendKeys(palabra);
                Thread.Sleep(500);
                btnIntentar.Click();
                Thread.Sleep(500);
                if (juegoGanado.GetAttribute("value") == "true")
                {
                    break;
                }
            }
            Thread.Sleep(time);
        }

        [Then("I should be told that I won")]
        public void ThenIShouldBeToldThatIWon()
        {
            var juegoGanado = _driver.FindElement(By.Id("juego-ganado"));
            Assert.AreEqual("true", juegoGanado.GetAttribute("value"));
            _driver.Quit();
        }
    }
}