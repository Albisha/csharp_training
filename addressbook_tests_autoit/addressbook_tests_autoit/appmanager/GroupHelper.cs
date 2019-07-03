using System;
using System.Collections.Generic;
using System.Text;


namespace addressbook_tests_autoit
{
   public class GroupHelper:HelperBase
        
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }
        public static string groupTitle = "Group editor";
        public List<GroupData> GetGroupList()
        {
            return new List<GroupData>();
        }

        public void Add(GroupData newGroup)
        {
            aux.ControlClick("Free Address Book","", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(groupTitle);
            aux.ControlClick(groupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{Enter}");
            aux.ControlClick(groupTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }
    }
}
