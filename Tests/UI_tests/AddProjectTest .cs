using OpenQA.Selenium;
using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Elements;
using Diplom_Pokrovskaya.Steps;
using Diplom_Pokrovskaya.Pages;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature", "AddProject feature")]
    public class AddProjectTest : BaseTest
    {
        [Test(Description = "ѕроверка успешного создани€ проекта")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story1")]
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
   