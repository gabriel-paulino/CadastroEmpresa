﻿using Newtonsoft.Json;

namespace CadastroEmpresa.Serialization
{
    public class Qsa
    {
        public int Id { get; set; }
        [JsonProperty("qual")]
        public string Qual { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
