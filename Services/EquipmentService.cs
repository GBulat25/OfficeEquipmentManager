using OfficeEquipmentManager.Models;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.Storage;
using System.Collections.Generic;
using System.Linq;

public class EquipmentService : IEquipmentService
{
    private readonly IStorage _storage;

    public EquipmentService(IStorage storage)
    {
        _storage = storage;
    }

    public List<Equipment> GetAll()
    {
        return _storage.LoadAll();
    }

    public void Add(Equipment equipment)
    {
        var list = _storage.LoadAll();
        equipment.Id = list.Count > 0 ? list.Max(x => x.Id) + 1 : 1;
        list.Add(equipment);
        _storage.SaveAll(list);
    }

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