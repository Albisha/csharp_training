using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            GroupData newdata = new GroupData("gr6");
            newdata.Header = "gr6header";
            newdata.Footer = "gr6footer";

            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newdata);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreNotEqual(oldgroups, newgroups);
        }
    }
}
