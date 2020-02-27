using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.Infrastructure.ServerInteraction
{
    public class LoginApi : IAuthApi
    {
        public LoginResponse LoginIn(LoginArgs args)
        {
            LoginResponse response = new LoginResponse();


            return response;
        }

        public void SignOutAsync(long id)
        {
            return;
        }
    }
}
