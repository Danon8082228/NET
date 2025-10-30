using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs
{
    public class Item : ItemBase
    {

        private string _brand;
        private string _supplier;


        public Item(string name, int quantity, double price, TypeOfManagement typeofmanagement, string brand, string supplier)
            : base(name, quantity, price, typeofmanagement)
        {
            _brand = brand;
            _supplier = supplier;
        }

        public string GetBrand()
        {
            return _brand;
        }

        public void SetBrand(string brand)
        {
            _brand = brand;
        }

        public string GetSupplier()
        {
            return _supplier;
        }

        public void SetSupplier(string supplier)
        {
            _supplier = supplier;
        }


        public override string ToString()
        {
            return $"{GetName(),-27} | {GetQuantity(),-21} | {GetPrice(),-10}$ | {GetTypeOfManagement(),-14} | {GetBrand(),-15} | {GetSupplier(),-20} |";
        }
    }
}
