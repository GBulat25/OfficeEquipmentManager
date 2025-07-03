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
        Console.WriteLine("OnSave вызван");
        OnRequestClose?.Invoke(Equipment);
    }

    private void OnCancel(object obj)
    {
        OnRequestClose?.Invoke(Equipment);
    }

    private bool CanSave(object obj)
    {
        var canSave = !string.IsNullOrWhiteSpace(Equipment?.Name);
        Console.WriteLine($"CanSave: {canSave}, Name: '{Equipment?.Name}'");
        return canSave;
    }

    public event Action<Equipment> OnRequestClose;
}