//файл Program.cs
using System;
using System.Collections.Generic;
using labs;
using StoreConsoleApp;

namespace StoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");

            List<IItem> items = new List<IItem>
            {
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new ToasterItem("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new SmartToasterItem("Samsung SmartToast", 25, 699.99, TypeOfManagement.Automatic,  true, true),
                new SmartToasterItem("Philips TouchToaster", 100, 249.99, TypeOfManagement.Electronic, true, false),
                new ToasterItem("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Mechanical, "Oster", "FreshMarket"),
                new SmartToasterItem("ToastyMaster Pro", 30, 99.99, TypeOfManagement.Mechanical, false, true),
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new ToasterItem("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new ToasterItem("KitchenAid KMT4116", 25, 699.99, TypeOfManagement.Automatic, "KitchenAid", "TechWorld"),
                new ToasterItem("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Electronic, "Oster", "FreshMarket"),
                new ToasterItem("Smeg TSF01", 200, 29.99, TypeOfManagement.Mechanical, "Smeg", "BookWorld"),
                new ToasterItem("Hamilton Beach 22796", 15, 19.95, TypeOfManagement.SmartControl, "Hamilton Beach", "ToyStore"),
                new ToasterItem("KRUPS KH732D50", 20, 250.00, TypeOfManagement.Mechanical, "KRUPS", "GadgetsPlus"),
                new ToasterItem("BLACK+DECKER TR3500SD", 40, 49.99, TypeOfManagement.Automatic, "BLACK+DECKER", "FashionHub"),
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),

            };

            // Создаём магазин и добавляем товары
            IShop shop = new Shop();
            shop.SetItems(items);

            // Выводим список товаров
            Console.WriteLine("Список товаров:");
            shop.ShowItems();

            // Создаём склад и добавляем товары
            IWarehouse warehouse = new Warehouse();
            Console.WriteLine("\nСписок товаров на складе:");
            warehouse.AddItems(items);
            warehouse.ShowItems();

        }
    }
}
