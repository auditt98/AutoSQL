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
        private Faker faker = new Faker("vi");

        string[] GenMultipleCMT(int n)
        {
            string[] listCMT = new string[] { };
            for (var i = 0; i < n; i++)
            {
                var tempCMT = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var cmt = Regex.Replace(tempCMT, "[a-zA-Z]", string.Empty).Substring(0, 9);
                listCMT.Append(cmt);
            }
            return listCMT;
        }

        string GenSingleCMT()
        {
            var tempCMT = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var cmt = Regex.Replace(tempCMT, "[a-zA-Z]", string.Empty).Substring(0, 9);
            return cmt;
        }

        (string, string, string) GenSingleName()
        {
            var firstNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.FirstName()).ToList();
            //since faker does not support middle name
            var middleNameList = new List<string>() { "Văn", "Hữu", "Thị", "Việt", "Anh", "Đình", "Quang", "Nam", "Đăng" };
            var lastNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.LastName()).ToList();
            Random r = new Random();
            var indFirst = r.Next(firstNameList.Count());
            var indMiddle = r.Next(middleNameList.Count());
            var indLast = r.Next(lastNameList.Count());
            return (firstNameList[indFirst], middleNameList[indMiddle], lastNameList[indLast]);
        }

        (string, string, string)[] GenMultipleName(int n)
        {
            (string, string, string)[] listName = new (string, string, string)[] { };
            var firstNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.FirstName()).ToList();
            //since faker does not support middle name
            var middleNameList = new List<string>() { "Văn", "Hữu", "Thị", "Việt", "Anh", "Đình", "Quang", "Nam", "Đăng" };
            var lastNameList = Enumerable.Range(1, 1000).Select(_ => faker.Name.LastName()).ToList();
            for(var i = 0; i < n; i++)
            {
                Random r = new Random();
                var indFirst = r.Next(firstNameList.Count());
                var indMiddle = r.Next(middleNameList.Count());
                var indLast = r.Next(lastNameList.Count());
                listName.Append((firstNameList[indFirst], middleNameList[indMiddle], lastNameList[indLast]));
            }
            return listName;
        }


        static void Main(string[] args)
        {

        }
    }
}
