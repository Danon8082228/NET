//файл IItem.cs
namespace labs
{
    public interface IItem
    {
        //int Id { get; set; } 
        string Name { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
        TypeOfManagement TypeOfManagement { get; set; }
    }

    public enum TypeOfManagement
    {
        Automatic,
        SmartControl,
        Mechanical,
        Electronic
    }
}
