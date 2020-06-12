using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoBarber.Application.Config
{
    public class AppSettings
    {
        public string DbAtivo { get; set; }
        public string DbConnection { get; set; }
        public string Email { get; set; }
        public string SMTPPort { get; set; }
        public string JWTKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
    }
}
