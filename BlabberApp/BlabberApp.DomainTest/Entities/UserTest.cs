using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "hooha@example.com";
            harness.ChangeEmail("hooha@example.com");

            // Act
            string actual = harness.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail00()
        {
            // Arrange
            User harness = new User(); 
            
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Email"));

            // Assert
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            // Arrange
            User harness = new User(); 

            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Email"));

            // Assert
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }
        [TestMethod]
        public void TestId()
        {
            // Arrange
            User harness = new User();
            Guid expected = harness.Id;

            // Act
            Guid actual = harness.Id;

            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }
    }
}
