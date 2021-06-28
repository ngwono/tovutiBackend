using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TovutiBackend.Models
{
    public class Product
    {
        public string id { get; set; }
        public string category { get; set; }
        public string product_type { get; set; }
        public string description { get; set; }
        public string attribute1 { get; set; }
        public string attribute2 { get; set; }
        public string categoryDesc { get; set; }
        public string typeDesc { get; set; }
        public string attribute1Desc { get; set; }
        public string attribute2Desc { get; set; }
        public List<String> productList { get; set; }
        public List<String> productListDesc { get; set; }
        public string price { get; set; }
        public string productDesc { get; set; }
    }
}