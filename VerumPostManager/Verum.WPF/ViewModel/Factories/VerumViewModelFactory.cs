using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel.Factories
{
    public class VerumViewModelFactory : IVerumViewModelFactory
    {
        private readonly CreateViewModel<CustomersViewModel> createCustomersViewModel;
        private readonly CreateViewModel<SentLettersViewModel> createSentLettersViewModel;
        private readonly CreateViewModel<ReceivedLettersViewModel> createReceivedLettersViewModel;

        public VerumViewModelFactory(CreateViewModel<CustomersViewModel> createCustomersViewModel,
            CreateViewModel<SentLettersViewModel> createSentLettersViewModel,
            CreateViewModel<ReceivedLettersViewModel> createReceivedLettersViewModel)
        {
            this.createCustomersViewModel = createCustomersViewModel;
            this.createSentLettersViewModel = createSentLettersViewModel;
            this.createReceivedLettersViewModel = createReceivedLettersViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Customers:
                    return createCustomersViewModel();
                case ViewType.SentLetters:
                    return createSentLettersViewModel();
                case ViewType.ReceivedLetters:
                    return createReceivedLettersViewModel();
                default:
                    throw new ArgumentException("ViewType does not have a viewModel", "viewType");
            }
        }
    }
}
