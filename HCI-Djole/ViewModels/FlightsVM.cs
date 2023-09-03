using HCI_Djole.Business.Dtos;

namespace HCI_Djole.ViewModels
{
    public class FlightsVM
    {
        public ICollection<FlightDto> Flights { get; set; }
        public List<FlightCompanyDto> FlightCompaines { get; set; }
        public List<CityDto> Cities { get; set; }
    }
}