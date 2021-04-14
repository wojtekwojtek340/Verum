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
        private readonly CreateViewModel<CustomersViewModel> createCustomerViewModel;
        private readonly CreateViewModel<SentLettersViewModel> createSentLettersViewModel;
        private readonly CreateViewModel<ReceivedLettersViewModel> createReceivedLettersViewModel;
        private readonly CreateViewModel<AddRowViewModel> createAddRowViewModel;
        private readonly CreateViewModel<LoginViewModel> createLoginViewModel;
        private readonly CreateViewModel<EditRowViewModel> createEditRowViewModel;

        public VerumViewModelFactory(CreateViewModel<CustomersViewModel> createCustomerViewModel,
            CreateViewModel<SentLettersViewModel> createSentLettersViewModel,
            CreateViewModel<ReceivedLettersViewModel> createReceivedLettersViewModel,
            CreateViewModel<AddRowViewModel> createAddRowViewModel,
            CreateViewModel<EditRowViewModel> createEditRowViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            this.createCustomerViewModel = createCustomerViewModel;
            this.createSentLettersViewModel = createSentLettersViewModel;
            this.createReceivedLettersViewModel = createReceivedLettersViewModel;
            this.createAddRowViewModel = createAddRowViewModel;
            this.createEditRowViewModel = createEditRowViewModel;
            this.createLoginViewModel = createLoginViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Customers:
                    return createCustomerViewModel();
                case ViewType.Sent:
                    return createSentLettersViewModel();
                case ViewType.Received:
                    return createReceivedLettersViewModel();
                case ViewType.Login:
                    return createLoginViewModel();
                case ViewType.AddRow:
                    return createAddRowViewModel();
                case ViewType.EditRow:
                    return createEditRowViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.");
            }
        }
    }
}
