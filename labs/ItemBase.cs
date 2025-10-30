using System;

namespace labs
{
    public enum TypeOfManagement
    {
        Mechanical,
        Electronic,
        Automatic,
        SmartControl
    }

    public class ItemBase
    {

        private string _name;
        private int _quantity;
        private double _price;
        private TypeOfManagement _typeofmanagement;


        public ItemBase(string name, int quantity, double price, TypeOfManagement typeofmanagement)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
            _typeofmanagement = typeofmanagement;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void SetPrice(double price)
        {
            _price = price;
        }

        public TypeOfManagement GetTypeOfManagement()
        {
            return _typeofmanagement;
        }

        public void SetTypeOfManagement(TypeOfManagement typeofmanagement)
        {
            _typeofmanagement = typeofmanagement;
        }

    }
}
