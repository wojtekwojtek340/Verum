using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.WPF.ViewModel
{
    public class SentLettersViewModel : BaseViewModel
    {
        public SentLettersViewModel()
        {
            SentLetter letters = new SentLetter { Id = 1, Attachment = "fds", Comment = "test", Content = "test", Date = DateTime.Now };
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
            CustomerList.Add(letters);
        }

        public ObservableCollection<SentLetter> CustomerList { get; set; } = new ObservableCollection<SentLetter>();
    }
}
