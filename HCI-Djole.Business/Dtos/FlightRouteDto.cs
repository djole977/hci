using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public class FlightRouteDto : BaseDto
    {
        public int AirportFromId { get; set; }
        public AirportDto AirportFrom { get; set; }

        public int AirportToId { get; set; }
        public AirportDto AirportTo { get; set; }

        public ICollection<FlightDto> Flights { get; set; }
    }
}
