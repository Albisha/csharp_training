﻿
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContact = app.Contact.GetContactList();
            app.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count+1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
/*
        [Test]
        public void EmptyContactCreationTest()
        {
            List<ContactData> oldContact = app.Contact.GetContactList();
            ContactData contact = new ContactData("", "");
            app.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        } */

    }
}