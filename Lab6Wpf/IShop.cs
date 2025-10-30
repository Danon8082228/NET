using System.Collections.Generic;
using labs;

namespace StoreConsoleApp
{
    public interface IShop
    {
        IEnumerable<IItem> GetItems();                  // ← вернуть список
        void SetItems(List<IItem> items);               // ← установить список
        void ShowItems();                               // ← вывод
        void SortByName();                              // ← сортировка по имени
        void SortByPrice();                             // ← сортировка по цене
    }
}
