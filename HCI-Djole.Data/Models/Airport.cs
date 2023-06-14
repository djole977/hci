using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Data.Models
{
    public class Airport : Base
    {
        public string Label { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}