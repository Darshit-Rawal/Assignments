using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Management_UI.GlobalParameters
{
    public class ProductsParams
    {
        int no_of_product_per_page = 2;
        public int getProduct_per_page()
        {
            return no_of_product_per_page;
        }
    }
}