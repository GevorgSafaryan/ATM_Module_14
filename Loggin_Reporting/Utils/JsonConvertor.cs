using Loggin_Reporting.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Loggin_Reporting.Utils
{
    public static class JsonConvertor
    {
        public static TestData GetTestData()
        {
            if (File.Exists(@"D:\ATM_Module_9\FW_Basics\Utils\TestData.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_9\FW_Basics\Utils\TestData.json");
                return JsonConvert.DeserializeObject<TestData>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static List<Users> GetUser()
        {
            if (File.Exists(@"D:\ATM_Module_9\FW_Basics\Utils\Users.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_9\FW_Basics\Utils\Users.json");
                return JsonConvert.DeserializeObject<List<Users>>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static IEnumerable<Users> ReturnUsers()
        {
            if (File.Exists(@"D:\ATM_Module_9\FW_Basics\Utils\Users.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_9\FW_Basics\Utils\Users.json");
                List<Users> users = JsonConvert.DeserializeObject<List<Users>>(data);
                for (int i = 3; i < users.Count; i++)
                {
                    yield return users[i];
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
