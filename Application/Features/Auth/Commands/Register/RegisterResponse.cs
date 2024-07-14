using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
