//файл Warehouse.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using labs;



public class WarehouseItem
{
    public IItem Item { get; set; }
    public int Id { get; set; }
    public WarehouseItem(IItem item, int id)
    {
        Item = item;
        Id = id;
    }
 }

namespace StoreConsoleApp
{
    //работа со складом как с обычным списком
    public class Warehouse : IWarehouse, IList<WarehouseItem>
    {

        private int _id = 0; // Счетчик ID для товаров
        private List<WarehouseItem> _items = new List<WarehouseItem>();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public WarehouseItem this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public void ShowItems()
        {
            Console.WriteLine($"{"ID",-5} | {"Продукт",-27} | {"Количество",-16} | {"Цена",-12} | {"Тип управления",-14} | {"Производитель",-15} | {"Поставщик",-20} | {"Наличие WIFI"} | {"Наличие TouchScreen"}");
            Console.WriteLine(new string('-', 150));

            foreach (WarehouseItem item in _items)
            {
                Console.WriteLine($"{item.Id,-5} | {item.Item.ToString()}");
            }
        }

        public void AddItem(IItem item)
        {
            _id++;
            WarehouseItem item1 = new WarehouseItem(item, _id);
            _items.Add(item1);
        }

        public void AddItems(List<IItem> lst)
        {
            foreach (IItem item in lst)
            {
                AddItem(item);
            }
        }

        public int IndexOf(WarehouseItem item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, WarehouseItem item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public void Add(WarehouseItem item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(WarehouseItem item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(WarehouseItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(WarehouseItem item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<WarehouseItem> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

    }
}