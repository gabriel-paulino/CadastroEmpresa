using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEmpresaMVC.Models
{
    public class AtividadesSecundaria
    {
        public int Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        public int Cnpj { get; set; }
        [ForeignKey("Cnpj")]
        public virtual Empresa Empresa { get; set; }
    }
}