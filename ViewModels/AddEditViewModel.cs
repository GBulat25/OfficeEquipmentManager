using OfficeEquipmentManager.Commands;
using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.ViewModels;
using System.Windows.Input;

/// <summary>
/// ViewModel для формы добавления или редактирования оборудования
/// </summary>
public class AddEditViewModel : ViewModelBase
{
    private readonly IEquipmentService _service;
    private Equipment _equipment;

    /// <summary>
    /// Оборудование, которое пользователь может добавить или изменить
    /// </summary>
    public Equipment Equipment
    {
        get => _equipment;
        set
        {
            _equipment = value;
            OnPropertyChanged();
            CommandManager.InvalidateRequerySuggested(); // <-- Уведомляем WPF, что состояние команд могло измениться
        }
    }

    /// <summary>
    /// Команда "Сохранить"
    /// </summary>
    public ICommand SaveCommand { get; }

    /// <summary>
    /// Команда "Отмена"
    /// </summary>
    public ICommand CancelCommand { get; }

    /// <summary>
    /// Конструктор для AddEditViewModel
    /// </summary>
    /// <param name="service">Сервис для работы с оборудованием</param>
    /// <param name="equipment">Оборудование (если null — создаётся новое)</param>
    public AddEditViewModel(IEquipmentService service, Equipment equipment = null)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));

        // Если оборудование не передано — создаём новое с дефолтными значениями
        Equipment = equipment ?? new Equipment(
            name: "",
            type: EquipmentType.Printer ?? throw new InvalidOperationException("EquipmentType.Printer is null"),
            status: EquipmentStatus.OnStock ?? throw new InvalidOperationException("EquipmentStatus.OnStock is null")
        );

        // Инициализируем команды
        SaveCommand = new RelayCommand(OnSave, CanSave);
        CancelCommand = new RelayCommand(OnCancel);
    }

    /// <summary>
    /// Выполняется при нажатии "Сохранить"
    /// </summary>
    private void OnSave(object obj)
    {
        OnRequestClose?.Invoke(Equipment); // <-- Передаём обратно обновлённое оборудование
    }

    /// <summary>
    /// Выполняется при нажатии "Отмена"
    /// </summary>
    private void OnCancel(object obj)
    {
        OnRequestClose?.Invoke(null); // <-- Отправляем null, чтобы MainViewModel понял, что операция отменена
    }

    /// <summary>
    /// Проверяет, можно ли выполнить команду "Сохранить"
    /// </summary>
    private bool CanSave(object obj) =>
        !string.IsNullOrWhiteSpace(Equipment?.Name); // <-- Пустое имя — нельзя сохранять

    /// <summary>
    /// Событие для закрытия окна и передачи данных обратно
    /// </summary>
    public event Action<Equipment> OnRequestClose;
}