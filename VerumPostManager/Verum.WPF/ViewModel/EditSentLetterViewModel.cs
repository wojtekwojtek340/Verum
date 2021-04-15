using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.CurrentViewModelService;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class EditSentLetterViewModel : BaseViewModel 
    {
        private readonly IRenavigator renavigator;

        public SentLetter SentLetter { get; set; }
        public EditSentLetterViewModel(IPanelsVisibilityService panelsVisibilityService, ILocalStorageService<SentLetter> localStorage, IRenavigator renavigator)
        {
            panelsVisibilityService.PanelsVisibility = false;
            SentLetter = localStorage.Data;
            this.renavigator = renavigator;
        }

        private ICommand editRow;
        public ICommand EditRow
        {
            get
            {
                editRow = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object e) =>
                    {
                        return true;
                    });

                return editRow;
            }
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                cancel = new RelayCommand(
                    (object o) =>
                    {
                        renavigator.Renavigate(ViewType.Sent);
                    },
                    (object e) =>
                    {
                        return true;
                    });

                return cancel;
            }
        }
    }
}
