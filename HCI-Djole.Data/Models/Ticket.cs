using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Data.Models
{
    public class Ticket : Base
    {
        public IdentityUser? Customer { get; set; }
        public DateTime BoughtAt { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
    }
}