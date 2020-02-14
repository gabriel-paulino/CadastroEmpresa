using CadastroEmpresa.Serialization;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CadastroEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\empresa.json");

            //Leitura arquivo empresa.json Modo1
            //var js = new DataContractJsonSerializer(typeof(Empresa));
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            //var empresa = (Empresa)js.ReadObject(ms);


            //Leitura arquivo empresa.json Modo2: Pacote Newtonsoft.Json
            var empresa = JsonConvert.DeserializeObject<Empresa>(json);


            //Escrita de alguns dados obtidos no arquivo empresa.json no console
            Console.WriteLine($"O nome da empresa é: {empresa.nome}");
            Console.WriteLine($"\nTambém conhecida por: {empresa.fantasia}");
            Console.WriteLine("\nA data de sua abertura foi: " + empresa.abertura);
            Console.WriteLine($"\nO CNPJ da {empresa.fantasia} é: {empresa.cnpj}.");
            Console.WriteLine($"\nO {(empresa.qsa[1].qual).Replace("16-","")} " +
                $"da {empresa.fantasia} é o {empresa.qsa[1].nome}.");
            Console.ReadLine();
        }
    }
}
