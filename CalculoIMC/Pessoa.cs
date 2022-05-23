using System;
using System.Globalization;

namespace CalculoIMC
{
    public class Pessoa
    {
        public string nome { get; set; }
        public int idade { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }

        public double CalculaIMC()
        {
            return peso / Math.Pow(altura, 2);
        }
        public void CriaTxt(string patch)
        {
            if (!File.Exists(@"C:\Temp\"))
            {
                Directory.CreateDirectory(@"C:\Temp\");
            }
            StreamWriter sw = new StreamWriter(patch);
            sw.WriteLine("Nome: " + nome);
            sw.WriteLine("Idade: " + idade);
            sw.WriteLine("Altura: " + altura.ToString("F2", CultureInfo.InvariantCulture) + "m");
            sw.WriteLine("Peso: " + peso.ToString("F2", CultureInfo.InvariantCulture) + "kg");
            sw.WriteLine("IMC: " + CalculaIMC().ToString("F2", CultureInfo.InvariantCulture));
            sw.Close();
        }
        public void SubstituiArquivo(string patch)
        {
            File.Delete(patch);
            CriaTxt(patch);
        }
        public void VerificaArquivo()
        {
            string path = @"C:\Temp\" + nome + ".txt";
            if (File.Exists(path))
            {
                Console.Write("Já existe um aquivo com esse nome, deseja substituir? s/n ");
                char ch = char.Parse(Console.ReadLine());
                while (ch != 's' && ch != 'n')
                {
                    Console.WriteLine("Caracter não identificado!");
                    Console.WriteLine("Digite novamente");
                    Console.Write("Já existe um arquivo com esse nome, deseja substituir? s/n ");
                    ch = char.Parse(Console.ReadLine());
                }
                if (ch == 's')
                {
                    SubstituiArquivo(path);
                    Console.WriteLine("Arquivo substituido com sucesso!");
                }
                else if (ch == 'n')
                {
                    Console.WriteLine("Arquivo permanece o mesmo.");
                }
            }
        }
        public void exibetxt(string patch)
        {
            string[] linhas = File.ReadAllLines(patch);
            foreach (string linha in linhas)
            {
                Console.WriteLine(linha);
            }
            Console.WriteLine();
            Console.WriteLine("Seu Arquivo esta salvo em: " + patch);
        }
        public void NovoArquivo()
        {
            Console.Clear();
            Console.WriteLine("Informe os dados:");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Idade: ");
            idade = int.Parse(Console.ReadLine());
            Console.Write("Peso: ");
            peso = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Altura: ");
            altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            string path = @"C:\Temp\" + nome + ".txt";
            VerificaArquivo();
            CriaTxt(path);
            Console.WriteLine();
            exibetxt(path);
        }
        public void ConsultaArquivo()
        {
            string pasta = @"C:\Temp\";
            Console.Clear();
            var file = Directory.EnumerateFiles(pasta, "*", SearchOption.AllDirectories);
            Console.WriteLine("Arquivos:");
            foreach (string s in file)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("------------------");

            Console.Write("Qual deseja abrir? (Digite o nome do txt): ");
            nome = Console.ReadLine();
            string path = @"C:\Temp\" + nome + ".txt";
            Console.WriteLine();
            exibetxt(path);
            Console.WriteLine();
        }
        public void Tratamento()
        {
            Console.Clear();
            Console.WriteLine("Resposta não identifica, responda novamente");
            Console.WriteLine();
            Console.WriteLine("Deseja fazer um novo cadastro ou consultar um existente? (Digite o número das opções abaixo)");
            Console.WriteLine("1 - Consultar");
            Console.WriteLine("2 - Novo");
            Console.Write("Resposta: ");
        }
    }
}
