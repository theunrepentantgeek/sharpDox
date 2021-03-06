﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharpDox.RegressionTests
{
    [TestClass]
    public class Regression5
    {
        [TestMethod]
        public void RepositoryShouldContainNestedTypes()
        {
            // Arrange
            var sdProject = TestConfig.ParseProject();
               
            // Act
            var type = sdProject.Solutions.First().Value.Repositories.First().Value.GetTypeByIdentifier("SharpDox.TestProject.Regression5");

            // Assert            
            Assert.AreEqual(1, type.NestedTypes.Count);
        }
    }
}
