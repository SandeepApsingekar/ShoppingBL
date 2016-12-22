using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public class CheckoutService:ICheckout
    {
        public decimal GetTotalCostWithoutOffers(List<Product> products)
        {
            decimal totalCost = 0.0m;
            int totalApples = 0;
            decimal applePrice = 0.0m;
            decimal orangePrice = 0.0m;
            int totalOranges = 0;

            // making a dictonary so that we can chek the uniqueness of the products and throw any exception if two keys are same
            // i.e same product with different prices
            var productPrice = products.GroupBy(p => new { p.Name, p.Price })
                .ToDictionary(pd => pd.Key.Name, (pd) => (pd.Key.Price));

            if (products.Any())
            {
                // we are assuming that customer put number of products (apples and oranges) he wants in the basket
                // find total number of apples and oranges
                // Right now the logic is checking for only apples and oranges, ideally these should come from a repository and should not be hard-coded
                foreach (var product in products)
                {
                    if (product.Name == "Apple")
                    {
                        totalApples++;
                    }
                    if (product.Name == "Orange")
                    {
                        totalOranges++;
                    }
                }

                foreach (var p in productPrice)
                {
                    if (p.Key == "Apple")
                    {
                        applePrice = p.Value;
                    }
                    if (p.Key == "Orange")
                    {
                        orangePrice = p.Value;
                    }
                }

                totalCost += (totalApples * applePrice) + (totalOranges * orangePrice);
            }

            return totalCost;
        }
    }
}