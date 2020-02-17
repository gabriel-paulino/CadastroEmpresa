using Newtonsoft.Json;

namespace CadastroEmpresa.Serialization
{
    public class AtividadePrincipal
    {
        public int Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
