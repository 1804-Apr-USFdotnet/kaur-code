using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapas.DataLayer.Models;
using Tapas.Web.Controllers;

namespace Tapas.Web.Tests
{
    [TestClass]
    public class TestRestaurantsController
    {
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            RestaurantsController controller = new RestaurantsController();
            Restaurant expected=null;
            //Act
            var indexData=controller.Index() as ViewResult;
            var actual = indexData.Model;            
            //Assert
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }
    }
}
