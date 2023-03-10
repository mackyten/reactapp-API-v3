using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Note : BaseDomainEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }
    }
}
