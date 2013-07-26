using System;
using Fat.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fat.Tests.Industry
{
    [TestClass]
    public class IndustryServiceTest
    {
        [TestMethod]
        public void Get_ReturnsDistinctSet()
        {
            // arrange
            var service = new IndustryService();


            // act
            var result = service.Get();

            // assert
            Assert.IsNotNull(result);

        }
    }
}
