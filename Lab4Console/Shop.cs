//файл Shop.cs
using System;
using System.Collections;
using System.Collections.Generic;
using labs;

namespace StoreConsoleApp
{

    public class Shop : IShop, IEnumerable<IItem> //GetEnumerator() и IEnumerable.GetEnumerator() перебирает товары
    {
        private List<IItem> _items = new List<IItem>();
       

        public void SetItems(List<IItem> items) => _items = items;


        public void ShowItems()
        {
            Console.WriteLine($"{"Продукт",-27} | {"Количество",-16} | {"Цена",-12} | {"Тип управления",-14} | {"Производитель",-15} | {"Поставщик",-20} |");
            Console.WriteLine(new string('-', 130));
            foreach (var item in _items)
            {
                Console.WriteLine($"{item}");
            }
        }

        public IEnumerator<IItem> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void SortByName() => _items.Sort((x, y) => string.Compare(x.Name, y.Name));
        public void SortByPrice() => _items.Sort((x, y) => x.Price.CompareTo(y.Price));
    }
}
