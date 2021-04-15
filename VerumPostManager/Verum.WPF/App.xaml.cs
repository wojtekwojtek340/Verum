using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verum.DataAccess;
using Verum.DataAccess.CQRS;
using Verum.DataAccess.CQRS.Queries.Employees;
using Verum.DataAccess.Entities;
using Verum.WPF.Commands;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;
using Verum.WPF.ViewModel;
using Verum.WPF.ViewModel.Factories;

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
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<SentLettersViewModel>();
            services.AddTransient<ReceivedLettersViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddTransient<AddCustomerViewModel>();
            services.AddTransient<AddReceivedLetterViewModel>();
            services.AddTransient<AddSentLetterViewModel>();
            services.AddTransient<EditCustomerViewModel>();
            services.AddTransient<EditReceivedLetterViewModel>();
            services.AddTransient<EditSentLetterViewModel>();

            //CQRS
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            //EntityFramework
            services.AddDbContext<VerumContext>(opt => opt.UseSqlServer("Server=DESKTOP-TH6F0L5;Initial Catalog=VerumDb;User ID=Verum;password=Verum;Integrated Security=True;Trusted_Connection=True;"));

            //Navigation
            services.AddSingleton<IRenavigator, Renavigator>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<ICommand, UpdateViewModelCommand>();

            //ViewModelFactory
            services.AddSingleton<IVerumViewModelFactory, VerumViewModelFactory>();

            //LocalServices
            services.AddSingleton<IPanelsVisibilityService, PanelsVisibilityService>();
            services.AddScoped(typeof(ILocalStorageService<>), typeof(LocalStorageService<>));


            //Delegates
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

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => services.GetRequiredService<LoginViewModel>();
            });

            services.AddSingleton<CreateViewModel<AddCustomerViewModel>>(services =>
            {
                return () => services.GetRequiredService<AddCustomerViewModel>();
            });

            services.AddSingleton<CreateViewModel<AddSentLetterViewModel>>(services =>
            {
                return () => services.GetRequiredService<AddSentLetterViewModel>();
            });

            services.AddSingleton<CreateViewModel<AddReceivedLetterViewModel>>(services =>
            {
                return () => services.GetRequiredService<AddReceivedLetterViewModel>();
            });

            services.AddSingleton<CreateViewModel<EditCustomerViewModel>>(services =>
            {
                return () => services.GetRequiredService<EditCustomerViewModel>();
            });

            services.AddSingleton<CreateViewModel<EditSentLetterViewModel>>(services =>
            {
                return () => services.GetRequiredService<EditSentLetterViewModel>();
            });

            services.AddSingleton<CreateViewModel<EditReceivedLetterViewModel>>(services =>
            {
                return () => services.GetRequiredService<EditReceivedLetterViewModel>();
            });



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
