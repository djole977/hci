using AutoMapper;
using HCI_Djole.Business.Dtos;
using HCI_Djole.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Airport, AirportDto>().ReverseMap();
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<IdentityUser, UserDto>().ReverseMap();
        }
    }
}