using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OfficeEquipmentManager.Services;
using OfficeEquipmentManager.Storage;
using OfficeEquipmentManager.ViewModels;
using OfficeEquipmentManager.Views;

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
            services.AddSingleton<IStorage, JsonStorage>();
            services.AddSingleton<IEquipmentService, EquipmentService>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<AddEditViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<AddEditWindow>();
        }
    }
}
