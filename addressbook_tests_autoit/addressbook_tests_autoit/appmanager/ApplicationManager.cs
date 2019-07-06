using System;
using System.Collections.Generic;
using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string Wintitle = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"D:\FreeAddressBookPortable\AddressBook.exe","", aux.SW_SHOW);
            aux.WinWait(Wintitle);
            aux.WinActivate(Wintitle);
            aux.WinWaitActive(Wintitle);

            groupHelper = new GroupHelper(this);
        }


        public void Stop()
        {
            aux.ControlClick(Wintitle,"", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups
        {
            get {
                return groupHelper;
            }
        }
        public AutoItX3 Aux
        {
            get {
            return aux;
            }
            
         }
    }
}
