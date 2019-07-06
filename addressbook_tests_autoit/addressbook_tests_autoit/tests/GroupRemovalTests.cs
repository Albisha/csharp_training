using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase

    {
        [Test]
        public void TestGroupRemoval()
        {
            app.Groups.IsGroupExists(); //проверяем и создаем группу.
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //получаем обновленный список после проверки

            if (oldGroups.Count > 1) //если несколько групп, то удаляем с перемещением подпапок и контактов - по умолчанию
            {
                app.Groups.Remove(oldGroups[0]);
                
            }
            else if (oldGroups.Count == 1) // если 1 группа, то удалять не можем, поэтому добавляем еще 1 группу
            {
                GroupData groupToDelete = new GroupData()
                {
                    Name = "GroupDel"
                };
                app.Groups.Add(groupToDelete);
                app.Groups.Remove(oldGroups[0]);

            }

            List<GroupData> newGroups = app.Groups.GetGroupList(); //получаем обновленный список после удаления
            oldGroups.Remove(oldGroups[0]);
            //  oldGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
