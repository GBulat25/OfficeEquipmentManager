using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
