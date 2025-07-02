using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        // Статические экземпляры
        public static readonly EquipmentType Printer = new() { Id = 1, Name = "Printer", DisplayName = "Принтер" };
        public static readonly EquipmentType Scanner = new() { Id = 2, Name = "Scanner", DisplayName = "Сканер" };
        public static readonly EquipmentType Monitor = new() { Id = 3, Name = "Monitor", DisplayName = "Монитор" };

        // Список всех типов
        public static readonly List<EquipmentType> All = new() { Printer, Scanner, Monitor };
    }
}
