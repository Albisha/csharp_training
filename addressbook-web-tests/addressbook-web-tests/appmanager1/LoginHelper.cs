﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager):base(manager)
        {
            this.driver = driver;
        }
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {

            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
