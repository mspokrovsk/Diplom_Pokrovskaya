using Diplom_Pokrovskaya.Core;
using Diplom_Pokrovskaya.Helpers.Configuration;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithStandardUser()
        {
            LoginPage loginPage = new LoginPage(Driver);
            ProductsPage productsPage = loginPage.SuccessfulLogin(Configurator.AppSettings.Username, Configurator.AppSettings.Password);

            Assert.That(productsPage.IsPageOpened);
        }
    }
   