using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public class ProductPrice
    {
        public string ProductName { set; get; }
        public int Price { set; get; }

        public ProductPrice(string ProductName, int Price)
        {
            this.ProductName = ProductName;
            this.Price = Price;
        }
    }

    public class Sample
    {
        private Dictionary<string, string> ProductCategoryMap = new Dictionary<string, string>
        {
            { "オロナミンC", "飲料品"},
            { "からあげ棒", "食料品"},
            { "キリン酎ハイ氷結グレープフルーツ", "酒類"},
            { "リポビタンD", "医薬部外品"}
        };
        public bool TaxCheck(string ProductName)
        {
            return TaxCategory(GetCategory(ProductName));
        }
        public bool TaxCategory(string CategoryName)
        {
            if (CategoryName == "食料品") return true;
            if (CategoryName == "飲料品") return true;
            return false;
        }
        public String GetCategory(string ProductName)
        {
            string CategoryName;
            if (ProductCategoryMap.TryGetValue(ProductName, out CategoryName)) return CategoryName;
            return "その他";
        }
        public int TaxInclusivePrice(string ProductName, int Price)
        {
            if (TaxCategory(GetCategory(ProductName))) return (int)Math.Round(Price * 1.08);
            return (int)Math.Round(Price * 1.1);
        }

        public int TaxInclusivePrice(IList<ProductPrice> items)
        {
            int priceTotal = 0;
            foreach (var productPrice in items)
            {
                priceTotal += TaxInclusivePrice(productPrice.ProductName, productPrice.Price);
            }
            return priceTotal;
        }
    }
}
