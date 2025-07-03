using System.Windows;

namespace OfficeEquipmentManager.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditViewModel ViewModel => DataContext as AddEditViewModel;

        public AddEditWindow(AddEditViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnRequestClose += equipment =>
            {
                DialogResult = equipment != null; // устанавливаем результат диалога
                Close(); // закрываем окно
            };
        }
    }
}