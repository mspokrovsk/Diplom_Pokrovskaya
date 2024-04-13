using OpenQA.Selenium;
using Diplom_Pokrovskaya.Helpers.Configuration;

namespace Diplom_Pokrovskaya.Core
{
    public class Browser
    {
        public IWebDriver? Driver { get; }

        public Browser()
        {
            Driver = Configurator.BrowserType?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver?.Manage().Window.Maximize();
            Driver?.Manage().Cookies.DeleteAllCookies();
            // Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
