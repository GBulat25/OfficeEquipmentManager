using OfficeEquipmentManager.Commands;
using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.ViewModels;
using System;
using System.Windows.Input;

public class AddEditViewModel : ViewModelBase
{
    private readonly IEquipmentService _service;
    private Equipment _equipment;

    public Equipment Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            OnPropertyChanged();
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public AddEditViewModel(IEquipmentService service, Equipment equipment = null)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));

        Equipment = equipment ?? new Equipment(
            name: "",
            type: EquipmentType.Printer ?? throw new InvalidOperationException("EquipmentType.Printer is null"),
            status: EquipmentStatus.OnStock ?? throw new InvalidOperationException("EquipmentStatus.OnStock is null")
        );

        SaveCommand = new RelayCommand(OnSave, CanSave);
        CancelCommand = new RelayCommand(OnCancel);
    }

    private void OnSave(object obj)
    {
        OnRequestClose?.Invoke(Equipment);
    }

    private void OnCancel(object obj)
    {
        OnRequestClose?.Invoke(null);
    }

    private bool CanSave(object obj) =>
    !string.IsNullOrWhiteSpace(Equipment?.Name);

    public event Action<Equipment> OnRequestClose;
}