using Newtonsoft.Json;

namespace CadastroEmpresa.Serialization
{
    public class Qsa
    {
        [JsonProperty("qual")]
        public string Qual { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
