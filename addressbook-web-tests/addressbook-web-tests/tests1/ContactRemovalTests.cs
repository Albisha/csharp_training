using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            List<ContactData> oldcontacts = app.Contact.GetContactList();

            app.Contact.Remove(0);

            List<ContactData> newcontacts = app.Contact.GetContactList();
            oldcontacts.RemoveAt(0);

            Assert.AreEqual(oldcontacts, newcontacts);

        }

    }
}
