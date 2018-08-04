using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prepaid.Models
{
    public class Credit
    {
        public Credit()
        {
            CreatedDate = DateTime.Now;
            ExpireDate = DateTime.Now.AddDays(30);
            IsAvaliable = true; 
        }

        [Key]
        public int SerialNumber { get; set; }

        public int CreditNumber { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsAvaliable { get; set; }
        
        public DateTime? ActivateDate { get; set; }

        public virtual User User { get; set; }
        
        public int? UserId { get; set; }
    }
}