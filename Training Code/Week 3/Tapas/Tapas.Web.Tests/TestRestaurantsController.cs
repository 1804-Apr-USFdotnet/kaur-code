using System;
using System.Collections.Generic;
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
        public void TestIndexModel()
        {
            //Arrange
            RestaurantsController controller = new RestaurantsController();            
            //Act
            var indexData=controller.Index() as ViewResult;
            var actual = indexData.Model; 
            //Assert
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestIndexModelData()
        {
           
   
        }
    }
}
