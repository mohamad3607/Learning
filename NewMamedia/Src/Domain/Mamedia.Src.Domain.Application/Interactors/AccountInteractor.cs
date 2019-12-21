using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Interactors
{
    public class AccountInteractor:IAccountService
    {
        IAccountRepository _repository;
        public AccountInteractor(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Admin AdminLogIn(Admin user)
        {
            return _repository.AdminLogIn(user);
        }
    }
}
