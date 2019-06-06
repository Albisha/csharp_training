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
            app.Contact.Exists();
            ContactData newdata = new ContactData("1stName");
            newdata.Lastname = "3Name";
            app.Contact.Modify(0, newdata);

        }
    }
}
