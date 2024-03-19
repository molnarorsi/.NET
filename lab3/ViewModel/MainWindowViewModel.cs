using lab3.Command;
using lab3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<User> userList;

        private User selectedUser;
        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand ClearListCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private AddItemViewModel addItemViewModel = new AddItemViewModel();

        public MainWindowViewModel()
        {
            this.UserList = new ObservableCollection<User>();
            this.LoadDataCommand = new RelayCommand(this.LoadDataCommandExecute);
            this.ClearListCommand = new RelayCommand(this.ClearListCommandExecute);
            this.DeleteItemCommand = new RelayCommand(this.DeleteItemCommandExecute);
            this.AddItemCommand = new RelayCommand(this.AddItemCommandExecute);
            this.UpdateCommand = new RelayCommand(this.UpdateCommandExecute);
            
            this.viewModel = new AddItemViewModel();
            Instance = this;
        }

        private void AddItemCommandExecute()
        {
            this.addItemViewModel.NewUser.UserId = this.userList.Count + 1;
            ViewService.ShowDialog(addItemViewModel);
        }

        private void DeleteItemCommandExecute()
        {
            if (this.SelectedUser != null)
            {
                this.userList.Remove(this.SelectedUser);
            }
        }

        private void ClearListCommandExecute()
        {
            this.userList.Clear();
        }

        private void UpdateCommandExecute()
        {
            if (this.userList.Count > 0)
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(@"D:\UNIVERSITY\NEGYEDEV\MASODIK FELEV\.NET\lab3\User Data.txt"))
            {
                foreach(User user in this.UserList)
                {
                    writer.WriteLine(user.ToString());
                }
            }

        }

        private void LoadDataCommandExecute()
        {
            if (this.userList.Count > 0)
            {
                return;
            }

            foreach (string line in System.IO.File.ReadLines(@"D:\UNIVERSITY\NEGYEDEV\MASODIK FELEV\.NET\lab3\User Data.txt"))
            {
                string[] words = line.Split(',');

                User user = new User();
                user.UserId = Int32.Parse(words[0]);
                user.FirstName = words[1];
                user.LastName = words[2];
                user.City = words[3];
                user.State = words[4];
                user.Country = words[5];

                this.userList.Add(user);
            }
        }

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                this.RaisePropertyChanged();
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
