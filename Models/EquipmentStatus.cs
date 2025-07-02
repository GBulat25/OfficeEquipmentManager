using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Models
{
    public class EquipmentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        // статические экземпляры класса
        public static readonly EquipmentStatus InUse = new() { Id = 1, Name = "InUse", DisplayName = "В пользовании" };
        public static readonly EquipmentStatus OnStock = new() { Id = 2, Name = "OnStock", DisplayName = "На складе" };
        public static readonly EquipmentStatus Repairing = new() { Id = 3, Name = "Repairing", DisplayName = "На ремонте" };
        // список всех статусов
        public static readonly List<EquipmentStatus> All = new() { InUse, OnStock, Repairing };

    }
}
