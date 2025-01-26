using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_eCommerce
{
    public class Products
    {
        int ProdID { get; set; }
        string ProdName { get; set; }
        int ItemPrice { get; set; }
        int StockAmount { get; set; }

        public Products(int prodID, string prodName, int itemPrice, int stockAmount) { 
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock()
        {
            if (StockAmount < 100000) { StockAmount++; }            
        }

        public void DecreaseStock()
        {
            if (StockAmount > 1) { StockAmount--; }
        }
    }
}
