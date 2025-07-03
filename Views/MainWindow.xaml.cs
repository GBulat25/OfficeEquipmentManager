using OfficeEquipmentManager.ViewModels;
using System.Windows;

namespace OfficeEquipmentManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна
        /// Принимает MainViewModel через внедрение зависимостей
        /// </summary>
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent(); // <-- загружает XAML интерфейс

            // Устанавливаем DataContext, чтобы все элементы могли привязаться к MainViewModel
            DataContext = viewModel;
        }
    }
}