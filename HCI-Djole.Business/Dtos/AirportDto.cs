using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public class AirportDto : BaseDto
    {
        public string Label { get; set; }
        public CityDto City { get; set; }
        public long CityId { get; set; }
    }
}