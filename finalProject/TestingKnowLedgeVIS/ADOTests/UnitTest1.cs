using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADO.NET.Repositories;
using ADO.NET.Models;
using System.Collections.Generic;

namespace ADOTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetUserTest()
        {
            UserRepository US = new UserRepository();
            UserModel @userModel = new UserModel();
            @userModel = US.Get(1);
            Console.WriteLine(@userModel.UserId +
                " " +
                @userModel.UserLogin +
                " " +
                @userModel.UserPasswd +
                " "+
               @userModel.UserRole.Desc);
            Assert.IsNotNull(@userModel);
        }

        [TestMethod]
        public void SaveUserTest()
        {
            Role role = new Role();
            role.ID = 3;
            role.Default();
            RoleRepository RoleREP = new RoleRepository();
            UserRepository US = new UserRepository();
            UserModel userModel = new UserModel();
            userModel.UserId = US.GetCount()+1;
            userModel.UserLogin = "two";
            userModel.UserPasswd = "one";
            userModel.UserRole = role;

            Assert.IsTrue(US.Save(userModel));
        }
        [TestMethod]
        public void GetTest()
        {
            Test test = new Test();
            TestRepository testRepository = new TestRepository();
            test = testRepository.Get(1);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void GetAllTest()
        {
            List<Test> testTest = new List<Test>();
            TestRepository testRepository = new TestRepository();
            testTest = testRepository.GetAll();
            Assert.IsNotNull(testTest);
        }
    }
}
