using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public void FactoryDriverTest()
        {
            Driver = new Browser().Driver;

            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}