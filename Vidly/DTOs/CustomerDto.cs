using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //exclude because this is domail class and here that property is create dependency from Dto to domain model
        //if we change this prop that impact Dto
        //public MembershipType MembershipType { get; set; }  

        public byte MembershipTypeId { get; set; }  

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; } 
    }
}