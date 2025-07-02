using OfficeEquipmentManager.Commands;
using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.ViewModels;
using System.Windows.Input;

public class AddEditViewModel : ViewModelBase
{
    private Equipment _equipment;
    private readonly IEquipmentService _service;

    public Equipment Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public event Action<Equipment> OnRequestClose;

    public AddEditViewModel(IEquipmentService service, Equipment equipment = null)
    {
        _service = service;
        Equipment = equipment ?? new Equipment("", EquipmentType.Printer, EquipmentStatus.OnStock);

        SaveCommand = new RelayCommand(OnSave, CanSave);
        CancelCommand = new RelayCommand(OnCancel);
    }

    private void OnSave(object obj)
    {
        if (Equipment.Id == 0)
        {
            _service.Add(Equipment);
        }
        else
        {
            _service.Update(Equipment);
        }

        OnRequestClose?.Invoke(Equipment);
    }

    private void OnCancel(object obj)
    {
        OnRequestClose?.Invoke(null);
    }

    private bool CanSave(object obj) =>
        !string.IsNullOrWhiteSpace(Equipment.Name);
}