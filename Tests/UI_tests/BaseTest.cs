using Allure.Net.Commons;
using NUnit.Allure.Core;
using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers;
using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Steps;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;
using System.Text;



namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [Parallelizable(scope: ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        protected WaitsHelper WaitsHelper { get; private set; }
        protected UserSteps UserSteps;
        protected AllureSteps AllureSteps;

        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void FactoryDriverTest()
        {
            Driver = new Browser().Driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
            AllureSteps = new AllureSteps(Driver);
            UserSteps = new UserSteps(Driver);

            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
                //AllureApi.AddAttachment("data.txt", "text/plain", Encoding.UTF8.GetBytes("This os the file content."));

            }
            Driver.Quit();
        }
    }
}