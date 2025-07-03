using OfficeEquipmentManager.Models;

namespace OfficeEquipmentManager.Services
{
    /// <summary>
    /// Интерфейс для работы с оборудованием.
    /// Реализует CRUD-операции: Получение, Добавление, Редактирование, Удаление
    /// </summary>
    public interface IEquipmentService
    {
        /// <summary>
        /// Получает список всего оборудования из источника данных
        /// </summary>
        List<Equipment> GetAll();

        /// <summary>
        /// Добавляет новое оборудование в хранилище
        /// </summary>
        void Add(Equipment equipment);

        /// <summary>
        /// Обновляет данные существующего оборудования
        /// </summary>
        void Update(Equipment equipment);

        /// <summary>
        /// Удаляет оборудование по Id
        /// </summary>
        void Delete(int id);
    }
}