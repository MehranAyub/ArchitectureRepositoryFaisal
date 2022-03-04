using Core.Application.Services.Owners.Dto;
using Core.Data.Entities;
using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Services.Owners
{
    public interface IOwnerRepository 
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(int ownerId);
        OwnerDto GetOwnerWithDetails(int ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
