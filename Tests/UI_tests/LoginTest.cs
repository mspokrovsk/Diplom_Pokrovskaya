using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;
using Diplom_Pokrovskaya.Pages;
using Diplom_Pokrovskaya.Steps;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [AllureEpic("Web Interface")]
    [AllureFeature("Login feature")]

    public class LoginTest : BaseTest
    {
        [Test(Description = "�������� �������� �� ������� �������� ����� ������ � ����������� �������")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story1")]
        public void LoginWithStandardUser()
        {
            UserSteps userSteps = new UserSteps(Driver);
            ProjectsPage projectsPage = userSteps.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(projectsPage.IsPageOpened);
        }

        [Test(Description = "�������� ����������� ������ These credentials do not match our records or the user account is not allowed to log in. ����� ������ � ������������ email")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("Story1")]
        public void LoginWithErrorUsername()
        {
            Assert.That(
            new UserSteps(Driver)
            .IncorrectLogin("mspokrovsk@mts", Configurator.AppSettings.Password)
            .GetErrorLabelText(),
            Is.EqualTo("These credentials do not match our records or the user account is not allowed to log in."));
        }
    }
}
   