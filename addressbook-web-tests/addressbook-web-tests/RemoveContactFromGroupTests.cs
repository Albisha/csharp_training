using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            bool notinGroup =true;
            bool inGroup = false;
            List<GroupData> groupsList = GroupData.GetAll(); //список всех групп 
            int i = 0;
            int count = groupsList.Count();
            List<ContactData> contacts = ContactData.GetAll(); //список всех контактов без удаленных
            GroupData groupWithContact = new GroupData(""); ;

           while (i < count && notinGroup)
            
            {
                List<ContactData> contactListInGroup = groupsList[i].GetContacts();
                if (contactListInGroup != null)
                {
                    notinGroup = false;
                    inGroup = true;
                    groupWithContact = groupsList[i];
                    contacts = contactListInGroup; //список контактов в группе i
                }
                else
                {
                    notinGroup = true;
                }
                i++;
                                  
            }
            if (inGroup)
            {
                List<ContactData> oldList = contacts;
                foreach (ContactData contact in contacts)
                {
                    app.Contact.RemoveContactFromGroup(contact, groupWithContact);
                    oldList.Remove(contact);
                }
                List<ContactData> newList = groupWithContact.GetContacts();
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(contacts, newList);
            }
            else
            {
                System.Console.Out.WriteLine("No groups with contacts");
            }

            
               
        }
    }
}
