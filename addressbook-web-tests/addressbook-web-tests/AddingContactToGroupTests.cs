using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
  public class AddingContactToGroupTests: AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> allContactList = ContactData.GetAll();
            ContactData contact = new ContactData("1", "2");
            GroupData group=null;



            if (groups.Count == 0) //если нет групп, создаем новую
            {
                GroupData newgroup = new GroupData("grname");
                newgroup.Header = "header";
                newgroup.Footer = "footer";
                app.Groups.Create(newgroup);
                List<GroupData> newgroups = GroupData.GetAll();
                groups = newgroups;
                group = groups.First();
            } 
 
            if (allContactList.Count == 0) //если нет контактов, создаем новый
            {               
                app.Contact.Create(contact);
                allContactList.Add(contact);
            }

            bool contactToAddExist = false;
                      
            List<ContactData> oldList = null;
           // int count = groups.Count;

            for (int i = 0; i < groups.Count; i++)
            {
                group = groups[i];
                oldList = group.GetContacts();
                if (oldList.Count == 0) //в группе нет контактов, добавляем первый из списка
                {   
                    contact = ContactData.GetAll().First();
                    contactToAddExist = true;
                }
                else if (oldList.Count == allContactList.Count) // в группу добавлены все контакты,п.э. создаем новый контакт
                {
                    
                    contact = new ContactData("firstname123", "lastname123");
                    app.Contact.Create(contact);
                    contactToAddExist = true; 
                }
                else if (oldList.Count < allContactList.Count) // есть контакт, который можно добавить в группу             
                {                
                  contact = ContactData.GetAll().Except(oldList).First();
                    contactToAddExist = true;
                }               
            }

            if (contactToAddExist)
            {
                app.Contact.AddContactToGrooup(contact, group);
                List<ContactData> newList = group.GetContacts();
                oldList.Add(contact);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);

            }
                          
        }


    }
}
