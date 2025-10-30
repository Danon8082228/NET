//файл ToasterItem.cs
namespace labs
{
    public class ToasterItem : ItemBase
    {
        public string Brand {  get; set; }
        public string Supplier { get; set; }
        public ToasterItem(string name, int quantity, double price, TypeOfManagement type, string brand, string supplier)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            TypeOfManagement = type;
            Brand = brand;
            Supplier = supplier;
        }

        protected override string GetDescription()
        {
            return $"{Name,-27} | {Quantity,-16} | {Price,-10:F2} $ | {TypeOfManagement,-14} | {Brand,-15} | {Supplier,-20} | {"-",-12} | { "-",-20}";
        }
    }
}
