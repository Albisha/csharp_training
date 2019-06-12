﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {


        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = driver;
        }

        public ContactHelper InitContactCreation()
        {

            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
           
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();           
            ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//tr[@name='entry']"));
       
      //int linecount=0; - лишний счетчик, можно и без него найти ячейки
            foreach (IWebElement element in elements)
            { //найденные значения ячеек для фамилии и имени сразу добавляю  в контакты
                contacts.Add(new ContactData(element.FindElement(By.XPath(".//td[3]")).Text, element.FindElement(By.XPath(".//td[2]")).Text));
              /*
               * contacts.Add(new ContactData(element.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (linecount + 2) + "]/td[3]")).Text, element.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[" + (linecount + 2) + "]/td[2]")).Text));
               * linecount++; */

            }
            return contacts;

        }
   

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.Name("selected[]"));
            SelectContact(v);
            RemoveContact();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
           manager.Navigator.GoToHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
                  SelectContact(v);
                  InitContactModification(v);
                  FillContactForm(newdata);
                  SubmitContactModification();
                  return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);

            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.CompanyAddress);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomeTel);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkTel);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.MobileTel);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);

            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);

            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);


            /*   // fill birth date=14.06.1984
               new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("14");
               driver.FindElement(By.XPath("//option[16]")).Click();
               driver.FindElement(By.Name("bmonth")).Click();
               new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("June");
               driver.FindElement(By.XPath("//option[@value='June']")).Click();
               driver.FindElement(By.Name("byear")).Click();
               driver.FindElement(By.Name("byear")).Clear();
               driver.FindElement(By.Name("byear")).SendKeys("1984");
               driver.FindElement(By.Name("aday")).Click();*/

            return this;

        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();

            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();

            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


        public ContactHelper RemoveContact()
        {
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                driver.SwitchTo().Alert().Accept();
                return this;
          
        }
        public ContactHelper Exists()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData newcontact = new ContactData("NewFirstN","NewLastN" );                
                Create(newcontact);
            }
            return this;
        }
    }
}