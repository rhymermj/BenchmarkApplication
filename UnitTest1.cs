using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenchmarkApplication;
using System.Collections.Generic;

namespace BenchmarkUnitTests
{
    [TestClass]
    public class StaffUnitTests
    {
        [TestMethod]
        public void TestStaffName() 
        {
            Staff s = new Staff();

            s.StaffName = "Amber";

            Assert.AreEqual("Amber", s.StaffName);
        }

        [TestMethod]
        public void TestStaffId()
        {
            Staff s = new Staff();

            s.StaffId = 123;

            Assert.AreEqual(123, s.StaffId);
        }

        [TestMethod]
        public void TestStaffDoB()
        {
            Staff s = new Staff();

            s.StaffDoB = "01/01/2001";

            Assert.AreEqual("01/01/2001", s.StaffDoB);
        }

        [TestMethod]
        public void TestStaffEmail()
        {
            Staff s = new Staff();

            s.StaffEmail = "amber@email.com";

            Assert.AreEqual("amber@email.com", s.StaffEmail);
        }

        [TestMethod]
        public void TestStaffPosition()
        {
            Staff s = new Staff();

            s.StaffPosition = "Team Lead";

            Assert.AreEqual("Team Lead", s.StaffPosition);
        }

        [TestMethod]
        public void TestStaffSalary()
        {
            Staff s = new Staff();

            s.StaffSalary = 90000;

            Assert.AreEqual(90000, s.StaffSalary);
        }

        [TestMethod]
        public void TestStaffConstructor()
        {
            Staff s = new Staff();

            Assert.AreEqual("NA", s.StaffName, "Name Fail");
            Assert.AreEqual(0, s.StaffId, "ID Fail");
            Assert.AreEqual("NA", s.StaffDoB, "Date of Birth Fail");
            Assert.AreEqual("NA", s.StaffEmail, "Email Fail");
            Assert.AreEqual("NA", s.StaffPosition, "Position Fail");
            Assert.AreEqual(0, s.StaffSalary, "Salary Fail");
        }

        [TestMethod]
        public void TestStaffToStringFormat()
        {
            Staff s = new Staff();

            s.StaffName = "Amber";
            s.StaffId = 123;
            s.StaffDoB = "01/01/2001";
            s.StaffEmail = "amber@email.com";
            s.StaffPosition = "Team Lead";
            s.StaffSalary = 90000;

            Assert.AreEqual("Amber ID: 123 DoB: 01/01/2001 Email: amber@email.com Position: Team Lead Salary: $90000", s.ToString());
        }
    }

    [TestClass]
    public class FilterUnitTests
    {
        [TestMethod]
        public void TestFilterSortAZ()
        {
            Staff s1 = new Staff();
            s1.StaffName = "s1";
            s1.StaffId = 111;
            s1.StaffDoB = "01/01/2001";
            s1.StaffEmail = "s1@email.com";
            s1.StaffPosition = "a";
            s1.StaffSalary = 71000;

            Staff s2 = new Staff();
            s2.StaffName = "s2";
            s2.StaffId = 222;
            s2.StaffDoB = "02/02/2002";
            s2.StaffEmail = "s2@email.com";
            s2.StaffPosition = "b";
            s2.StaffSalary = 72000;

            Staff s3 = new Staff();
            s3.StaffName = "s3";
            s3.StaffId = 333;
            s3.StaffDoB = "03/03/2003";
            s3.StaffEmail = "s3@email.com";
            s3.StaffPosition = "c";
            s3.StaffSalary = 73000;

            Staff s4 = new Staff();
            s4.StaffName = "s4";
            s4.StaffId = 444;
            s4.StaffDoB = "04/04/2004";
            s4.StaffEmail = "s4@email.com";
            s4.StaffPosition = "d";
            s4.StaffSalary = 74000;

            List<Staff> sListExpected = new List<Staff>();

            sListExpected.Add(s1);
            sListExpected.Add(s2);
            sListExpected.Add(s3);
            sListExpected.Add(s4);

            List<Staff> sList = new List<Staff>();

            sList.Add(s1);
            sList.Add(s2);
            sList.Add(s3);
            sList.Add(s4);

            Filter f = new Filter();

            sList = f.SortAZ(sList);

            CollectionAssert.AreEqual(sListExpected, sList);
        }

        [TestMethod]
        public void TestFilterSortZA()
        {
            Staff s1 = new Staff();
            s1.StaffName = "s1";
            s1.StaffId = 111;
            s1.StaffDoB = "01/01/2001";
            s1.StaffEmail = "s1@email.com";
            s1.StaffPosition = "a";
            s1.StaffSalary = 71000;

            Staff s2 = new Staff();
            s2.StaffName = "s2";
            s2.StaffId = 222;
            s2.StaffDoB = "02/02/2002";
            s2.StaffEmail = "s2@email.com";
            s2.StaffPosition = "b";
            s2.StaffSalary = 72000;

            Staff s3 = new Staff();
            s3.StaffName = "s3";
            s3.StaffId = 333;
            s3.StaffDoB = "03/03/2003";
            s3.StaffEmail = "s3@email.com";
            s3.StaffPosition = "c";
            s3.StaffSalary = 73000;

            Staff s4 = new Staff();
            s4.StaffName = "s4";
            s4.StaffId = 444;
            s4.StaffDoB = "04/04/2004";
            s4.StaffEmail = "s4@email.com";
            s4.StaffPosition = "d";
            s4.StaffSalary = 74000;

            List<Staff> sListExpected = new List<Staff>();

            sListExpected.Add(s4);
            sListExpected.Add(s3);
            sListExpected.Add(s2);
            sListExpected.Add(s1);

            List<Staff> sList = new List<Staff>();

            sList.Add(s4);
            sList.Add(s3);
            sList.Add(s2);
            sList.Add(s1);

            Filter f = new Filter();

            sList = f.SortZA(sList);

            CollectionAssert.AreEqual(sListExpected, sList);
        }

        [TestMethod]
        public void TestFilterSearch()
        {
            Staff s1 = new Staff();
            s1.StaffName = "Amber";

            Staff s2 = new Staff();
            s2.StaffName = "Brian";

            Staff s3 = new Staff();
            s3.StaffName = "Craig";

            Staff s4 = new Staff();
            s4.StaffName = "John";

            List<Staff> sList = new List<Staff>();

            sList.Add(s1);
            sList.Add(s2);
            sList.Add(s3);
            sList.Add(s4);

            Filter f = new Filter();

            List<Staff> searchResults = new List<Staff>();

            searchResults = f.Search(sList, "a");

            CollectionAssert.Contains(searchResults, s1);
            CollectionAssert.Contains(searchResults, s2);
            CollectionAssert.Contains(searchResults, s3);
            CollectionAssert.DoesNotContain(searchResults, s4);
        }
    }

    [TestClass]
    public class FileManagerUnitTests
    {
        [TestMethod]
        public void TestLoadStaff()
        {
            Staff s1 = new Staff();
            s1.StaffName = "s1";
            s1.StaffId = 111;
            s1.StaffDoB = "01/01/2001";
            s1.StaffEmail = "s1@email.com";
            s1.StaffPosition = "a";
            s1.StaffSalary = 71000;

            Staff s2 = new Staff();
            s2.StaffName = "s2";
            s2.StaffId = 222;
            s2.StaffDoB = "02/02/2002";
            s2.StaffEmail = "s2@email.com";
            s2.StaffPosition = "b";
            s2.StaffSalary = 72000;

            Staff s3 = new Staff();
            s3.StaffName = "s3";
            s3.StaffId = 333;
            s3.StaffDoB = "03/03/2003";
            s3.StaffEmail = "s3@email.com";
            s3.StaffPosition = "c";
            s3.StaffSalary = 73000;

            Staff s4 = new Staff();
            s4.StaffName = "s4";
            s4.StaffId = 444;
            s4.StaffDoB = "04/04/2004";
            s4.StaffEmail = "s4@email.com";
            s4.StaffPosition = "d";
            s4.StaffSalary = 74000;

            List<Staff> sListExpected = new List<Staff>();

            sListExpected.Add(s1);
            sListExpected.Add(s2);
            sListExpected.Add(s3);
            sListExpected.Add(s4);

            List<Staff> sList = new List<Staff>();

            sList.Add(s1);
            sList.Add(s2);
            sList.Add(s3);
            sList.Add(s4);

            FileManager fm = new FileManager();

            sList = fm.LoadStaff();

            CollectionAssert.AreEqual(sListExpected, sList);
        }

        [TestMethod]
        public bool TestSaveStaff()
        {
            Staff s1 = new Staff();
            s1.StaffName = "s1";
            s1.StaffId = 111;
            s1.StaffDoB = "01/01/2001";
            s1.StaffEmail = "s1@email.com";
            s1.StaffPosition = "a";
            s1.StaffSalary = 71000;

            List<Staff> sListExpected = new List<Staff>();

            sListExpected.Add(s1);

            List<Staff> sList = new List<Staff>();

            sList.Add(s1);

            FileManager fm = new FileManager();

            string fileName = "test.txt";

            sList = fm.SaveStaff(sList, fileName);

            CollectionAssert.AreEqual(sListExpected, sList);




        }
    }
}
