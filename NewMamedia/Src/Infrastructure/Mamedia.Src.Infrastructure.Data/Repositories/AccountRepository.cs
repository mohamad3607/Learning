using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamedia.Src.Infrastructure.Data.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        MamediaDataContext _context;
        public AccountRepository(MamediaDataContext context)
        {
            _context = context;
        }

        public Admin AdminLogIn(Admin user)
        {
            return _context.Admins.Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefault();
        }
    }
}
