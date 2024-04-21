using Diplom_Pokrovskaya.Helpers.Configuration;
using Diplom_Pokrovskaya.Helpers;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace Diplom_Pokrovskaya.Pages
{
    public abstract class PageBase
    {
        protected IWebDriver Driver { get; private set; }
        protected WaitsHelper WaitsHelper { get; private set; }

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        }

        public PageBase(IWebDriver driver, bool openPageByUrl) : this(driver)
        {
            if (openPageByUrl)
            {
                OpenPageByURL();
            }
        }

        protected abstract string GetEndpoint();

        public abstract bool IsPageOpened();

        [AllureStep("Открыта страница")]
        protected void OpenPageByURL()
        {
            Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
        }
    }
}
