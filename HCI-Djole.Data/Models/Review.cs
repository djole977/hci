using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Data.Models
{
    public class Review : Base
    {
        [Range(1, 5)]
        public int Grade { get; set; }
        public IdentityUser? Customer { get; set; }
        public string CustomerId { get; set; }
        public string Comment { get; set; }
    }
}