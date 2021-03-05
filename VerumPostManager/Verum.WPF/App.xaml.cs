using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Verum.DataAccess.CQRS;
using Verum.WPF.State.Navigators;
using Verum.WPF.ViewModel;

namespace Verum.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //ViewModelDelegateRenavigator.cs
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<ViewModelDelegateRenavigator<CustomersViewModel>>();

            //CQRS added
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            //ViewModels added
            services.AddSingleton<CustomersViewModel>();
            services.AddSingleton<SentLettersViewModel>();
            services.AddSingleton<ReceivedLettersViewModel>();

            //VerumViewModelFactory.cs
            services.AddSingleton<CreateViewModel<CustomersViewModel>>(services =>
            {
                return () => services.GetRequiredService<CustomersViewModel>();
            });

            services.AddSingleton<CreateViewModel<SentLettersViewModel>>(services =>
            {
                return () => services.GetRequiredService<SentLettersViewModel>();
            });

            services.AddSingleton<CreateViewModel<ReceivedLettersViewModel>>(services =>
            {
                return () => services.GetRequiredService<ReceivedLettersViewModel>();
            });

            //Main window added
            services.AddScoped<MainWindow>(s => new MainWindow());

            return services.BuildServiceProvider();
        }
    }
}
