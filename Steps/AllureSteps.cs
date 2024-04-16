using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Steps
{
    public class AllureSteps
    {
        protected IWebDriver Driver;

        public AllureSteps(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
