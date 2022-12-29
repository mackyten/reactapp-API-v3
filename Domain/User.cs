using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   
    public class User : BaseDomainEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Index(IsUnique = true)]
        [Index(nameof(Email), IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
