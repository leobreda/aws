using Amazon;
using System;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.Runtime;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleSSM
{
    class Program
    {

        private static string ACCESS_KEY = "COLOQUE O SEU ACCESS KEY AQUI";
        private static string SECRET_KEY = "COLOQUE A SUA SECRET KEY AQUI";
        private static RegionEndpoint REGION = RegionEndpoint.SAEast1;

        static void Main(string[] args)
        {
            Program instancia = new Program();

            string chave = "/DEV/Database/Password";
            string valor = instancia.RecuperarParametro(chave);

            Console.WriteLine("Chave:" + chave);
            Console.WriteLine("Valor:" + valor);

             chave = "LoremIpsum";
             valor = instancia.RecuperarParametro(chave);

            Console.WriteLine("\n\nChave:" + chave);
            Console.WriteLine("Valor:" + valor);


            Console.ReadLine();

        }

        public string RecuperarParametro(string chave)
        {
            string valor = null;

            var request = new GetParameterRequest();
            request.Name = chave;
            request.WithDecryption = false;

            var credentials = new BasicAWSCredentials(ACCESS_KEY,
               SECRET_KEY);

            using (var client = new AmazonSimpleSystemsManagementClient(credentials, REGION))
            {
                var response = client.GetParameterAsync(request);
                valor = response.Result.Parameter.Value;
            }

            return valor;
        }

    }
}
