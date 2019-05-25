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
            ContactData newdata = new ContactData("1stName");
            newdata.Middlename = "2Name";
            newdata.Lastname = "3Name";
            newdata.Nickname = "4name";
            app.Contact.Modify(1, newdata);

        }
    }
}
