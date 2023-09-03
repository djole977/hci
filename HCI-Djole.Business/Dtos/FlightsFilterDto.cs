using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public class FlightsFilterDto
    {
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int[] Companies { get; set; }
        public int CityFrom { get; set; }
        public int CityTo { get; set; }
    }
}