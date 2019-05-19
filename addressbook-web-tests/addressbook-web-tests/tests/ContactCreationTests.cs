using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitContactCreation();
            ContactData contact = new ContactData("FirstName")
            {
                Middlename = "MiddleName",
                Lastname = "LastName",
                Nickname = "Nickname",
                Email1 = "test1@test.ru",
                HomeTel = "+7-496-123-45-67"
            };
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Auth.Logout();
        }


    }
}