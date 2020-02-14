using Newtonsoft.Json;

namespace CadastroEmpresa.Serialization
{
    public class AtividadePrincipal
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
