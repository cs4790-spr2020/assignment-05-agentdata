using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        private User _user;
        private UserAdapter _harness = new UserAdapter(new MySqlUser());

        [TestInitialize]
        public void Setup()
        {
            _user = new User("Jackson@mississippi.com");
        }
        [TestCleanup]
        public void TearDown()
        {
            _harness.Remove(new User("Jackson@mississippi.com"));
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;

            //Act
            _harness.Add(_user);
            User actual = _harness.GetById(_user.Id);

            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }

        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness.Add(_user);

            //Act
            ArrayList users = (ArrayList)_harness.GetAll();
            //get the last user added to the db by grabbing the user at the last index of the users array
            User actual = (User)users[users.Count-1];

            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
        }
    }
}
