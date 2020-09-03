using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bogus;
using Bogus.DataSets;

namespace AutoSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker("vi");

            #region Name
            var name = new Name();
            var firstNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.FirstName()).ToList();
            var middleNameList = new List<string>() { "Văn", "Hữu", "Thị", "Việt", "Anh", "Đình", "Quang", "Nam", "Đăng" };
            var lastNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.LastName()).ToList();
            for (var i = 0; i < 1000; i++)
            {
                Random r = new Random();
                var indFirst = r.Next(firstNameList.Count());
                var indMiddle = r.Next(middleNameList.Count());
                var indLast = r.Next(lastNameList.Count());
                Console.WriteLine(firstNameList[indFirst] + " " + middleNameList[indMiddle] + " " + lastNameList[indLast]);
            }
            #endregion

            #region CMT
            for (var i = 0; i < 1000; i++)
            {
                var tempCMT = Guid.NewGuid().ToString().Replace("-", string.Empty);
                //var temp2CMT = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var cmt = Regex.Replace(tempCMT, "[a-zA-Z]", string.Empty).Substring(0, 9);
                Console.WriteLine(cmt);
            }
            #endregion



        }
    }
}
