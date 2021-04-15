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
        private readonly CreateViewModel<LoginViewModel> createLoginViewModel;
        private readonly CreateViewModel<AddCustomerViewModel> createAddCustomerViewModel;
        private readonly CreateViewModel<AddSentLetterViewModel> createAddSentLetterViewModel;
        private readonly CreateViewModel<AddReceivedLetterViewModel> createAddReceivedLetterViewModel;
        private readonly CreateViewModel<EditCustomerViewModel> createEditCustomerViewModel;
        private readonly CreateViewModel<EditSentLetterViewModel> createEditSentLetterViewModel;
        private readonly CreateViewModel<EditReceivedLetterViewModel> createEditReceivedLetterViewModel;

        public VerumViewModelFactory(CreateViewModel<CustomersViewModel> createCustomerViewModel,
            CreateViewModel<SentLettersViewModel> createSentLettersViewModel,
            CreateViewModel<ReceivedLettersViewModel> createReceivedLettersViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<AddCustomerViewModel> createAddCustomerViewModel,
            CreateViewModel<AddSentLetterViewModel> createAddSentLetterViewModel,
            CreateViewModel<AddReceivedLetterViewModel> createAddReceivedLetterViewModel,
            CreateViewModel<EditCustomerViewModel> createEditCustomerViewModel,
            CreateViewModel<EditSentLetterViewModel> createEditSentLetterViewModel,
            CreateViewModel<EditReceivedLetterViewModel> createEditReceivedLetterViewModel)
        {
            this.createCustomerViewModel = createCustomerViewModel;
            this.createSentLettersViewModel = createSentLettersViewModel;
            this.createReceivedLettersViewModel = createReceivedLettersViewModel;
            this.createLoginViewModel = createLoginViewModel;
            this.createAddCustomerViewModel = createAddCustomerViewModel;
            this.createAddSentLetterViewModel = createAddSentLetterViewModel;
            this.createAddReceivedLetterViewModel = createAddReceivedLetterViewModel;
            this.createEditCustomerViewModel = createEditCustomerViewModel;
            this.createEditSentLetterViewModel = createEditSentLetterViewModel;
            this.createEditReceivedLetterViewModel = createEditReceivedLetterViewModel;
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
                case ViewType.AddCustomer:
                    return createAddCustomerViewModel();
                case ViewType.AddSentLetter:
                    return createAddSentLetterViewModel();
                case ViewType.AddReceivedLetter:
                    return createAddReceivedLetterViewModel();
                case ViewType.EditCustomer:
                    return createEditCustomerViewModel();
                case ViewType.EditReceivedLetter:
                    return createEditReceivedLetterViewModel();
                case ViewType.EditSentLetter:
                    return createEditSentLetterViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.");
            }
        }
    }
}
