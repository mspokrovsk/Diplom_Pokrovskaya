using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;
using Diplom_Pokrovskaya.Steps;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class ValuesTest : BaseTest
    {
        [Test]
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
   