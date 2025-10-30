using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Globalization;
using labs;
using StoreConsoleApp;
namespace StoreWPFApp
{
    public partial class MainWindow : Window
    {
        private List<IItem> allItems;
        private List<IItem> filteredItems;

        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
            DisplayItems(allItems);
        }

        private void LoadItems()
        {
            allItems = new List<IItem>
            {
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new SmartToasterItem("Samsung SmartToast", 25, 699.99, TypeOfManagement.Automatic, true, true),
                // Добавьте другие товары
            };
            filteredItems = new List<IItem>(allItems);
        }

        private void DisplayItems(List<IItem> items)
        {
            ItemsDataGrid.ItemsSource = null;
            ItemsDataGrid.ItemsSource = items;
        }

        private void ApplyFilterSort_Click(object sender, RoutedEventArgs e)
        {
            string filterText = FilterTextBox.Text.ToLower();
            var query = allItems.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filterText))
            {
                query = query.Where(item => item.Name.ToLower().Contains(filterText));
            }

            if (SortComboBox.SelectedIndex == 0)
            {
                query = query.OrderBy(item => item.Name);
            }
            else if (SortComboBox.SelectedIndex == 1)
            {
                query = query.OrderBy(item => item.Price);
            }

            filteredItems = query.ToList();
            DisplayItems(filteredItems);
        }

        private void TotalPrice_Click(object sender, RoutedEventArgs e)
        {
            double total = filteredItems.Sum(item => item.Price * item.Quantity);
            MessageBox.Show($"Общая стоимость товаров: {total:C}");
        }

        private void ItemCount_Click(object sender, RoutedEventArgs e)
        {
            int count = filteredItems.Count;
            MessageBox.Show($"Количество отображаемых товаров: {count}");
        }
    }
}
