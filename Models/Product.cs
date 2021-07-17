using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipcart.Models
{
    public class Product
    {
        public int PRODUCT_ID { set; get; }
        public string NAME { set; get;}
        public string DESCRIPTION { set; get; }
        public decimal PRICE { set; get; }
    }
}