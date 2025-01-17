﻿using System.Collections.ObjectModel;
using System.Linq;
using AppAdminPanel.Commands;
using AppAdminPanel.ViewModel;
using AppLibrary.Data;
using AppLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmnPanel.ViewModel
{
    internal class UserViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        

        public ObservableCollection<User> Users
        {
            get => _users;
            set { _users = value;OnPropertyChanged(); }
        
        }

        

        public UserViewModel()
        {
            LoadUsers();
            BackCommand = new RelayCommand(BackCommandExecute);
        }

        private void LoadUsers()
        {
            using (var context = new MyDbContext())
            {
                var users = context.Users
          .Include(u => u.Photo) 
          .ToList();
                Users = new ObservableCollection<User>( users);



            }
        }
    }
}
