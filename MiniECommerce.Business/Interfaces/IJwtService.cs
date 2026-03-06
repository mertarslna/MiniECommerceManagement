using Microsoft.Extensions.Configuration;
using MiniECommerce.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Business.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
