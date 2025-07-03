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
using OfficeEquipmentManager.Views;
using System.Windows;

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
            try
            {
                var newEquipment = new Equipment("", EquipmentType.Printer, EquipmentStatus.OnStock);
                var viewModel = new AddEditViewModel(_service, newEquipment); 
                var window = new AddEditWindow(viewModel);
                if (window.ShowDialog() == true && viewModel.Equipment != null)
                {
                    Equipments.Add(viewModel.Equipment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.StackTrace}");
            }
        }

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
