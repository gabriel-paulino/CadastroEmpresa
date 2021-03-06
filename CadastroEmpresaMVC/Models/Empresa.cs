﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroEmpresaMVC.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        [JsonProperty("nome")]
        [Required(ErrorMessage = "O Campo Nome é obrigatório")]
        public string Nome { get; set; }
        [JsonProperty("cnpj")]
        [Required(ErrorMessage = "O Campo Cnpj é obrigatório")]
        public string Cnpj { get; set; }
        //[JsonProperty("atividade_principal")]
        //public virtual List<AtividadePrincipal> AtividadePrincipals { get; set; }
        [JsonProperty("data_situacao")]
        public string DataSituacao { get; set; }
        [JsonProperty("efr")]
        public string Efr { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        //[JsonProperty("atividades_secundarias")]
        //public virtual List<AtividadesSecundaria> AtividadesSecundarias { get; set; }
        //[JsonProperty("qsa")]
        //public virtual List<Qsa> Qsas { get; set; }
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("numero")]
        public string Numero { get; set; }
        [JsonProperty("cep")]
        public string Cep { get; set; }
        [JsonProperty("municipio")]
        public string Municipio { get; set; }
        [JsonProperty("porte")]
        public string Porte { get; set; }
        [JsonProperty("abertura")]
        public string Abertura { get; set; }
        [JsonProperty("natureza_juridica")]
        public string NaturezaJuridica { get; set; }
        [JsonProperty("fantasia")]
        public string Fantasia { get; set; }
        [JsonProperty("ultima_atualizacao")]
        public string UltimaAtualizacao { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("tipo")]
        public string Tipo { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("motivo_situacao")]
        public string MotivoSituacao { get; set; }
        [JsonProperty("situacao_especial")]
        public string SituacaoEspecial { get; set; }
        [JsonProperty("data_situacao_especial")]
        public string DataSituacaoEspecial { get; set; }
        [JsonProperty("capital_social")]
        public string CapitalSocial { get; set; }
    }
}