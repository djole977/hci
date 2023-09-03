using AutoMapper;
using HCI_Djole.Business.Dtos;
using HCI_Djole.Business.Interfaces;
using HCI_Djole.Data;
using HCI_Djole.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Services
{
    public class FlightService : IFlightService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FlightService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task CreateFlight(FlightDto newFlight)
        {
            _db.Flights.Add(_mapper.Map<Flight>(newFlight));
            await _db.SaveChangesAsync();
        }
        public async Task<List<FlightDto>> GetAll()
        {
            return _mapper.Map<List<FlightDto>>(await _db.Flights.Include(f => f.FlightCompany)
                .Include(f => f.FlightRoute).ThenInclude(x => x.AirportFrom).ThenInclude(x => x.City)
                .Include(f => f.FlightRoute).ThenInclude(x => x.AirportTo).ThenInclude(x => x.City)
                .ToListAsync());
        }
        public async Task<FlightDto> GetFlightById(int flightId)
        {
            return _mapper.Map<FlightDto>(await _db.Flights.Where(x => x.Id == flightId)
                .Include(x => x.FlightRoute).ThenInclude(x => x.AirportFrom).ThenInclude(x => x.City)
                .Include(x => x.FlightRoute).ThenInclude(x => x.AirportTo).ThenInclude(x => x.City)
                .Include(x => x.Reviews).ThenInclude(x => x.Customer)
                .Include(x => x.FlightCompany).FirstOrDefaultAsync());
        }
        public async Task<List<TicketDto>> GetCustomerTickets(string customerId)
        {
            var tickets = _mapper.Map<List<TicketDto>>(await _db.Tickets.Where(x => x.CustomerId == customerId)
                .Include(x => x.Customer)
                .Include(x => x.Flight).ThenInclude(x => x.Reviews)
                .Include(x => x.Flight).ThenInclude(x => x.FlightCompany)
                .Include(x => x.Flight).ThenInclude(x => x.FlightRoute).ThenInclude(x => x.AirportFrom).ThenInclude(x => x.City)
                .Include(x => x.Flight).ThenInclude(x => x.FlightRoute).ThenInclude(x => x.AirportTo).ThenInclude(x => x.City)
                .ToListAsync());
            foreach(var ticket in tickets)
            {
                if(ticket.Flight.Reviews.Where(r => r.CustomerId == customerId).Any())
                {
                    ticket.IsAlreadyRatedByCustomer = true;
                }
                else
                {
                    ticket.IsAlreadyRatedByCustomer = false;
                }
            }
            return tickets;
        }
        public async Task ReserveFlightForCustomer(int flightId, string customerId)
        {
            var newTicket = new Ticket
            {
                FlightId = flightId,
                CustomerId = customerId,
                BoughtAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            await _db.Tickets.AddAsync(newTicket);
            await _db.SaveChangesAsync();
        }
        public async Task CancelCustomerFlight(int ticketId, string customerId)
        {
            var ticket = await _db.Tickets.Where(x => x.Id == ticketId).FirstOrDefaultAsync();
            if(ticket == null)
            {
                throw new Exception("TICKET NOT FOUND");
            }
            if(ticket.CustomerId == customerId)
            {
                _db.Tickets.Remove(ticket);
                await _db.SaveChangesAsync();
                return;
            }
            throw new Exception("CUSTOMER DOES NOT OWN THE TICKET");
        }
        public async Task<List<FlightCompanyDto>> GetAllCompanies()
        {
            return _mapper.Map<List<FlightCompanyDto>>(await _db.FlightCompanies.ToListAsync());
        }
        public async Task<List<CityDto>> GetAllCities()
        {
            return _mapper.Map<List<CityDto>>(await _db.Cities.ToListAsync());
        }
        public async Task<List<FlightDto>> GetFlightsFiltered(FlightsFilterDto filters)
        {
            var flightClass = (Dtos.FlightClass)Enum.Parse(typeof(Dtos.FlightClass), filters.FlightCategory);
            int classValue = (int)flightClass;
            if(filters.Companies == null)
            {
                return _mapper.Map<List<FlightDto>>(await _db.Flights.Where(x => x.Price >= filters.PriceFrom && x.Price <= filters.PriceTo && 
                x.FlightRoute.AirportFrom.City.Id == filters.CityFrom &&
                x.FlightRoute.AirportTo.City.Id == filters.CityTo && (int)x.FlightClass == classValue).Include(x => x.FlightRoute).ThenInclude(x => x.AirportFrom).ThenInclude(x => x.City)
                .Include(x => x.FlightRoute).ThenInclude(x => x.AirportTo).ThenInclude(x => x.City)
                .Include(x => x.Reviews).ThenInclude(x => x.Customer)
                .Include(x => x.FlightCompany).ToListAsync());
            }
            return _mapper.Map<List<FlightDto>>(await _db.Flights.Where(x => x.Price >= filters.PriceFrom &&  x.Price <= filters.PriceTo &&
                filters.Companies.Contains(x.FlightCompany.Id) && x.FlightRoute.AirportFrom.City.Id == filters.CityFrom &&
                x.FlightRoute.AirportTo.City.Id == filters.CityTo && (int)x.FlightClass == classValue)
                .Include(x => x.FlightRoute).ThenInclude(x => x.AirportFrom).ThenInclude(x => x.City)
                .Include(x => x.FlightRoute).ThenInclude(x => x.AirportTo).ThenInclude(x => x.City)
                .Include(x => x.Reviews).ThenInclude(x => x.Customer)
                .Include(x => x.FlightCompany).ToListAsync());
        }
        public async Task GradeFlight(int flightId, int grade, string comment, string userId)
        {
            var newReview = new Review
            {
                CustomerId = userId,
                FlightId = flightId,
                Comment = comment,
                CreatedAt = DateTime.Now,
                Grade = grade
            };
            await _db.Reviews.AddAsync(newReview);
            await _db.SaveChangesAsync();
        }
    }
}