using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo
{
    public class LoginViewModel: BindableBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public DelegateCommand LoginInCommand { get; private set; }

        public LoginViewModel()
        {
            LoginInCommand = new DelegateCommand(LoginIn);
        }

        public void LoginIn()
        {
            if (string.IsNullOrEmpty(UserName))
            {
            }
            else if (string.IsNullOrEmpty(Password))
            { 
                
            }
        }
    }
}
