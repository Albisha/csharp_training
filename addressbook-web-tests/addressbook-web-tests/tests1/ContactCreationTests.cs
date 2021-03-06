﻿
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> RandomContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));                
            }
            return contacts;
        }
        public static IEnumerable<ContactData> RandomContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("RandomContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContact = ContactData.GetAll(); 
            app.Contact.Create(contact);
            Assert.AreEqual(oldContact.Count+1, app.Contact.GetContactCount());

            List<ContactData> newContact = ContactData.GetAll(); 
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

        [Test]
        public void TestDBConnectivityToContact()
        {
            DateTime start = DateTime.Now;
            List<ContactData> oldContact = app.Contact.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDB = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }

    }
}