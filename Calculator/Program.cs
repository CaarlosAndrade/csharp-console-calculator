using System;

namespace Calculator
{
    class Calculator {
        public static double realizarOperacao(double num1, double num2, string operacao)
        {

            double result = double.NaN; // definindo o retorno como a constante Not a Number, qualquer operação falha, resulta no erro;

            // verificando o tipo de operação 
            switch (operacao)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;

                // caso não caia em nenhuma operação é gerado o resultado NaN por padrão
                default:
                    break;
            }

            return result;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Definindo variavel que encerra o programa parando o laço de repetição
            bool endApp = false;

            // Exibindo as boas vindas e titulo do programa
            Console.Write("Calculadora em C#\n");
            Console.Write("------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Recebendo o primero valor do usuário 
                Console.WriteLine("Digite um valor: ");
                numInput1 = Console.ReadLine();


                // TODO: Tentar colocar um FOR para reduzir o código

                // Verificando se o primero valor digitado no input é um valor do tipo real
                double num1 = 0;
                while (!double.TryParse(numInput1, out num1))
                {
                    Console.WriteLine("Digite um valor válido");
                    numInput1 = Console.ReadLine();
                }

                // Recebendo o segundo valor do usuário
                Console.WriteLine("Digite outro valor: ");
                numInput2 = Console.ReadLine();

                // Verificando se o numero digitado é válido
                double num2 = 0;
                while (!double.TryParse(numInput2, out num2))
                {
                    Console.WriteLine("Digite um valor válido");
                    numInput2 = Console.ReadLine();
                }

                // Rebendo a operação do usuário
                string operacao = "";

                Console.WriteLine("selecione a operação que deseja executar");
                Console.WriteLine("\t a - Adição ");
                Console.WriteLine("\t s - Subtração");
                Console.WriteLine("\t m - Multiplicação");
                Console.WriteLine("\t d - Divisão");
                Console.WriteLine("Operação escolhida: ");
                operacao = Console.ReadLine();

                // Chamada do método e retorno da operação
                result = Calculator.realizarOperacao(num1, num2, operacao);


                // Testando o resultado e tratando as exeções caso exista
                try
                {
                    if (double.IsNaN(result))
                        Console.WriteLine("Essa operação gera um erro matemático");
                    else
                        Console.WriteLine($"O resultado da operação é: {result}");
                } 
                catch (Exception erro) 
                {
                    Console.WriteLine($"Ocorreu um erro ao executar a conta! \n - Detalhes {erro.Message} ");
                }
                
                // Finalização do programa ou reinicialização

                Console.WriteLine("Digite n e aperte a tecla enter para sair do programa");
                Console.WriteLine("Caso queira utilizar novamente, precione apenas enter");
                if (Console.ReadLine() == "n")
                    endApp = true;

            }
            return;
        }
    }
}
