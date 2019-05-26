using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);
            GroupData group = new GroupData("gr4");
            group.Header = "gr4header";
            group.Footer = "gr4footer";
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

      [Test]

        public void EmptyGroupCreationTest()
        {
          
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }
    }
}
