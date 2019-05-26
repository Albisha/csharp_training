using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = driver;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            if (IsElementPresent(By.Name("selected[]")))
            {
                SelectGroup(v);
                RemoveGroup();
                manager.Navigator.ReturnToGroupsPage();
                return this;
            }
            GroupData group = new GroupData("");
            Create(group);
            driver.FindElement(By.Name("selected[]"));
            v = 0;
            SelectGroup(v);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper Modify(int v, GroupData newdata)
        {
            manager.Navigator.GoToGroupsPage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                SelectGroup(v);
                InitGroupModification();
                FillGroupForm(newdata);
                SubmitGroupModification();
                manager.Navigator.ReturnToGroupsPage();
                return this;
            }
            GroupData group = new GroupData("");
            Create(group);
            driver.FindElement(By.Name("selected[]"));
            v = 0;
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newdata);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }



        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }


        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }
}