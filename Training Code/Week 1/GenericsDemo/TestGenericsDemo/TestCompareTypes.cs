using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsDemo;

namespace TestGenericsDemo
{
    [TestClass]
    public class TestCompareTypes
    {
        [TestMethod]
        public void TestCompareTwo()
        {
            //Arrange
            CompareTypes compareTypes = new CompareTypes();
            bool expectedValue = true;
            //Act
           bool actual= compareTypes.CompareTwo<string>("John", "John");
            //Assert
            Assert.AreEqual(expectedValue, actual);
        }
    }
}
