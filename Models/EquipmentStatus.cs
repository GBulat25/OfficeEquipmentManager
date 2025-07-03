namespace OfficeEquipmentManager.Models
{
    /// <summary>
    /// Представляет возможный статус оборудования
    /// </summary>
    public class EquipmentStatus
    {
        /// <summary>
        /// Уникальный идентификатор статуса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Техническое имя статуса (например, "InUse", "OnStock")
        /// Используется в коде и JSON
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя статуса (например, "На складе") для интерфейса пользователя
        /// </summary>
        public string DisplayName { get; set; }

        // Статические экземпляры статусов
        /// <summary>
        /// Оборудование находится в использовании
        /// </summary>
        public static readonly EquipmentStatus InUse = new() { Id = 1, Name = "InUse", DisplayName = "В пользовании" };

        /// <summary>
        /// Оборудование хранится на складе
        /// </summary>
        public static readonly EquipmentStatus OnStock = new() { Id = 2, Name = "OnStock", DisplayName = "На складе" };

        /// <summary>
        /// Оборудование на ремонте
        /// </summary>
        public static readonly EquipmentStatus Repairing = new() { Id = 3, Name = "Repairing", DisplayName = "На ремонте" };

        /// <summary>
        /// Список всех доступных статусов
        /// Используется в ComboBox в интерфейсе
        /// </summary>
        public static readonly List<EquipmentStatus> All = new() { InUse, OnStock, Repairing };
    }
}