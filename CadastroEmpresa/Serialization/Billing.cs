using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEmpresa.Serialization
{
    public class Billing
    {
        [JsonProperty("free")]
        public bool Free { get; set; }
        [JsonProperty("database")]
        public bool Database { get; set; }
    }
}
