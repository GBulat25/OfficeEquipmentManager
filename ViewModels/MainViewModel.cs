using OfficeEquipmentManager.Commands;
using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OfficeEquipmentManager.Services;

namespace OfficeEquipmentManager.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IEquipmentService _service;
        private Equipment _selectedEquipment;

        public ObservableCollection<Equipment> Equipments { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

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
        public MainViewModel(IEquipmentService service)
        {
            _service = service;
            Equipments = new ObservableCollection<Equipment>(_service.GetAll());

            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete, CanEditOrDelete);
        }
        private void OnAdd(object obj)
        {
            // Логика открытия окна добавления
        }

        private void OnEdit(object obj)
        {
            // Логика редактирования выбранного оборудования
        }

        private void OnDelete(object obj)
        {
            if (SelectedEquipment != null)
            {
                _service.Delete(SelectedEquipment.Id);
                Equipments.Remove(SelectedEquipment);
            }
        }

        private bool CanEditOrDelete(object obj) => SelectedEquipment != null;
    }
}
