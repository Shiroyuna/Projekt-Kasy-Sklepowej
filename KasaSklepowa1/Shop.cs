using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KasaSklepowa1
{
    
    class Shop
    {
            /* Wyświetl menu
             * 1)pokaż liste produktów
             * 2)zakupy
             *  -zapytaj o dane od użytkowanika
             *   a)jeżeli P: 
             *      -wyświetl paragon
             *   b)w przeciwnym wypadku:
             *      -znajdź produkt po kodzie kreskowym:
             *         -jeżeli produkt istnieje:
             *           a)dodaj do koszyka
             *             -wyświetl nazwe dodanego produktu i cene łączną
             *           b)w innym wypadku:
             *             -wyświetl komunikat o błędzie
             * 3)zakończ program
             */
        public List<string> Cart { get; set; } = new List<string>();

        private bool Menu { get; set; } = true;

        private List<Product> Products { get; set; } = new Warehouse().Products;

        public void DisplayMenu()
        {
            while (Menu)
            {
               MainMenu();
            }
        }

        private void MainMenu()
        {
            Console.WriteLine("KASA SKLEPOWA");
            Console.WriteLine("1. Lista wszystkich produktów");
            Console.WriteLine("2. Zakupy");
            Console.WriteLine("3. Koniec zakupów");
            Console.Write("\r\nWybierz opcję: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ListOfProducts();
                    break;
                case "2":
                    Console.Clear();
                    DisplayShopMenu();
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }

        private void ListOfProducts()
        {
            Console.WriteLine("KOD KRESKOWY I NAZWA PRODUKTU");
            foreach (var p in Products)
            {
                Console.WriteLine(p.Barcode + " " + p.Name);
            }
            Console.Write("\n");
            MainMenu();
        }

        private void DisplayShopMenu()
        {
            Console.WriteLine("WPISZ KOD KRESKOWY PRODUKTU");
            Console.WriteLine("LUB KLIKNIJ 'P' ABY WYŚWIETLIĆ PARAGON");

            string userInput = Console.ReadLine();

            if (userInput == "P")
            {
                DisplayCartSummary();
            }
            else
            {
                var added = AddToCart(userInput);
                Console.Clear();
                if (added)
                {
                    var justAdded = GetProduct(userInput);
                    Console.WriteLine(justAdded.Name);
                    Console.WriteLine(GetCartTotal(GetCartProducts(Cart)));
                }
                else
                {
                    Console.WriteLine("NIEPRAWIDŁOWY KOD KRESKOWY");
                }
                DisplayShopMenu();
            }
        }

        private void DisplayCartSummary()
        {
            var productsInCart = GetCartProducts(Cart);
            Console.Clear();
            Console.WriteLine($@"
---------------------------------
PARAGON

DATA ZAKUPU: {DateTime.Now.ToString("dd/MM/yyyy")}
-------------------------------- -");

            foreach (var product in productsInCart)
            {
                Console.WriteLine(product.Name + " " + product.BruttoPrice);
            }

            Console.WriteLine($@"

-------------------------------- -
DO ZAPŁATY: { GetCartTotal(productsInCart)} zł
            
W TYM VAT: { GetVat(productsInCart)} zł
-------------------------------- - ");

            Console.ReadLine();
            Menu = false;
        }

        private bool AddToCart(string barcode)
        {
            var p = GetProduct(barcode);

            if (p != null)
            {
                Cart.Add(p.Barcode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Product GetProduct(string barcode)
        {
            return Products.Where(x => x.Barcode == barcode).FirstOrDefault();
        }

        private List<Product> GetCartProducts(List<string> barcodelist)
        {
            return barcodelist.Select(x => GetProduct(x)).ToList();
        }

        private decimal GetCartTotal(List<Product> productsInCart)
        {
            return productsInCart.Aggregate(0.0m, (acc, item) => acc + item.BruttoPrice);
        }

        private decimal GetCartTotalNetto(List<Product> productsInCart)
        {
            return productsInCart.Aggregate(0.0m, (acc, item) => acc + item.NettoPrice);
        }

        private decimal GetVat(List<Product> productsInCart)
        {
            return GetCartTotal(productsInCart) - GetCartTotalNetto(productsInCart);
        }
    }
}
    

