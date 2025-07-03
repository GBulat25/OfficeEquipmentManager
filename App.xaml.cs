using Microsoft.Extensions.DependencyInjection; // <-- Для DI
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.Storage;
using OfficeEquipmentManager.ViewModels;
using OfficeEquipmentManager.Views;
using System.Windows;

namespace OfficeEquipmentManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<Views.MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация хранилища данных
            services.AddSingleton<IStorage, JsonStorage>();

            // Сервис для работы с оборудованием
            services.AddSingleton<IEquipmentService, EquipmentService>();

            // Регистрация ViewModel
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AddEditViewModel>();

            // Регистрация окон
            services.AddSingleton<MainWindow>();
            services.AddSingleton<AddEditWindow>();
        }
    }
}