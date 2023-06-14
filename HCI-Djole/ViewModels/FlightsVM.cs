using HCI_Djole.Business.Dtos;

namespace HCI_Djole.ViewModels
{
    public class FlightsVM
    {
        public ICollection<FlightDto> Flights { get; set; }
    }
}