﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPFDemo.Infrastructure
{
    public interface IAcceleriderUser : IRefreshable
    {
        string Token { get; }

        string Email { get; }

        string Username { get; }

        Uri AvatarUrl { get; }

        IList<string> Apps { get; set; }

        Task<bool> SignOutAsync();

        void Exit();
    }
}
