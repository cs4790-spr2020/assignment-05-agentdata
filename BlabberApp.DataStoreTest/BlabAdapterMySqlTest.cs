using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private Blab _testBlab;
        private string _testEmail;
        private User _testUser;
        private BlabAdapter _harness = new BlabAdapter(new MySqlBlab());

        [TestInitialize]
        public void Setup()
        {
            _testEmail = "jojo@andthecoons.com";
            _testUser = new User(_testEmail);    
            _testBlab = new Blab("Test blab message @mississippi.com", _testUser);
        }

        [TestCleanup]
        public void TearDown()
        {
            _harness.Remove(_testBlab);
        }

        [TestMethod]
        public void TestAddAndGetByBlabID()
        { 
            //Act
            _harness.Add(_testBlab);

            //Retrieve from DB by email
            Blab actual = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreEqual(_testBlab.Id.ToString(), actual.Id.ToString());
            Assert.AreEqual(_testBlab.Id.ToString(), actual.Id.ToString());
        }

        [TestMethod]
        public void TestAddAndGetAllByUserEmail()
        { 
            //Act
            _harness.Add(_testBlab);

            //Retrieve from DB by email
            ArrayList actual = (ArrayList)_harness.GetByUserId (_testEmail);

            //Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void TestGetAll()
        {
            ArrayList initialCount = (ArrayList)_harness.GetAll();
            _harness.Add(_testBlab);
            ArrayList countAfterAdd = (ArrayList)_harness.GetAll();

            Assert.AreNotEqual(initialCount.Count, countAfterAdd.Count);

        }

        [TestMethod]
        public void TestAddAndUpdateBlab()
        {
            //Add to DB
            _harness.Add(_testBlab);

            //Update blab by Guid Id
            _harness.UpdateBlabById(_testBlab.Id, "This is a new message");

            //Retrieve blab from db by Guid Id
            Blab _updatedBlab = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreNotEqual(_testBlab.Message, _updatedBlab.Message);
            //Assert.AreEqual("This is a new message", _updatedBlab.Message);
        }

         [TestMethod]
         public void TestAddAndDelete()
        { 
            //Act
            _harness.Add(_testBlab);

            //Delete From DB
            _harness.Remove(_testBlab);

            //Retrieve from DB by email, returns null if no row found
            Blab actual = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void TestUpdateNonExistentBlab()
        {
            _harness.UpdateBlabById(new System.Guid(), "fake message");
        }

        [TestMethod]
        public void TestDeleteNonExistentBlab()
        {
            _harness.Remove(new Blab());
        }
    }
}