using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScholarStation;
namespace UserFactoryTests
{
    [TestClass]
    public class UserFactoryUnitTesting
    {
        [TestMethod]
        public void CreateStandardUserCreatesCorrectUserType()
        {
            UserFactory sut = new UserFactory(); 
            sut.CreateUser("Standard User", 0, UserType.Standard, "standard@email.com");
        }

        [TestMethod]
        public void CreateAdminUserCreatesCorrectUserType()
        {
            UserFactory sut = new UserFactory();
            sut.CreateUser("Admin User", 0, UserType.Administrator, "admin@email.com");
        }

        [TestMethod]
        public void CreateProfessorUserCreatesCorrectUserType()
        {
            UserFactory sut = new UserFactory();
            sut.CreateUser("Prof User", 0, UserType.Professor, "prof@email.com");
        }

        [TestMethod]
        public void CreateDeptUserCreatesCorrectUserType()
        {
            UserFactory sut = new UserFactory();
            sut.CreateUser("Dept User", 0, UserType.Department, "dept@email.com");
        }

        [TestMethod]
        public void CreateNullUserCreatesCorrectUserType()
        {
            UserFactory sut = new UserFactory();
            sut.CreateUser("Null User", 0, UserType.Null, "null@email.com");
        }
    }
}
