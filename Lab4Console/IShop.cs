//файл IShop.cs
using System.Collections.Generic;

namespace StoreConsoleApp
{
    public interface IShop
    {
        void SetItems(List<labs.IItem> items); //заполнить массив
        void ShowItems();
        void SortByName();
        void SortByPrice();
    }
}
