using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prepaid.Models
{
    public class ChargeViewModel
    {
        public int CreditNumber { get; set; }

        public string Username { get; set; }

        public string Message { get; set; }

        public string MessageType { get; set; }
    }
}