﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
