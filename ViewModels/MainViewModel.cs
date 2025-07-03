using OfficeEquipmentManager.Commands;
using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace OfficeEquipmentManager.ViewModels
{
    /// <summary>
    /// ViewModel для главного окна приложения
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IEquipmentService _service;
        private Equipment _selectedEquipment;

        /// <summary>
        /// Список всего оборудования (привязка к DataGrid)
        /// </summary>
        public ObservableCollection<Equipment> Equipments { get; }

        /// <summary>
        /// Команда "Добавить"
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// Команда "Редактировать"
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Команда "Удалить"
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Выбранное оборудование (привязка к SelectedItem в DataGrid)
        /// </summary>
        public Equipment SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged();
                ((RelayCommand)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Конструктор MainViewModel
        /// Загружает данные из сервиса и создаёт команды
        /// </summary>
        public MainViewModel(IEquipmentService service)
        {
            _service = service;
            Equipments = new ObservableCollection<Equipment>(_service.GetAll());

            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete, CanEditOrDelete);
        }

        /// <summary>
        /// Обработчик команды "Добавить"
        /// Открывает форму добавления
        /// При успешном сохранении добавляет запись в список
        /// </summary>
        private void OnAdd(object obj)
        {
            try
            {
                var newEquipment = new Equipment("", EquipmentType.Printer, EquipmentStatus.OnStock);
                var viewModel = new AddEditViewModel(_service, newEquipment);
                var window = new AddEditWindow(viewModel);

                if (window.ShowDialog() == true && viewModel.Equipment != null)
                {
                    Equipments.Add(viewModel.Equipment);
                    _service.Add(viewModel.Equipment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Обработчик команды "Редактировать"
        /// Создаёт копию выбранного оборудования и открывает форму редактирования
        /// При сохранении обновляет данные в списке и хранилище
        /// </summary>
        private void OnEdit(object obj)
        {
            if (SelectedEquipment == null) return;

            var equipmentCopy = new Equipment
            {
                Id = SelectedEquipment.Id,
                Name = SelectedEquipment.Name,
                Type = SelectedEquipment.Type,
                Status = SelectedEquipment.Status
            };

            var addEditViewModel = new AddEditViewModel(_service, equipmentCopy);

            var window = new AddEditWindow(addEditViewModel);
            if (window.ShowDialog() == true)
            {
                _service.Update(window.ViewModel.Equipment);
                var index = Equipments.IndexOf(SelectedEquipment);
                Equipments.RemoveAt(index);
                Equipments.Insert(index, window.ViewModel.Equipment);
            }
        }

        /// <summary>
        /// Обработчик команды "Удалить"
        /// Удаляет запись из списка и хранилища
        /// </summary>
        private void OnDelete(object obj)
        {
            if (SelectedEquipment != null)
            {
                _service.Delete(SelectedEquipment.Id);
                Equipments.Remove(SelectedEquipment);
            }
        }

        /// <summary>
        /// Проверяет, можно ли выполнять команды "Редактировать" и "Удалить"
        /// </summary>
        private bool CanEditOrDelete(object obj) => SelectedEquipment != null;
    }
}