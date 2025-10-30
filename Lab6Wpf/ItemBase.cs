//файл ItemBase.cs
using System;

namespace labs
{
    public abstract class ItemBase : IItem, ICloneable, IComparable<IItem>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public TypeOfManagement TypeOfManagement { get; set; }


        //шаблонный метод
        protected abstract string GetDescription();
        //запечатанный to string
        public sealed override string ToString() => GetDescription();

        public object Clone() => MemberwiseClone(); //реализация ICloneable создает поверхностную копию объекта

        public int CompareTo(IItem other) // реализация IComparable сравнивает 2 товара по цене
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }
    }
}
