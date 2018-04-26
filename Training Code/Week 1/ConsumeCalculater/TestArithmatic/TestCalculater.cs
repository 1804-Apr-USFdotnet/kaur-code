using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;//MSTest
using ExtensionMethodDemo;

namespace TestArithmatic
{
    [TestClass]
    public class TestCalculater
    {
        [TestMethod]
        public void TestAdd()
        {
            //arrange 
            Calculater calculater = new Calculater();
            float expectedSum = 5f;

            //Act
           var actualSum= calculater.Add(2, 3);

            //Assert
            Assert.AreEqual(expectedSum, actualSum);

        }
    }
}
