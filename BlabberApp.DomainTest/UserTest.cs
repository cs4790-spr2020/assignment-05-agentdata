using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {        
        [TestMethod]
        public void TestCreateBlankSetGetEmail_Success()
        {
            //Create
            User _testUser = new User();
            _testUser.ChangeEmail("testuser@test.com");

            //Assert
            Assert.AreEqual("testuser@test.com", _testUser.Email);
            Assert.AreEqual(true, _testUser.IsValid());
        }

        [TestMethod]
        public void TestCreateWithEmailSetGetEmail_Success()
        {
            //Create
            User _testUser = new User("testuser@test.com");

            //Assert
            Assert.AreEqual("testuser@test.com", _testUser.Email);
            Assert.AreEqual(true, _testUser.IsValid());
        }

        [TestMethod]
        public void TestUpdateEmail_Success()
        {
            //Create
            User _testUser = new User("testuser@test.com");

            //Update Email with valid email
            _testUser.ChangeEmail("newTestEmail@test.com");

            //Assert
            Assert.AreEqual("newTestEmail@test.com", _testUser.Email);
            Assert.AreEqual(true, _testUser.IsValid());
        }

        [TestMethod]
        public void TestUpdateEmailAfterInitial_Fail00()
        {
            //Create
            User _testUser = new User("testuser@test.com");

            // Assert
            var ex = Assert.ThrowsException<FormatException>(() => _testUser.ChangeEmail("badEmail"));
            Assert.AreEqual("badEmail is invalid", ex.Message.ToString());
            Assert.AreEqual(true, _testUser.IsValid());
        }
        [TestMethod]
        public void TestUpdateEmailFromBlank_Fail01()
        {
            // Arrange
            User _testUser = new User(); 

            // Assert
            var ex = Assert.ThrowsException<FormatException>(() => _testUser.ChangeEmail(""));
            Assert.AreEqual(" is invalid", ex.Message.ToString());
            Assert.ThrowsException<ArgumentNullException>(() => _testUser.IsValid());
        }

        [TestMethod]
        public void TestIdAndDTTM()
        {
            // Arrange
            User _testUser = new User("TestEmail@test.com");
            System.DateTime _RegisterDTTM = System.DateTime.Now;
            System.DateTime _LastLoginDTTM = System.DateTime.Now;
            _testUser.RegisterDTTM = _RegisterDTTM;
            _testUser.LastLoginDTTM = _LastLoginDTTM;

            Guid expected = _testUser.Id;

            // Act
            Guid actual = _testUser.Id;

            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, _testUser.Id is Guid);

            Assert.AreEqual(_RegisterDTTM, _testUser.RegisterDTTM);
            Assert.AreEqual(_LastLoginDTTM, _testUser.LastLoginDTTM);
            Assert.AreEqual(true, _testUser.RegisterDTTM is DateTime);
            Assert.AreEqual(true, _testUser.LastLoginDTTM is DateTime);

            //update login time
            Thread.Sleep(1000);
            System.DateTime  _newLoginTime = System.DateTime.Now;
            _testUser.LastLoginDTTM = _newLoginTime;

            //asssert again
            Assert.AreEqual(_newLoginTime, _testUser.LastLoginDTTM);
            Assert.AreEqual(true, _testUser.LastLoginDTTM is DateTime);

        }
    }
}