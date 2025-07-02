using OfficeEquipmentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeEquipmentManager.Services
{
    public interface IEquipmentService
    {
        List<Equipment> GetAll();
        void Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(int id);
    }
}
