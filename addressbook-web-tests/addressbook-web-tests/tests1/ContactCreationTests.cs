
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            

            ContactData contact = new ContactData("FirstName");
            contact.Middlename = "MiddleName";
            contact.Lastname = "LastName";
            contact.Nickname = "Nickname";
            contact.Email1 = "test1@test.ru";
            contact.HomeTel = "+7-496-123-45-67";

            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Contact.InitContactCreation();
            app.Contact.Create(contact);
            List<ContactData> newcontacts = app.Contact.GetContactList();

            Assert.AreEqual(oldcontacts.Count + 1, newcontacts.Count);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            List<ContactData> oldcontacts = app.Contact.GetContactList();
            app.Contact.InitContactCreation();
            ContactData contact = new ContactData("");
            app.Contact.Create(contact);
            List<ContactData> newcontacts = app.Contact.GetContactList();

            Assert.AreEqual(oldcontacts.Count + 1, newcontacts.Count);

        }

    }
}