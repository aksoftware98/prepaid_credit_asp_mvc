using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prepaid.Models
{
    public class User
    {
        public User()
        {
            Balance = 0;
        }

        public int UserId { get; set; }

        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [StringLength(30)]
        [Required]
        public string PhoneNumber { get; set; }

        public decimal Balance { get; set; }

        public virtual List<Credit> Credits { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
            
    }
}