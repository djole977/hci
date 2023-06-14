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
    }
}