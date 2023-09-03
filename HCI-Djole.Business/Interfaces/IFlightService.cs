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
        public Task<FlightDto> GetFlightById(int flightId);
        public Task<List<TicketDto>> GetCustomerTickets(string customerId);
        public Task ReserveFlightForCustomer(int flightId, string customerId);
        public Task CancelCustomerFlight(int ticketId, string customerId);
        public Task<List<FlightCompanyDto>> GetAllCompanies();
        public Task<List<CityDto>> GetAllCities();
        public Task<List<FlightDto>> GetFlightsFiltered(FlightsFilterDto filters);
    }
}