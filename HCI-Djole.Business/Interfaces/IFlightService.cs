using HCI_Djole.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Interfaces
{
    public interface IFlightService
    {
        public Task CreateFlight(FlightDto newFlight);
        public Task<List<FlightDto>> GetAll();
    }
}