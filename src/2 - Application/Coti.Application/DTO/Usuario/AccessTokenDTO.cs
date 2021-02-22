using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.DTO
{
    public class AccessTokenDTO
    {
        public string BearerToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
