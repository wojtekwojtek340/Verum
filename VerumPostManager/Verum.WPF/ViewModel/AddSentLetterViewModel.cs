using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.Entities;
using Verum.WPF.State.LocalServices.PanelsVisibilityService;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class AddSentLetterViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;

        public SentLetter SentLetter { get; set; } = new SentLetter();

        public AddSentLetterViewModel(IPanelsVisibilityService panelsVisibilityService, IRenavigator renavigator)
        {
            panelsVisibilityService.PanelsVisibility = false;
            this.renavigator = renavigator;
        }

        private ICommand addRow;
        public ICommand AddRow
        {
            get
            {
                addRow = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object e) =>
                    {
                        return true;
                    });

                return addRow;
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
