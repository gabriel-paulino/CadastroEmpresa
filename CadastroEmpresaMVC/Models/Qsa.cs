using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEmpresaMVC.Models
{
    public class Qsa
    {
        public int Id { get; set; }
        [JsonProperty("qual")]
        public string Qual { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        public int Cnpj { get; set; }
        [ForeignKey("Cnpj")]
        public virtual Empresa Empresa { get; set; }
    }
}