using exercicios;
using Newtonsoft.Json;

public class Program
{
    private static bool _continuar = true;
    private static readonly string _pergunta = "Deseja continuar? (S/N)";

    #region Main

    public static void Main()
    {
        while (_continuar) 
        {
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Teste calculo de Fibonacci;");
            Console.WriteLine("2 - Ler um aquivo e calcular o faturamento da Distribuidora;");
            Console.WriteLine("3 - Calcular faturamento mensal da Distribuidora por estado;");
            Console.WriteLine("4 - Criar um metodo para inverser a string sem usar função pronta;");
            Console.WriteLine("0 - Encerrar;");

            int opcao = int.Parse(Console.ReadLine() ?? "");

            switch (opcao)
            {
                case 1:
                    CalcularFibonacci();
                    break;

                case 2:
                    CalcularFaturamento();
                    break;

                case 3:
                    CalcularFaturamentoEstado();
                    break;

                case 4:
                    InverterString();
                    break;

                case 0:
                    _continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            if (_continuar)
            {
                Console.WriteLine("Deseja escolher outra opção? (S/N)");

                if (Console.ReadLine()?.ToUpper() != "S")
                    _continuar = false;
            }
        }
    }

    #endregion

    #region Exercicio 2 - Teste calculo de Fibonacci

    public static void CalcularFibonacci()
    {
        while (_continuar)
        {
            int numero;
            Console.WriteLine("Digite um número para verificar se ele pertence à sequência de Fibonacci: ");
            numero = int.Parse(Console.ReadLine() ?? "");

            bool pertence = VerificaFibonacci(numero);

            string resultado;
            if (pertence)
                resultado = $"{numero} pertence à sequência de Fibonacci.";
            else
                resultado = $"{numero} não pertence à sequência de Fibonacci.";

            Console.WriteLine(resultado);

            Console.WriteLine("Deseja continuar? (S/N)");

            if(Console.ReadLine()?.ToUpper() != "S")
                _continuar = false;
        }

        _continuar = true;
    }

    public static bool VerificaFibonacci(int numero)
    {
        int a = 0, b = 1, c = 0;
        while (c < numero)
        {
            c = a + b;
            a = b;
            b = c;
        }
        if (c == numero)
            return true;
        else
            return false;
    }

    #endregion

    #region Exercicio 3 - Ler um aquivo e calcular o faturamento da Distribuidora

    public static void CalcularFaturamento()
    {
        while (_continuar)
        {
            string json = File.ReadAllText("C:\\dados\\dados.json");
            List<Faturamento>? dados = JsonConvert.DeserializeObject<List<Faturamento>>(json);

            double menorValor = double.MaxValue;
            double maiorValor = double.MinValue;
            double somaValores = 0.0;
            int numDiasAcimaMedia = 0;

            foreach (Faturamento dia in dados)
            {
                if (dia.Valor < menorValor)
                    menorValor = dia.Valor;

                if (dia.Valor > maiorValor)
                    maiorValor = dia.Valor;

                somaValores += dia.Valor;
            }

            double mediaMensal = somaValores / dados.Count;

            foreach (Faturamento dia in dados)
            {
                if (dia.Valor > mediaMensal && dia.Valor > 0)
                    numDiasAcimaMedia++;
            }

            Console.WriteLine("Menor valor de faturamento: R$ {0}", menorValor);
            Console.WriteLine("Maior valor de faturamento: R$ {0}", maiorValor);
            Console.WriteLine("Número de dias com faturamento acima da média: {0}", numDiasAcimaMedia);

            Console.WriteLine("Desesa continuar? (S/N)");

            if (Console.ReadLine()?.ToUpper() != "S")
                _continuar = false;
        }

        _continuar = true;
    }

    #endregion

    #region Exercicio 4 - Calcular faturamento mensal da Distribuidora por estado

    public static void CalcularFaturamentoEstado()
    {
        while(_continuar) 
        {
            decimal faturamentoSP = 67836.43m;
            decimal faturamentoRJ = 36678.66m;
            decimal faturamentoMG = 29229.88m;
            decimal faturamentoES = 27165.48m;
            decimal faturamentoOutros = 19849.53m;

            decimal faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG +
                                       faturamentoES + faturamentoOutros;

            decimal percentualSP = (faturamentoSP / faturamentoTotal) * 100;
            decimal percentualRJ = (faturamentoRJ / faturamentoTotal) * 100;
            decimal percentualMG = (faturamentoMG / faturamentoTotal) * 100;
            decimal percentualES = (faturamentoES / faturamentoTotal) * 100;
            decimal percentualOutros = (faturamentoOutros / faturamentoTotal) * 100;

            Console.WriteLine("Percentual de representação de cada estado:");
            Console.WriteLine($"SP: {decimal.Round(percentualSP)}%");
            Console.WriteLine($"RJ: {decimal.Round(percentualRJ)}%");
            Console.WriteLine($"MG: {decimal.Round(percentualMG)}%");
            Console.WriteLine($"ES: {decimal.Round(percentualES)}%");
            Console.WriteLine($"Outros: {decimal.Round(percentualOutros)}%");

            Console.WriteLine("Deseja Continuar? (S/N)");

            if (Console.ReadLine() != "S")
                _continuar = false;
        }

        _continuar = true;
    }

    #endregion

    #region Exercicio 5 - Criar um metodo para inverser a string sem usar função pronta

    public static void InverterString()
    {
        while (_continuar) 
        {
            Console.WriteLine("Digite uma palavra para ser invertida: ");
            string palavra = Console.ReadLine() ?? "";

            char[] caracteres = palavra.ToCharArray();

            int comprimento = caracteres.Length;

            for (int i = 0; i < comprimento / 2; i++)
            {
                (caracteres[comprimento - 1 - i], caracteres[i]) = (caracteres[i], caracteres[comprimento - 1 - i]);
            }

            Console.WriteLine("A palavra digitarda inviertida ficou dessa forma:" + caracteres);

            Console.WriteLine(_pergunta);

            if (Console.ReadLine()?.ToUpper() != "S")
                _continuar = false;
        }

        _continuar = true;
    }

    #endregion
}