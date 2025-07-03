using System.Windows.Input;

namespace OfficeEquipmentManager.Commands
{
    /// <summary>
    /// Реализация ICommand для MVVM, позволяет привязывать методы к элементам UI
    /// </summary>
    public class RelayCommand : ICommand
    {
        // Делегат, который будет выполнен при вызове команды
        private readonly Action<object> _execute;

        // Опциональный делегат, определяющий, можно ли выполнить команду
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Конструктор команды.
        /// </summary>
        /// <param name="execute">Основное действие команды</param>
        /// <param name="canExecute">Условие выполнения команды (необязательно)</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            // Проверяем, что execute не null
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Метод проверяет, можно ли выполнить команду
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Выполняет основное действие команды
        /// </summary>
        public void Execute(object parameter) => _execute(parameter);

        /// <summary>
        /// Событие, которое уведомляет WPF о том, что состояние команды изменилось
        /// Например, если кнопка стала активной/неактивной
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Ручной вызов обновления состояния команды.
        /// Например, когда изменяется свойство в ViewModel, влияющее на доступность команды
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}