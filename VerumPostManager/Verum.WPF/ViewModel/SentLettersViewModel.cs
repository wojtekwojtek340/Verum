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
    public class SentLettersViewModel : BaseViewModel
    {
        public SentLettersViewModel()
        {
            SentLetter letters = new SentLetter { Id = 1, Attachment = "Sent", Comment = "Sent", Content = "Sent", Date = DateTime.Now };
            SentList.Add(letters);

        }

        public ObservableCollection<SentLetter> SentList { get; set; } = new ObservableCollection<SentLetter>();

        public SentLetter SelectedItem { get; set; }

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

        private ICommand addRowCommand;

        public ICommand AddRowCommand
        {
            get
            {
                addRowCommand = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object e) =>
                    {
                        return true;
                    });

                return addRowCommand;
            }
        }
    }
}
