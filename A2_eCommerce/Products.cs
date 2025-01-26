using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_eCommerce
{
    public class Products
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public int ItemPrice { get; set; }
        public int StockAmount { get; set; }

        public Products(int prodID, string prodName, int itemPrice, int stockAmount) {
            if (prodID < 10 || prodID > 100000)
                throw new ArgumentOutOfRangeException(nameof(prodID), "Product ID must be between 10 and 100000.");
            if (itemPrice < 10 || itemPrice > 10000)
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Item price must be between $10 and $10,000.");
            if (stockAmount < 1 || stockAmount > 100000)
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock amount must be between 1 and 100,000.");

            ProdID = prodID;
            ProdName = prodName ?? throw new ArgumentNullException(nameof(prodName));
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount = 1)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Increase amount must be at least 1.");
            if (StockAmount + amount > 100000)
                throw new InvalidOperationException("Stock amount cannot exceed 100,000.");

            StockAmount += amount;
        }

        public void DecreaseStock(int amount = 1)
        {
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Decrease amount must be at least 1.");
            if (StockAmount - amount < 1)
                throw new InvalidOperationException("Stock amount cannot be less than 1.");

            StockAmount -= amount;
        }
    }
}
