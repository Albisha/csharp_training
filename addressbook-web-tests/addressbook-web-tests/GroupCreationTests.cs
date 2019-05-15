﻿using System;
using System.Text;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests:TestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("gr4");
            group.Header = "gr4header";
            group.Footer = "gr4footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
   

    }
}
