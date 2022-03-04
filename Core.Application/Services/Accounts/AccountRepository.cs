using Core.Application.Services.Accounts;
using Core.Data;
using Core.Data.Entities;
using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Services.AccountS
{
   public   class AccountRepository:RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
                                                   :base(repositoryContext)
        {

        }
    }
}
