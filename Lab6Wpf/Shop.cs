using System;
using System.Collections.Generic;
using System.Linq;
using labs;

namespace StoreConsoleApp
{
    public class Shop : IShop
    {
        private List<IItem> _items = new List<IItem>();

        public IEnumerable<IItem> GetItems() => _items;

        public void SetItems(List<IItem> items)
        {
            _items = items;
        }

        public void ShowItems()
        {
            foreach (var item in _items)
                Console.WriteLine($"{item.Name} - {item.Price} - {item.Quantity}");
        }

        public void SortByName()
        {
            _items = _items.OrderBy(i => i.Name).ToList();
        }

        public void SortByPrice()
        {
            _items = _items.OrderBy(i => i.Price).ToList();
        }
    }
}
