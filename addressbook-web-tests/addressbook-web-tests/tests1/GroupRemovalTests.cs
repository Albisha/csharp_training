
using System.Collections.Generic;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase

    {
        
        [Test]
        public void GroupRemovalTest()
        {
            AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);

            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newgroups = app.Groups.GetGroupList();

            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);
        }

    }
}
