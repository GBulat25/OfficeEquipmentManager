using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public EquipmentStatus Status { get; set; }
        public Equipment() { }
        public Equipment(string name, EquipmentType type, EquipmentStatus status)
        {
            Name = name;
            Type = type;
            Status = status;
        }
    }
}
