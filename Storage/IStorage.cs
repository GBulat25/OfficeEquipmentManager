using OfficeEquipmentManager.Models;

namespace OfficeEquipmentManager.Storage
{
    /// <summary>
    /// Интерфейс для работы с хранилищем оборудования
    /// Позволяет абстрагироваться от конкретной реализации (JSON, БД и т.д.)
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Загружает список оборудования из хранилища
        /// </summary>
        List<Equipment> LoadAll();

        /// <summary>
        /// Сохраняет список оборудования в хранилище
        /// </summary>
        void SaveAll(List<Equipment> equipments);
    }
}