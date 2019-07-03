using AutoItX3Lib;
namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string Wintitle;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            Wintitle = ApplicationManager.Wintitle;
            this.aux = manager.Aux;
        }
    }
}