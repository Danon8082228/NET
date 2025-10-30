using System;
using System.Collections.Generic;
using System.Globalization;
using labs;
using static StoreConsoleApp.Shop;

namespace StoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop items = new Shop(); // создание объекта shop
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            List<Item> tosters = new List<Item>
            {
                new Item("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new Item("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new Item("KitchenAid KMT4116", 25, 699.99, TypeOfManagement.Automatic, "KitchenAid", "TechWorld"),
                new Item("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Electronic, "Oster", "FreshMarket"),
                new Item("Smeg TSF01", 200, 29.99, TypeOfManagement.Mechanical, "Smeg", "BookWorld"),
                new Item("Hamilton Beach 22796", 15, 19.95, TypeOfManagement.SmartControl, "Hamilton Beach", "ToyStore"),
                new Item("KRUPS KH732D50", 20, 250.00, TypeOfManagement.Mechanical, "KRUPS", "GadgetsPlus"),
                new Item("BLACK+DECKER TR3500SD", 40, 49.99, TypeOfManagement.Automatic, "BLACK+DECKER", "FashionHub"),
                new Item("Dash Clear View Toaster", 80, 3.49, TypeOfManagement.Electronic, "Dash", "SuperMart"),
                new Item("Dualit Classic 4-Slice", 150, 12.99, TypeOfManagement.SmartControl, "Dualit", "BookStore"),
                new Item("Russell Hobbs 2-Slice Retro", 5, 499.99, TypeOfManagement.Mechanical, "Russell Hobbs", "TechShop"),
                new Item("Mueller UltraToast", 30, 15.00, TypeOfManagement.Mechanical, "Mueller", "ToyStore"),
                new Item("De’Longhi Distinta", 60, 89.99, TypeOfManagement.Electronic, "De’Longhi", "SoundWorld"),
                new Item("Oster 4-Slice Long Slot", 20, 120.00, TypeOfManagement.SmartControl, "Oster", "FashionHub"),
                new Item("REDMOND 4-Slice", 150, 0.99, TypeOfManagement.Automatic, "REDMOND", "FreshMarket")
            };

            items.SetItems(tosters); //передача списка товаров 

            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по названию:");
            items.Sortbyproduct();
            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по типу подключения:");
            items.Sortbymanagment();
            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по производителю:");
            items.Sortbyname();
            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по цене:");
            items.Sortbyorice();
            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по количесвту отделений:");
            items.Sortbyquantity();
            items.ShowItems();
            Console.WriteLine("\n");

            Console.WriteLine("Сортировка по поставщику:");
            items.Sortbysupplier();
            items.ShowItems();
            Console.WriteLine("\n");
        }
    }
}
