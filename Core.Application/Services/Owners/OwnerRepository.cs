using Core.Application.Services.Owners.Dto;
using Core.Data;
using Core.Data.Entities;
using Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Services.Owners
{
    public  class OwnerRepository : IOwnerRepository
    {
        RepositoryContext _repositoryContext;
        public OwnerRepository(RepositoryContext repositoryContext)
                                                 
        {
            _repositoryContext = repositoryContext;

        }


        public IEnumerable<Owner> GetAllOwners()
        {

            return _repositoryContext.Owners
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public Owner GetOwnerById(int ownerId)
        {
            return _repositoryContext.Owners.Where(owner => owner.OwnerId.Equals(ownerId))
                .FirstOrDefault();
        }

        public OwnerDto GetOwnerWithDetails(int ownerId)
        {
            //var data= FindByCondition(owner => owner.OwnerId.Equals(ownerId))
            //    .Include(ac => ac.Accounts)
            //    .FirstOrDefault();
            //var data = (from o in GetAll()
            //            where o.OwnerId == ownerId
            //            select new OwnerDto
            //            {
            //                OwnerId = o.OwnerId,
            //                Name = o.Name,
            //                Address = o.Address,
            //                DateOfBirth = o.DateOfBirth,
            //                Accounts = o.Accounts.ToList()

            //            }).FirstOrDefault();

            var query = (from o in _repositoryContext.Owners
                        join b in _repositoryContext.Accounts
                        on o.OwnerId equals b.OwnerId
                        where o.OwnerId==ownerId
                        select new OwnerDto
                        {
                            OwnerId = o.OwnerId,
                            Name = o.Name,
                            Address = o.Address,
                            DateOfBirth = o.DateOfBirth,
                            Accounts = o.Accounts.ToList()

                        }).FirstOrDefault();

            //select new OwnerDto
            //  {
            //      OwnerId = o.OwnerId,
            //      Name = o.Name,
            //      Address = o.Address,
            //      DateOfBirth = o.DateOfBirth,
            //      Accounts = o.Accounts.ToList()

            //  };
            //(from a in DataContext.User
            // join b in DataContext.UserTable on a.UserId equals b.UserId
            // select new
            // {
            //     UserId = a.UserId,
            //     FirstName = b.FirstName
            //     LastName = b.LastName
            // }).ToList();

            return query;
        }

        public void CreateOwner(Owner owner)
        {
            _repositoryContext.Owners.Add(owner);
           
        }

        public void UpdateOwner(Owner owner)
        {

            //Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            //Delete(owner);
        }
    }
}
