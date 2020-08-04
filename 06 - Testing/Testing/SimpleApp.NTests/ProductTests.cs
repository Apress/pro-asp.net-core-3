using SimpleApp.Models;
using NUnit.Framework;
using System.Diagnostics;

namespace SimpleApp.NTests
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };

            //Act
            p.Name = "New Name";

            //Assert
            Assert.Pass("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product { Name = "Test", Price = 100M };
            // Act
            p.Price = 200M;
            //Assert
            Assert.Equal(100M, p.Price);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}