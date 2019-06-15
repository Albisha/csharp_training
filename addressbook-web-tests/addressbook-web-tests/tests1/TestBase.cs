
using System;
using System.Text;
using NUnit.Framework;


namespace WebAddressbookTests
{
public class TestBase
    {      
        protected ApplicationManager app;

      [SetUp]
        public void SetupApplicationManager()
        {
           app = ApplicationManager.GetInstance();
          // app.Auth.Login(new AccountData("admin", "secret"));
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
           // char[] randomWord = new char[l];
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                //randomWord[i] = (char)rnd.Next(65, 91);
                builder.Append(Convert.ToChar(32+Convert.ToInt32(rnd.NextDouble()*223)));
            }
            return builder.ToString();
        }


    }
}
