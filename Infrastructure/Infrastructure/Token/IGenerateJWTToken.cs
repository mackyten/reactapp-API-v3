using Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Token
{
    public interface IGenerateJWTToken
    {
        public string Generate(User user);
    }
}
