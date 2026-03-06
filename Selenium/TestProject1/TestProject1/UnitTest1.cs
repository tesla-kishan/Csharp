using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void OpenGoogleTest()
        {
            ChromeOptions options = new ChromeOptions();

            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://www.google.com");

            Assert.That(driver.Title.Contains("Google"), Is.True);

            driver.Quit();
        }
    }
}