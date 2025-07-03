using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.Storage;

/// <summary>
/// Сервис для работы с оборудованием.
/// Реализует CRUD-операции через IStorage
/// </summary>
public class EquipmentService : IEquipmentService
{
    private readonly IStorage _storage;

    /// <summary>
    /// Конструктор сервиса
    /// </summary>
    /// <param name="storage">Источник данных (JSON, БД и т.д.)</param>
    public EquipmentService(IStorage storage)
    {
        _storage = storage;
    }

    /// <summary>
    /// Получает все записи оборудования из хранилища
    /// </summary>
    public List<Equipment> GetAll()
    {
        return _storage.LoadAll();
    }

    /// <summary>
    /// Добавляет новое оборудование в список
    /// Назначает уникальный Id
    /// </summary>
    public void Add(Equipment equipment)
    {
        var list = _storage.LoadAll();
        equipment.Id = list.Count > 0 ? list.Max(x => x.Id) + 1 : 1;
        list.Add(equipment);
        _storage.SaveAll(list);
    }

    /// <summary>
    /// Обновляет данные оборудования
    /// </summary>
    public void Update(Equipment equipment)
    {
        var list = _storage.LoadAll();
        var index = list.FindIndex(x => x.Id == equipment.Id);
        if (index != -1)
        {
            list[index] = equipment;
            _storage.SaveAll(list);
        }
    }

    /// <summary>
    /// Удаляет оборудование по Id
    /// </summary>
    public void Delete(int id)
    {
        var list = _storage.LoadAll();
        var item = list.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            list.Remove(item);
            _storage.SaveAll(list);
        }
    }
}