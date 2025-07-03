using OfficeEquipmentManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Storage
{
    public  class JsonStorage:IStorage
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "equipment.json");

        public List<Equipment> LoadAll()
        {
            if (!File.Exists(_filePath))
                SaveAll(new List<Equipment>());

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Equipment>>(json);
        }

        public void SaveAll(List<Equipment> equipments)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(equipments, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
