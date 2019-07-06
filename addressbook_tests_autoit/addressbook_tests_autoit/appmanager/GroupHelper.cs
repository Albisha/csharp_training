using System;
using System.Collections.Generic;
using System.Text;


namespace addressbook_tests_autoit
{
   public class GroupHelper:HelperBase
        
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }
        public static string groupTitle = "Group editor";
        public static string deleteGroupTitle="Delete group";

        public List<GroupData> GetGroupList()
        {            
            OpensGroupsDialog();
            List<GroupData> groupsList = new List<GroupData>();
            string itemsCount = aux.ControlTreeView(groupTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51","GetItemCount", "#0", "");
            int groupsCount = int.Parse(itemsCount);

            for (int i = 0; i < groupsCount; i++)
            {
                string item = aux.ControlTreeView(groupTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51","GetText", "#0|#" + i, "");
                groupsList.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialog();
            return groupsList;
        }
        public void Add(GroupData newGroup)
        {
            OpensGroupsDialog();
            aux.ControlClick(groupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{Enter}");
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(groupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public GroupHelper IsGroupExists()

        {
           
            OpensGroupsDialog();
            List<GroupData> oldGroups = GetGroupList();

            if (oldGroups.Count == 0)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "GroupForRemove1"
                };

                Add(newGroup);
            }
            return this;          
        }

        public void Remove(GroupData group) 
        {
            if (!aux.WinGetTitle("[ACTIVE]").Equals(groupTitle))
            {
                OpensGroupsDialog();
            }          
            //выбираем группу на удаление
            aux.ControlTreeView(groupTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#1", "");
            aux.ControlClick(groupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51"); // нажимаем удалить
            aux.WinWaitActive(deleteGroupTitle);
            //подтверждаем удаление
            aux.ControlClick(deleteGroupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialog();
        }

        private void OpensGroupsDialog()
        {
            aux.ControlClick("Free Address Book", "", "WindowsForms10.BUTTON.app.0.2c908d512"); //
            aux.WinWaitActive(groupTitle);
        }


    }
}
