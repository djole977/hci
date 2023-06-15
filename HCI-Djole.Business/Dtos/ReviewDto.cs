using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Djole.Business.Dtos
{
    public class ReviewDto : BaseDto
    {
        [Range(1, 5)]
        public int Grade { get; set; }
        public UserDto? Customer { get; set; }
        public string CustomerId { get; set; }
        public string Comment { get; set; }
    }
}