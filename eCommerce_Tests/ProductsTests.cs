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

        // For this test I'm testing the creation of a valid Product
        // I design this one to make sure the Product constructor is correctly creating objects
        [Test]
        public void Constructor_ValidInput_ShouldCreateProduct()
        {
            // Arrange
            int prodID = 100;
            string prodName = "Test Product";
            int itemPrice = 500;
            int stockAmount = 50;

            // Act
            Products product = new Products(prodID, prodName, itemPrice, stockAmount);

            // Assert
            Assert.That(product.ProdID, Is.EqualTo(prodID));
            Assert.That(product.ProdName, Is.EqualTo(prodName));
            Assert.That(product.ItemPrice, Is.EqualTo(itemPrice));
            Assert.That(product.StockAmount, Is.EqualTo(stockAmount));
        }

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

        #endregion


        #endregion

    }
}
