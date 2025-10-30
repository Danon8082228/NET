using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StoreConsoleApp;
using labs;
using System.Windows.Shapes;

namespace Lab6Wpf
{
    public partial class MainWindow : Window
    {
        private List<IItem> _allItems;
        private IEnumerable<IItem> _filteredItems;
        private IShop shop;
        private IWarehouse warehouse;

        public MainWindow()
        {
            InitializeComponent();
            shop = new Shop();
            warehouse = new Warehouse();
            LoadItems();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void LoadItems()
        {
            _allItems = new List<IItem>
            {
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new ToasterItem("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new SmartToasterItem("Samsung SmartToast", 25, 699.99, TypeOfManagement.Automatic,  true, true),
                new SmartToasterItem("Philips TouchToaster", 100, 249.99, TypeOfManagement.Electronic, true, false),
                new ToasterItem("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Mechanical, "Oster", "FreshMarket"),
                new SmartToasterItem("ToastyMaster Pro", 30, 99.99, TypeOfManagement.Mechanical, false, true),
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new ToasterItem("Cuisinart CPT-180", 50, 19.99, TypeOfManagement.SmartControl, "Cuisinart", "FashionHub"),
                new ToasterItem("KitchenAid KMT4116", 25, 699.99, TypeOfManagement.Automatic, "KitchenAid", "TechWorld"),
                new ToasterItem("Oster TSSTTRJBG1", 100, 1.29, TypeOfManagement.Electronic, "Oster", "FreshMarket"),
                new ToasterItem("Smeg TSF01", 200, 29.99, TypeOfManagement.Mechanical, "Smeg", "BookWorld"),
                new ToasterItem("Hamilton Beach 22796", 15, 19.95, TypeOfManagement.SmartControl, "Hamilton Beach", "ToyStore"),
                new ToasterItem("KRUPS KH732D50", 20, 250.00, TypeOfManagement.Mechanical, "KRUPS", "GadgetsPlus"),
                new ToasterItem("BLACK+DECKER TR3500SD", 40, 49.99, TypeOfManagement.Automatic, "BLACK+DECKER", "FashionHub"),
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
                new ToasterItem("Breville BTA820XL", 10, 1500.00, TypeOfManagement.Automatic, "Breville", "BestTech"),
            };

            foreach (var item in _allItems)
            {
                warehouse.AddItem(item);
                shop.GetItems().ToList().Add(item);
            }
        }

        private void ApplyFilter()
        {
            _filteredItems = GetFilteredItems();  // Получение отфильтрованных товаров
            ItemsDataGrid.ItemsSource = _filteredItems.ToList();  // Отображение отфильтрованных товаров в DataGrid
        }

        //Получение отфильтрованных товаров
        private IEnumerable<IItem> GetFilteredItems()
        {
            //Считывание значений с пользовательского интерфейса
            string keyword = FilterTextBox.Text.ToLower().Trim();
            string priceMinText = PriceMinTextBox.Text;
            string priceMaxText = PriceMaxTextBox.Text;
            string selectedType = (ManagementTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string brand = BrandTextBox.Text.ToLower().Trim();
            string supplier = SupplierTextBox.Text.ToLower().Trim();
            bool? wifiRequired = WifiCheckBox.IsChecked;
            bool? touchRequired = TouchCheckBox.IsChecked;

            //парсинг цен
            bool hasMin = double.TryParse(priceMinText, out double priceMin);
            bool hasMax = double.TryParse(priceMaxText, out double priceMax);

            //Фильтрация товаров с использованием линк
            return _allItems
                // Фильтрация по ключевому слову в названии (если введено).
                .Where(i => string.IsNullOrEmpty(keyword) || i.Name.ToLower().Contains(keyword))

                // Фильтрация по минимальной цене
                .Where(i => !hasMin || i.Price >= priceMin)

                // Фильтрация по максимальной цене
                .Where(i => !hasMax || i.Price <= priceMax)

                // Фильтрация по типу управления.
                .Where(i => selectedType == "Все" || i.TypeOfManagement.ToString() == selectedType)

                //Проверяем, что товар — это ToasterItem и бренд содержит введённый текст.
                .Where(i => string.IsNullOrEmpty(brand) || (i as ToasterItem)?.Brand?.ToLower().Contains(brand) == true)

                .Where(i => string.IsNullOrEmpty(supplier) || (i as ToasterItem)?.Supplier?.ToLower().Contains(supplier) == true)

                .Where(i => wifiRequired == false || (i is SmartToasterItem s && s.HasWifi))

                .Where(i => touchRequired == false || (i is SmartToasterItem s && s.HasTouchScreen));
        }


        private void FilterButton_Click(object sender, RoutedEventArgs e) => ApplyFilter();

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Clear();
            PriceMinTextBox.Clear();
            PriceMaxTextBox.Clear();
            BrandTextBox.Clear();
            SupplierTextBox.Clear();
            WifiCheckBox.IsChecked = false;
            TouchCheckBox.IsChecked = false;
            ManagementTypeComboBox.SelectedIndex = 0;
            SortFieldComboBox.SelectedIndex = 0;
            SortOrderComboBox.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ShowSummary_Click(object sender, RoutedEventArgs e)
        {
            int count = _filteredItems.Count();
            double totalPrice = _filteredItems.Sum(item => item.Price);
            MessageBox.Show($"Всего товаров: {count}\nОбщая стоимость: {totalPrice:C2}", "Сводка");
        }

        private void ShowCountByType_Click(object sender, RoutedEventArgs e)
        {
            var grouped = _filteredItems.GroupBy(i => i.TypeOfManagement) //товары по типу подключения группируюся с помощью групбай
                                         // Формируем строку для каждой группы типа управления
                                         .Select(g => $"{g.Key}: {g.Count()}");

            MessageBox.Show(string.Join("\n", grouped), "Количество по типам управления");
        }


        private void ShowFirstFiveItems_Click(object sender, RoutedEventArgs e)
        {
            var items = _filteredItems.Take(5).Select(i => i.Name);
            MessageBox.Show("Первые 5 товаров:\n" + string.Join("\n", items), "Первые 5 товаров");
        }

        private void ShowUniqueItems_Click(object sender, RoutedEventArgs e)
        {
            //Select создает колллекцию строк состящую только из назавний товаров
            //distinct удаляет повторяющиеся элементы из коллекции, оставляя только уникальные
            var uniqueNames = _filteredItems.Select(i => i.Name).Distinct();
            MessageBox.Show("Уникальные товары:\n" + string.Join("\n", uniqueNames), "Уникальные товары");
        }

        //Сортировка товаров
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранное поле для сортировки из выпадающего списка
            string selectedField = (SortFieldComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Получаем выбранный порядок сортировки из выпадающего списка
            string sortOrder = (SortOrderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // выбираем сво-во по которому будет сортировка. keySelector для сортировки
            Func<IItem, object> keySelector = selectedField switch
            {
                "Название" => i => i.Name,

                "Производитель" => i => (i as ToasterItem)?.Brand ?? "",

                "Поставщик" => i => (i as ToasterItem)?.Supplier ?? "",

                "Цена" => i => i.Price,

                "Количество" => i => i.Quantity,

                // по умолчанию по имени
                _ => i => i.Name
            };

            // В зависимости от выбранного порядка сортировки (по возрастанию или по убыванию)
            _filteredItems = sortOrder switch
            {
                "По возрастанию" => _filteredItems.OrderBy(keySelector),

                "По убыванию" => _filteredItems.OrderByDescending(keySelector),

                // Если порядок не выбран или задан некорректно, не изменяем сортировку
                _ => _filteredItems
            };

            ItemsDataGrid.ItemsSource = _filteredItems.ToList();
        }
    }
}
            