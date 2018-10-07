using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NewRentalDto
    {
        public byte CustomerId { get; set; }
        public List<int> MovieId { get; set; }
    }
}