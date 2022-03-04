using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Services.Owners.Dto
{
    
        public class OwnerDto
        {
            
            public int OwnerId { get; set; }

            public string Name { get; set; }

            public DateTime DateOfBirth { get; set; }

            public string Address { get; set; }

            public List<Account> Accounts { get; set; }
        }
    }
