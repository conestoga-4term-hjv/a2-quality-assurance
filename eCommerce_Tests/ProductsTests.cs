using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2_eCommerce;

namespace eCommerce_Tests
{
    [TestFixture]
    public class ProductsTests
    {
        #region Venicio Tests       

        #region Constructor Tests

        // For this test, I'm testing the creation of a valid Product
        // I design this one to make sure the Product constructor is correctly creating valid objects
        [Test]
        public void Constructor_ValidInput_ShouldCreateProduct()
        {
            // Arrange
            int validProdID = 100;
            string validProdName = "Test Product";
            int validItemPrice = 500;
            int validStockAmount = 50;

            // Act
            Products product = new Products(validProdID, validProdName, validItemPrice, validStockAmount);

            // Assert
            Assert.That(product.ProdID, Is.EqualTo(validProdID));
            Assert.That(product.ProdName, Is.EqualTo(validProdName));
            Assert.That(product.ItemPrice, Is.EqualTo(validItemPrice));
            Assert.That(product.StockAmount, Is.EqualTo(validStockAmount));
        }
        // For this test, I'm testing creation with an invalid stock, a negative one, more precisely
        // I designed this one because it could be a very problematic one if it occurs, and it is also very easy to occur
        [Test]
        public void Constructor_NegativeStockAmount_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            int validProdID = 101;
            string validProdName = "Test Product";
            int validItemPrice = 500;
            int invalidStockAmount = -10;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProdID, validProdName, validItemPrice, invalidStockAmount));

            // Assert
            Assert.That(ex.Message, Does.Contain("Stock amount must be between 1 and 100,000."));
        }

        // For this test, I'm testing creation with a value higher than the accepted value
        // I designed this one because users might assign value wrongly, and we need to make sure the system is catching that
        [Test]
        public void Constructor_10001PriceValue_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            int validProdID = 102;
            string validProdName = "Test Product";
            int invalidItemPrice = 10001;
            int validStockAmount = 1;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(validProdID, validProdName, invalidItemPrice, validStockAmount));

            // Assert
            Assert.That(ex.Message, Does.Contain("Item price must be between $10 and $10,000."));
        }

        // For this test, I'm testing creation with an invalid ProductID
        // This should be a fairly common error and the system should be able to catch it
        [Test]
        public void Constructor_InvalidProductID_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            int invalidProdID = 5;
            string validProdName = "Test Product";
            int validItemPrice = 1000;
            int validStockAmount = 10;

            // Act
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Products(invalidProdID, validProdName, validItemPrice, validStockAmount));

            // Assert
            Assert.That(ex.Message, Does.Contain("Product ID must be between 10 and 100000."));
        }

        #endregion

        #region Increase/Descrease

        // For this test, I'm testing increasing the stock to a value that exceeds the maximum capacity
        // Exceeding the maximum capacity should be a common error, as such, we need to cover it 
        [Test]
        public void IncreaseStock_ExceedsMax_ShouldThrowInvalidOperationException()
        {
            // Arrange
            int validProdID = 100;
            string validProdName = "Test Product";
            int validItemPrice = 500;
            int validStockAmount = 50;

            Products validProduct = new Products(validProdID, validProdName, validItemPrice, validStockAmount);

            int increaseAmount = 100001;

            // Act
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => validProduct.IncreaseStock(increaseAmount));

            // Assert
            Assert.That(ex.Message, Does.Contain("Stock amount cannot exceed 100,000."));
        }

        #endregion

        #endregion

    }
}
