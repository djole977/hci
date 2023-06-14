using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public class TicketDto : BaseDto
    {
        public UserDto? Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime BoughtAt { get; set; }
        public FlightDto Flight { get; set; }
        public int FlightId { get; set; }
    }
}