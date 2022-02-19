using System;
using System.Collections.Generic;
using System.Text;

namespace KasaSklepowa1
{
    class Warehouse
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public Warehouse()
        {
            Products.Add(new Product
            {
                Barcode = "001",
                Name = "Masło Extra",
                NettoPrice = 6.5m
            });
            Products.Add(new Product
            {
                Barcode = "002",
                Name = "Chleb wiejski",
                NettoPrice = 4.5m
            });
            Products.Add(new Product
            {
                Barcode = "003",
                Name = "Makaron Babuni",
                NettoPrice = 9.2m
            });
            Products.Add(new Product
            {
                Barcode = "004",
                Name = "Dżem truskawkowy",
                NettoPrice = 8.1m
            });
            Products.Add(new Product
            {
                Barcode = "005",
                Name = "Kiełbasa myśliwska",
                NettoPrice = 29.0m
            });
            Products.Add(new Product
            {
                Barcode = "006",
                Name = "Szynka konserwowa",
                NettoPrice = 22.0m
            });
            Products.Add(new Product
            {
                Barcode = "007",
                Name = "Chipsy paprykowe",
                NettoPrice = 6.0m
            });
            Products.Add(new Product
            {
                Barcode = "008",
                Name = "Serek wiejski",
                NettoPrice = 3.5m
            });
            Products.Add(new Product
            {
                Barcode = "009",
                Name = "Sól kuchenna",
                NettoPrice = 2.7m
            });
            Products.Add(new Product
            {
                Barcode = "010",
                Name = "Cukier kryształ",
                NettoPrice = 3.2m
            });
        }
    }
}
