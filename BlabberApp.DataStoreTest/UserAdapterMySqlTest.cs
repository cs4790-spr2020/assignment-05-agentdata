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
            _user = new User("testUserAdapter@test.com");
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
        }

        [TestCleanup]
        public void TearDown()
        {
            _harness.Remove(_user);
        }

        [TestMethod]
        public void TestAddAndGetUserByID()
        {
            //Add user to DB
            _harness.Add(_user);

            //Retrieve user from DB by Guid Id
            User actual = _harness.GetById(_user.Id);

            //Assert IDs and Email match
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
            Assert.AreEqual(_user.Email, actual.Email);
        }

        [TestMethod]
        public void TestAddAndGetUserByEmail()
        {
            //Add user to DB
            _harness.Add(_user);

            //Retrieve user from DB by Guid Id
            User actual = _harness.GetByEmail(_user.Email);

            //Assert IDs and Email match
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
            Assert.AreEqual(_user.Email, actual.Email);
        }

        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Add user to DB
            _harness.Add(_user);

            //Retrieve all users
            ArrayList users = (ArrayList)_harness.GetAll();

            //get the last user added to the db by grabbing the user at the last index of the users array
            User actual = (User)users[users.Count-1];

            //Assert IDs and Email match
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString());
            Assert.AreEqual(_user.Email, actual.Email);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Add user to DB
            _harness.Add(_user);

            //Update user email
            _harness.UpdateEmailById(_user.Id, "new-testUpdate@test.com");

            //Retrieve record from db by Guid Id
            User _modifiedUser = _harness.GetById(_user.Id);

            //Assert
            Assert.AreNotEqual(_modifiedUser.Email.ToString(), _user.Email.ToString());
            Assert.AreEqual(_modifiedUser.Email.ToString(), "new-testUpdate@test.com");
        }

        [TestMethod]
        public void TestUpdateNonExistentUser()
        {
            _harness.UpdateEmailById(new System.Guid(), "fake message");
        }
    }
}