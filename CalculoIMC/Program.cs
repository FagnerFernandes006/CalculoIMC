using System.Globalization;

namespace CalculoIMC
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
           
            Console.WriteLine("Deseja fazer um novo cadastro ou consultar um existente?");
            Console.WriteLine("1 - Novo");
            Console.WriteLine("2 - Consultar");
            Console.Write("Resposta: ");
            int r = int.Parse(Console.ReadLine());

            while (r != 1 && r != 2)
            {
                pessoa.Tratamento();
                r = int.Parse(Console.ReadLine());
            }
            if (r == 1)
            {
                pessoa.NovoArquivo();
            }
            else
            {
               pessoa.ConsultaArquivo();
            }
        }
    }
}