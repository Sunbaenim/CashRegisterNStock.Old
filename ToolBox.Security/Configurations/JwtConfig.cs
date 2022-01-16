using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Security.Configurations
{
    public class JwtConfig
    {
        public string Signature { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Validity { get; set; } //ms
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifeTime { get; set; }
    }
}
