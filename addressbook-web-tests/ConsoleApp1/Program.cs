using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //передаем кол-во тестовых данных, которое хотим сгенерировать
            StreamWriter writer = new StreamWriter(args[1]);//запись в файл
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", 
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10),
                    TestBase.GenerateRandomString(10)));
            };
            writer.Close();
        }
    }
}
