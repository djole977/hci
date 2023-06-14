using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Data.Models
{
    public class FlightRoute : Base
    {
        public int AirportFromId { get; set; }

        public Airport AirportFrom { get; set; }

        public int AirportToId { get; set; }

        public Airport AirportTo { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
