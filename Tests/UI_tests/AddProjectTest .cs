using OpenQA.Selenium;
using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Elements;
using Diplom_Pokrovskaya.Steps;
using Diplom_Pokrovskaya.Pages;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    public class AddProjectTest : BaseTest
    {
        [Test]
        public void TestAddProject()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);
            ProjectSteps projectSteps = new ProjectSteps(Driver);
            //Thread.Sleep(3000);
            projectsPage = projectSteps.AddProject("Test_Project");
            Assert.That(projectsPage.IsPageOpened());
            Assert.That(projectsPage.NameProject.Text.Trim(), Is.EqualTo("Test_Project"));
        }
    }
}
   