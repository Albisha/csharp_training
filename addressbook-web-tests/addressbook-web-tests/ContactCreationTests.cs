using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("FirstName");
            contact.Middlename = "MiddleName";
            contact.Lastname = "LastName";
            contact.Nickname = "Nickname";
            contact.Email1 = "test1@test.ru";
            contact.HomeTel = "+7-496-123-45-67";
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();
        }


    }
}