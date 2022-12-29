using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTO
{
    public class SignUpResultsDTO
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }    
        public string JWT { get; set; }
    }
}
