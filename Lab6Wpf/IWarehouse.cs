//файл IWarehouse.cs
using System.Collections.Generic;
using labs;

namespace StoreConsoleApp
{
    public interface IWarehouse
    {
        void AddItem(IItem item);
        //IItem GetItemById(int id);
        void ShowItems();
        void AddItems(List<IItem> lst);
    }
}
