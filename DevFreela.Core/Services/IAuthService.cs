using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        public string GenerationJwtToken(string email, string role);
        public string ComputerSha256Hash(string password);
    }
}
