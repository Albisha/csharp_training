using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            List<ContactData> oldcontacts = app.Contact.GetContactList();

            ContactData newdata = new ContactData("1stName");
            newdata.Lastname = "3Name";
            app.Contact.Modify(0, newdata);
            List<ContactData> newcontacts = app.Contact.GetContactList();

            Assert.AreNotEqual(oldcontacts, newcontacts);

            
           

        }
    }
}
