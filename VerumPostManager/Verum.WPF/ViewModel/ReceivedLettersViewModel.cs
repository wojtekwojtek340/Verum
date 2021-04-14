using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verum.DataAccess.Entities;
using Verum.WPF.State.Navigators;

namespace Verum.WPF.ViewModel
{
    public class ReceivedLettersViewModel : BaseViewModel
    {
        private readonly IRenavigator renavigator;
        public ObservableCollection<ReceivedLetter> ReceivedList { get; set; } = new ObservableCollection<ReceivedLetter>();
        public ReceivedLetter SelectedItem { get; set; }

        public ReceivedLettersViewModel(IRenavigator renavigator)
        {
            ReceivedLetter letters = new ReceivedLetter { Id = 1, Attachment = "Received", Comment = "Received", Content = "Received", Date = DateTime.Now };
            ReceivedList.Add(letters);
            this.renavigator = renavigator;
        }        

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
                        renavigator.Renavigate(ViewType.AddRow);
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
