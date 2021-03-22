using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.Entities;

namespace Verum.WPF.ViewModel
{
    public class ReceivedLettersViewModel : BaseViewModel
    {
        public ReceivedLettersViewModel()
        {
            ReceivedLetter letters = new ReceivedLetter { Id = 1, Attachment = "Received", Comment = "Received", Content = "Received", Date = DateTime.Now };
            CustomerList.Add(letters);
        }

        public ObservableCollection<ReceivedLetter> CustomerList { get; set; } = new ObservableCollection<ReceivedLetter>();

        public ReceivedLetter SelectedItem { get; set; }

        private ICommand deleteRowCommand;
        public ICommand DeleteRowCommand
        {
            get
            {
                deleteRowCommand = new RelayCommand(
                    (object o) =>
                    {
                    },
                    (object e) =>
                    {
                        return SelectedItem != null;
                    });

                return deleteRowCommand;
            }
        }
    }
}
