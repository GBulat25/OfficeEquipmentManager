using OfficeEquipmentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Storga
{
    public interface IStorage
    {
        List<Equipment> LoadAll();
        void SaveAll(List<Equipment> equipments);
    }
}
