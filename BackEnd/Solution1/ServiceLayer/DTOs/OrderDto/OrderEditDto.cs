using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderDto
{
    public class OrderEditDto
    {
        public int Id { get; set; }
        public int Cash { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
