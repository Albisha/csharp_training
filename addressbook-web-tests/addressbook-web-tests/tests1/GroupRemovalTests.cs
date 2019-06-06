
using NUnit.Framework;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase

    {
        
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Exists();
            app.Groups.Remove(0);
        }

    }
}
