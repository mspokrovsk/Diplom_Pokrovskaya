using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;
using Diplom_Pokrovskaya.Steps;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature", "AddProject feature")]
    public class ValuesTest : BaseTest
    {
        [Test(Description = "Проверка на граничные значения")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story5")]
        public void ExceedingPermissibleValuesTest()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.ClickAddToProject();
            projectsPage.AddRandomLetters();
            string summaryValue = Driver.FindElement(By.CssSelector("[data-target=\"note behavior--maxlength-counter.control\"]")).GetAttribute("value");
            int summaryLength = summaryValue.Length;
            Assert.That(summaryLength, Is.EqualTo(80));
        }
    }
}
   