//файл SmartToasterItem.cs
namespace labs
{
    public class SmartToasterItem : ItemBase
    {
        public bool HasWifi { get; set; }
        public bool HasTouchScreen { get; set; }

        public SmartToasterItem(string name, int quantity, double price, TypeOfManagement type, bool hasWifi, bool hasTouchScreen)

        {
            Name = name;
            Quantity = quantity;
            Price = price;
            TypeOfManagement = type;
            HasWifi = hasWifi;
            HasTouchScreen = hasTouchScreen;
        }

        protected override string GetDescription()
        {
            return $"{Name,-27} | {Quantity,-16} | {Price,-10:F2} $ | {TypeOfManagement,-14} | {"-",-15} | {"-",-20} | {HasWifi,-12} | {HasTouchScreen,-23}";
        }
    } 
}
