using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ADO.NET.Repositories;
using ADO.NET.Models;

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
    }
}
