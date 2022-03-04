using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data.Entities
{
  public  class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "Owner Id is required")] 
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
