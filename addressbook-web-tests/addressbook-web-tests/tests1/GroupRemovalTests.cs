
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
            app.Groups.Remove(1);
        }

    }
}
