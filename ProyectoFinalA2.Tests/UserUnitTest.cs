using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalA2.Tests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void Save()
        {
            BaseRepository<User> br = new BaseRepository<User>();
            bool ok = br.Save(GetUser());
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void Get()
        {
            BaseRepository<User> br = new BaseRepository<User>();
            User user = br.Get(1);
            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void GetList()
        {
            BaseRepository<User> br = new BaseRepository<User>();
            bool ok = br.GetList(x => true).Count > 0;
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void Delete()
        {
            BaseRepository<User> br = new BaseRepository<User>();
            bool ok = br.Delete(1);
            Assert.IsTrue(ok);
        }

        #region AuxiliaryMethods
        private User GetUser()
        {
            User user = new User();
            user.Name = "Luis";
            user.LastName = "Apell";
            user.UserName = "lluis";
            user.Password = "123456";
            user.CreatedAt = DateTime.Now;
            return user;
        }
        #endregion
    }
}
