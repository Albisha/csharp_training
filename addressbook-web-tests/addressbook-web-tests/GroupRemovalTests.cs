using System;
using System.Text;
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase

    {
        
        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();
        }

    }
}
