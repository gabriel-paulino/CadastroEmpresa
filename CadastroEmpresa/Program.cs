using Refit;
using System;
using System.Threading.Tasks;

namespace CadastroEmpresa
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cnpjEmpresa = RestService.For<EmpresaApiService>("https://www.receitaws.com.br");
                Console.WriteLine("Informe o cnpj: ");
                string cnpjInformado = Console.ReadLine().ToString();

                //TODO: validar cnpj


                Console.WriteLine($"\nConsultando informacoes do CNPJ: {cnpjInformado}");

                //Salvando as informações de maneira assincrona da web api na variavel empresa
                var empresa = await cnpjEmpresa.GetEmpresaAsync(cnpjInformado);

                //Escrita de alguns dados obtidas pela web api
                Console.WriteLine($"\nO nome da empresa é: {empresa.Nome}");
                Console.WriteLine($"\nTambém conhecida por: {empresa.Fantasia}");
                Console.WriteLine("\nA data de sua abertura foi: " + empresa.Abertura);
                Console.WriteLine($"\nO CNPJ da {empresa.Fantasia} é: {empresa.Cnpj}.");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nErro na consulta de cnpj:  {e.Message}");
                Console.ReadLine();
            }

            
        }
    }
}
