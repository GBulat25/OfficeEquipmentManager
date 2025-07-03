namespace OfficeEquipmentManager.Models
{
    /// <summary>
    /// Представляет возможный тип оборудования (принтер, сканер, монитор)
    /// </summary>
    public class EquipmentType
    {
        /// <summary>
        /// Уникальный идентификатор типа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Техническое имя типа (например, "Printer", "Scanner")
        /// Используется в коде и JSON
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя типа (например, "Принтер") для интерфейса пользователя
        /// </summary>
        public string DisplayName { get; set; }

        // Статические экземпляры типов
        /// <summary>
        /// Оборудование типа "Принтер"
        /// </summary>
        public static readonly EquipmentType Printer = new() { Id = 1, Name = "Printer", DisplayName = "Принтер" };

        /// <summary>
        /// Оборудование типа "Сканер"
        /// </summary>
        public static readonly EquipmentType Scanner = new() { Id = 2, Name = "Scanner", DisplayName = "Сканер" };

        /// <summary>
        /// Оборудование типа "Монитор"
        /// </summary>
        public static readonly EquipmentType Monitor = new() { Id = 3, Name = "Monitor", DisplayName = "Монитор" };

        /// <summary>
        /// Список всех доступных типов оборудования
        /// Используется в ComboBox в интерфейсе
        /// </summary>
        public static readonly List<EquipmentType> All = new() { Printer, Scanner, Monitor };
    }
}