using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapas.Web.Controllers;

namespace Tapas.Web.Tests
{
    [TestClass]
    public class TestHomeController
    {
        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            HomeController controller = new HomeController();
            string expected = "Index";
            //Act
            var action = controller.Index() as ViewResult;
            string actualViewName = action.ViewName;
            //Assert
            Assert.AreEqual(expected, actualViewName);
        }
        [TestMethod]
        public void TestIndexData()
        {
            //Arrange
            HomeController controller = new HomeController();
            string expectedTempData = ".Net Full Stack";
            //Act
            var action = controller.Index() as ViewResult;
            string actualTempData = action.TempData["Training"].ToString();
            //Assert
            Assert.AreEqual(expectedTempData, actualTempData);
        }
    }
}
