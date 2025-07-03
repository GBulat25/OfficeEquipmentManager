namespace OfficeEquipmentManager.Models
{
    /// <summary>
    /// Представляет объект "Оборудование" — например, принтер или монитор
    /// </summary>
    public class Equipment
    {
        /// <summary>
        /// Уникальный идентификатор оборудования
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название оборудования (например, "HP LaserJet")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип оборудования (принтер, сканер, монитор)
        /// </summary>
        public EquipmentType Type { get; set; }

        /// <summary>
        /// Статус оборудования (в пользовании, на складе, на ремонте)
        /// </summary>
        public EquipmentStatus Status { get; set; }

        /// <summary>
        /// Конструктор по умолчанию, необходимый для сериализации (JSON / EF Core)
        /// </summary>
        public Equipment()
        { }

        /// <summary>
        /// Основной конструктор для создания нового оборудования
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="type">Тип (Printer, Scanner, Monitor)</param>
        /// <param name="status">Статус (InUse, OnStock, Repairing)</param>
        public Equipment(string name, EquipmentType type, EquipmentStatus status)
        {
            Name = name;
            Type = type;
            Status = status;
        }
    }
}