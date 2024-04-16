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
    [AllureFeature("Login feature")]

    public class HoverTest : BaseTest
    {
        [Test(Description = "Проверка на скриншот")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("mspokrovsk")]
        [AllureIssue("TMS-123")]
        [AllureTms("Req-456")]
        [AllureLink("github", "https://github.com/mspokrovsk/Diplom_Pokrovskaya/blob/develop/Tests/UI_tests/HoverTest.cs")]
        [AllureStory("Story3")]
        public void HoverTests()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.HoverOverHoverElement();
            string tooltipText = Driver.FindElement(By.CssSelector("[data-content='mspokrovsk']")).Text;
            Assert.That(projectsPage.IsTooltipTextCorrect(tooltipText, "mspokrovsk"));
        }
    }
}
   