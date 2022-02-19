using System;
using System.Collections.Generic;
using System.Text;

namespace KasaSklepowa1
{
    class Product
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal BruttoPrice
        {
            get { return Math.Round(NettoPrice * 1.23m, 2); }
        }
    }
}
