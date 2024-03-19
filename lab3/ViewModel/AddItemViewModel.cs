using lab3.Command;
using lab3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.ViewModel
{
    public class AddItemViewModel : ViewModelBase
    {
        public RelayCommand SaveDataCommand { get; set; }

        private User newUser;

        public User NewUser
        {
            get { return newUser; }
            set
            {
                newUser = value;
                this.RaisePropertyChanged();
            }
        }
        public AddItemViewModel()
        {
            newUser = new User();
            this.SaveDataCommand = new RelayCommand(this.SaveDataCommandExecute);
        }

        private void SaveDataCommandExecute()
        {
            Instance.UserList.Add(NewUser);
            ViewService.CloseDialog(this);
        }
    }
}
