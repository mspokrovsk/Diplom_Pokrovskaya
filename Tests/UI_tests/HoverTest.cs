using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;
using Diplom_Pokrovskaya.Steps;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class HoverTest : BaseTest
    {
        [Test]
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
   