using System;
using System.Collections.Generic;
using labs;

namespace StoreConsoleApp
{
    public class Shop
    {
        private List<Item> _items = new List<Item>();

        public void ShowItems()
        {
            Console.WriteLine($"{"Продукт",-27} | {"Количество отделений",-21} | {"Цена",-11} | {"Тип управления",-14} | {"Производитель",-15} | {"Поставщик",-20} |");
            Console.WriteLine(new string('-', 124));

            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }

        }


        public List<Item> GetItems()
        {
            return _items;
        }

        public void SetItems(List<Item> items)
        {
            _items = items;
        }

        // Абстрактный класс сортировщика
        public abstract class Sorter
        {
            public abstract int Compare(Item X, Item Y);
            public virtual void Sort(List<Item> list)
            {
                list.Sort(Compare);
            }
        }

        // Сортировка по названию
        public class SortByProduct : Sorter
        {
            public override int Compare(Item x, Item y)
            {
                return string.Compare(x.GetName(), y.GetName());
            }
        }

        // Сортировка по цене
        public class SortByPrice : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.GetPrice().CompareTo(Y.GetPrice());
            }

        }

        public class SortBySupplier : Sorter
        {
            public override int Compare(Item x, Item y)
            {
                return x.GetSupplier().CompareTo(y.GetSupplier());
            }
        }

        //пузырьковая сортировка по кол-ву отделений

        public class SortByQuantity : Sorter
        {
            public override void Sort(List<Item> list)
            {
                for (int i = 0; i <= list.Count - 2; i++)
                {
                    for (int j = 0; j <= list.Count - i - 2; j++)
                    {
                        if (Compare(list[j], list[j + 1]) > 0)
                        {
                            Item temp = list[j + 1];
                            list[j + 1] = list[j];
                            list[j] = temp;
                        }
                    }
                }
            }
            public override int Compare(Item x, Item y)
            {
                return x.GetQuantity().CompareTo(y.GetQuantity());
            }
        }

        //сортировка вставками по типу управления
        public class SortByManagemnt : Sorter
        {
            public override void Sort(List<Item> list)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    var key = list[i];
                    int j = i - 1;

                    while (j >= 0 && Compare(list[j], key) > 0)
                    {
                        list[j + 1] = list[j];
                        j--;
                    }
                    list[j + 1] = key;
                }
            }
            public override int Compare(Item x, Item y)
            {
                return x.GetTypeOfManagement().CompareTo(y.GetTypeOfManagement());
            }
        }

        //шейкерная сортировка по производитедю
        public class SortByBrand : Sorter
        {
            public override void Sort(List<Item> list)
            {
                bool swapped = true;
                int start = 0;
                int end = list.Count - 1;

                while (swapped)
                {
                    swapped = false;

                    for (int i = start; i < end; i++)
                    {
                        if (Compare(list[i], list[i + 1]) > 0)
                        {
                            Item temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            swapped = true;
                        }
                    }

                    if (!swapped)
                        break;

                    swapped = false;
                    end--;

                    for (int i = end - 1; i >= start; i--)
                    {
                        if (Compare(list[i], list[i + 1]) > 0)
                        {
                            Item temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            swapped = true;
                        }
                    }
                    start++;
                }
            }
            public override int Compare(Item x, Item y)
            {
                return x.GetBrand().CompareTo(y.GetBrand());
            }
        }

        public void Sortbyname()
        {
            Sorter sorter = new SortByBrand();
            sorter.Sort(_items);
        }

        public void Sortbymanagment()
        {
            Sorter sorter = new SortByManagemnt();
            sorter.Sort(_items);
        }

        public void Sortbyorice()
        {
            Sorter sorter = new SortByPrice();
            sorter.Sort(_items);
        }

        public void Sortbyproduct()
        {
            Sorter sorter = new SortByProduct();
            sorter.Sort(_items);
        }
        public void Sortbyquantity()
        {
            Sorter sorter = new SortByQuantity();
            sorter.Sort(_items);
        }

        public void Sortbysupplier()
        {
            Sorter sorter = new SortBySupplier();
            sorter.Sort(_items);
        }
    }
}
