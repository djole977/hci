﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public enum FlightStatus
    {
        Predstojeći = 1,
        Obavljen = 2,
        Otkazan = 3
    }
    public enum FlightReview
    {
        Odličan = 1,
        Neutralan = 2,
        Loš = 3
    }
    public enum FlightClass
    {
        Economy = 1,
        Biznis = 2,
        Prva = 3
    }
    public class FlightDto : BaseDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public FlightClass FlightClass { get; set; }
        public FlightStatus Status { get; set; }
        public FlightRouteDto FlightRoute { get; set; }
        public int FlightRouteId { get; set; }
        public FlightCompanyDto FlightCompany { get; set; }
        public int FlightCompanyId { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}