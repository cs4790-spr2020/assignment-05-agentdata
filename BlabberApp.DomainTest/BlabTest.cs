using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {   
        [TestMethod]
        public void CreateBlankBlab()
        {
            //Create
            Blab _testBlab = new Blab();

            // Assert
            Assert.AreEqual(_testBlab.Message, "");
            Assert.AreEqual(true, _testBlab.IsValid());
        }

        [TestMethod]
        public void CreateBlabWithMessage()
        {
            //Create
            Blab _testBlab = new Blab("new test message for blab");

            // Assert
            Assert.AreEqual(_testBlab.Message, "new test message for blab");
            Assert.AreEqual(true, _testBlab.IsValid());
        }

        [TestMethod]
        public void CreateBlabWithUser()
        {
            //Create
            Blab _testBlab = new Blab(new User("testUser@test.com"));

            // Assert
            Assert.AreEqual(_testBlab.Message, "");
            Assert.AreEqual("testUser@test.com", _testBlab.User.Email);
            Assert.AreEqual(true, _testBlab.IsValid());
        }

        [TestMethod]
        public void CreateBlabWithUserAndMessage()
        {
            //Create
            Blab _testBlab = new Blab("new test blab", new User("testUser@test.com"));

            // Assert
            Assert.AreEqual(_testBlab.Message, "new test blab");
            Assert.AreEqual("testUser@test.com", _testBlab.User.Email);
            Assert.AreEqual(true, _testBlab.IsValid());
        }


        [TestMethod]
        public void TestId()
        {
            Blab _testBlab = new Blab();

            // Arrange
            Guid expected = _testBlab.Id;

            // Act
            Guid actual = _testBlab.Id;

            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, _testBlab.Id is Guid);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();

            // Act
            Blab Actual = new Blab();

            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}