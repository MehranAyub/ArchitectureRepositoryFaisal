using Core.Application.Services.Accounts;
using Core.Application.Services.Owners;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }

        void Save();
    }
}
