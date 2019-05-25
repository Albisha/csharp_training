
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
            app.Groups.Create(group);
        }

      [Test]

        public void EmptyGroupCreationTest()
        {
           /* AccountData correctaccount = new AccountData("admin", "secret");
            app.Auth.Login(correctaccount);*/
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
                  }
    }
}
