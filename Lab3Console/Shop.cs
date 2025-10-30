using System;
using System.Collections.Generic;
using System.Threading;
using labs;
using static StoreConsoleApp.Shop;
using System.Threading.Tasks;

namespace StoreConsoleApp
{
    public class Shop
    {
        private List<Item> _items = new List<Item>();


        // Делегат для сравнения товаров
        public delegate int Compare(Item a, Item b);



        // Делегат и событие завершения сортировки
        public delegate void Finished(Shop sender);
        public event Finished FinishedEvent;

        public void ShowItems()
        {
            Console.WriteLine($"{"Продукт",-27} | {"Количество",-21} | {"Цена",-11} | {"Тип управления",-14} | {"Производитель",-15} | {"Поставщик",-20} |");
            Console.WriteLine(new string('-', 124));

            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public void SetItems(List<Item> items) => _items = items;



        // Метод сортировки с использованием делегата
        public void Sort(Compare compare, bool Descending = false)
        {
            Thread.Sleep(500);
            QuickSort(_items, 0, _items.Count - 1, compare, Descending);
            FinishedEvent?.Invoke(this); // Вызов события после завершения сортировки
        }

        private void QuickSort(List<Item> list, int left, int right, Compare compare, bool Descending)
        {
            if (left >= right) return;

            int pivotIndex = Partition(list, left, right, compare, Descending);
            QuickSort(list, left, pivotIndex - 1, compare, Descending);
            QuickSort(list, pivotIndex + 1, right, compare, Descending);
        }

        private int Partition(List<Item> list, int left, int right, Compare compare, bool Descending)
        {
            Item pivot = list[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                Thread.Sleep(500); // Задержка для демонстрации асинхронности
                int comparison = compare(list[j], pivot);
                if (Descending) comparison = -comparison;

                if (comparison < 0)
                {
                    i++;
                    (list[i], list[j]) = (list[j], list[i]);
                }
            }

            (list[i + 1], list[right]) = (list[right], list[i + 1]);
            return i + 1;
        }


        // Методы-сравнители
        public int CompareByName(Item a, Item b) => string.Compare(a.GetName(), b.GetName());
        public int CompareByPrice(Item a, Item b) => a.GetPrice().CompareTo(b.GetPrice());
        public int CompareByQuantity(Item a, Item b) => a.GetQuantity().CompareTo(b.GetQuantity());
        public int CompareBySupplier(Item a, Item b) => string.Compare(a.GetSupplier(), b.GetSupplier());
        public int CompareByTypeOfManagment(Item a, Item b) => string.Compare(a.GetTypeOfManagement().ToString(), b.GetTypeOfManagement().ToString());
        public int CompareByBrand(Item a, Item b) => string.Compare(a.GetBrand(), b.GetBrand());


        // Асинхронная сортировка

        public void SortAsync(Compare compare, bool Descending = false)
        {
            Task.Run(() => Sort(compare, Descending));
        }




    }
}
