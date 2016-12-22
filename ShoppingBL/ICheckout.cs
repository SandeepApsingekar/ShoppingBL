using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    interface ICheckout
    {
        decimal GetTotalCostWithoutOffers(List<Product> products);
    }
}
