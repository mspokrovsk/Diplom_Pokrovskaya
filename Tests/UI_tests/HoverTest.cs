using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using OpenQA.Selenium.Interactions;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class HoverTest : BaseTest
    {
        [Test]
        public void HoverTests()
        {
            LoginPage loginPage = new LoginPage(Driver);
            ProjectsPage projectsPage = loginPage.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            projectsPage.HoverOverHoverElement();
            string tooltipText = Driver.FindElement(By.CssSelector("[data-content='mspokrovsk']")).Text;
            Assert.That(projectsPage.IsTooltipTextCorrect(tooltipText, "mspokrovsk"));
        }
    }
}
   