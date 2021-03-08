using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Verum.DataAccess;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Queries.Employees;
using Verum.WPF.ViewModel;

namespace Verum.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            //ViewModels added
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CustomersViewModel>();
            services.AddSingleton<SentLettersViewModel>();
            services.AddSingleton<ReceivedLettersViewModel>();
            services.AddSingleton<LoginViewModel>();

            //EF and CQRS added
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddDbContext<VerumContext>(opt => opt.UseSqlServer("Server=DESKTOP-TH6F0L5;Initial Catalog=VerumDb;User ID=Verum;password=Verum;Integrated Security=True;Trusted_Connection=True;"));

            //Start window
            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            serviceProvider = services.BuildServiceProvider();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
