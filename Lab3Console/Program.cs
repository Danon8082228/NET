using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using labs;
using static StoreConsoleApp.Shop;

namespace StoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            List<Item> toasters = new List<Item>
            {
                new Item("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new Item("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new Item("KitchenAid KMT4116", 25, 699.99, TypeOfManagement.Automatic, "KitchenAid", "TechWorld"),
                new Item("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Electronic, "Oster", "FreshMarket"),
                new Item("Smeg TSF01", 200, 29.99, TypeOfManagement.Mechanical, "Smeg", "BookWorld"),
            };

            shop.SetItems(toasters);

            shop.ShowItems();
            Console.WriteLine("\n");


            Console.WriteLine("Сортировка по названию с использованием обычного метода:");
            shop.Sort(shop.CompareByName);
            shop.ShowItems();
            Console.WriteLine("\n");



            Console.WriteLine("Сортировка количествву отделений с использованием указателя на метод:");
            Func<Item, Item, int> compareByQuantity = shop.CompareByQuantity;
            shop.Sort(compareByQuantity.Invoke);
            shop.ShowItems();
            Console.WriteLine("\n");


            Console.WriteLine("Сортировка по поставщику с использованием анонимного метода:");
            shop.Sort(delegate (Item a, Item b)
            {
                return a.GetSupplier().CompareTo(b.GetSupplier());
            });
            shop.ShowItems();
            Console.WriteLine("\n");


            Console.WriteLine("Сортировка по типу с использованием лямбда-выражения:");
            shop.Sort((a, b) => a.GetTypeOfManagement().CompareTo(b.GetTypeOfManagement()));
            shop.ShowItems();
            Console.WriteLine("\n");



            shop.FinishedEvent += (sender) =>
            {
                Console.WriteLine("\nСортировка завершена!");
                sender.ShowItems();
            };

            // Асинхронная сортировка
            Console.WriteLine("Асинхронная сортировка по производителю...");
            shop.SortAsync(shop.CompareByBrand);

            // Фоновый процесс
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Ожидание: {i + 1}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Программа завершена.");
        }
    }
}
