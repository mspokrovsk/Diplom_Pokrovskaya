﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Pokrovskaya.Pages
{
    internal class LoginPage : PageBase
    {
        private static string END_POINT = "auth/login";

        // Описание элементов
        private static By userEmail = By.Name("email");
        private static By passwordField = By.Name("password");
        private static By loginButton = By.CssSelector("button[type='submit']");
        private static By textError = By.CssSelector("div.alert.alert-danger");

        // Инициализация класса
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }


        // Методы
        public IWebElement UsernameField => WaitsHelper.WaitForExists(userEmail);
        public IWebElement PasswordField => WaitsHelper.WaitForExists(passwordField);
        public IWebElement LoginButton => WaitsHelper.WaitForExists(loginButton);
        public IWebElement TextError => WaitsHelper.WaitForExists(textError);

        // Комплексные
       public ProjectsPage SuccessfulLogin(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new ProjectsPage(Driver, true);
        }
        public LoginPage IncorrectLogin(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return this;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public override bool IsPageOpened()
        {
            return LoginButton.Displayed && UsernameField.Displayed;
        }
    }
}
