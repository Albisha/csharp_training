﻿using System;
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
            app.Groups.Exists();
            GroupData newdata = new GroupData("gr6edited");
            newdata.Header = "editedheader";
            newdata.Footer = "editedfooter";
            app.Groups.Modify(0, newdata);
        }
    }
}
