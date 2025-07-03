using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OfficeEquipmentManager.ViewModels
{
    /// <summary>
    /// Базовый класс для всех ViewModel.
    /// Реализует INotifyPropertyChanged для обновления интерфейса при изменении свойств
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, которое вызывается при изменении любого свойства
        /// Используется WPF для обновления UI
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод, который вызывает обновление UI
        /// Использует CallerMemberNameAttribute, чтобы автоматически определять имя изменившегося свойства
        /// </summary>
        /// <param name="name">Имя свойства, которое изменилось</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            // Вызываем событие с указанием имени свойства
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}