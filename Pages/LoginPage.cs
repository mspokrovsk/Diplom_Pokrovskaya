using Allure.NUnit.Attributes;
using Diplom_Pokrovskaya.Elements;
using OpenQA.Selenium;

namespace Diplom_Pokrovskaya.Pages
{
    public class LoginPage : PageBase
    {
        private static string END_POINT = "auth/login";

        private static By userEmail = By.Name("email");
        private static By passwordField = By.Name("password");
        private static By loginButton = By.CssSelector("button[type='submit']");
        private static By textError = By.CssSelector("div.message-block.message-block--negative.message-block--scroll");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UsernameField => WaitsHelper.WaitForExists(userEmail);

        public IWebElement PasswordField => WaitsHelper.WaitForExists(passwordField);

        public Button LoginButton => new Button(Driver, loginButton);

        public IWebElement TextError => WaitsHelper.WaitForExists(textError);

        protected override string GetEndpoint()
        {
            return END_POINT;
        }
        
        public override bool IsPageOpened()
        {
            try
            {
                return LoginButton.Displayed && UsernameField.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [AllureStep("Нажата кнопка логина")]
        public void ClickLoginInButton() => LoginButton.Click();

        [AllureStep("Отображение текста ошибки")]
        public string GetErrorLabelText() => TextError.Text.Trim();
    }
}
