using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Security.Models
{
    public interface IBasePayload
    {
        public string Identifier { get; set; }
    }
}
