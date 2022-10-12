using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderDto
{
    public class OrderGetDto
    {
        public int Id { get; set; }
        public int Cash { get; set; }
        public CityDto.CityDto City { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
