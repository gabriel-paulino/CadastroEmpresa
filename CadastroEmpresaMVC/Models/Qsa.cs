using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "O Campo Cnpj é obrigatório")]
        public int EmpresaID { get; set; }
        [ForeignKey("EmpresaID")]
        public virtual Empresa Empresa { get; set; }
    }
}