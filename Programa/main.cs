using System;
using System.Diagnostics;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        using (StreamWriter escrever = new StreamWriter("PerfisIMC.txt"))
        {
        repe:
            Console.Write("Quantas triagens online deseja cadastrar? ");
            if (!int.TryParse(Console.ReadLine(), out int vezes) && vezes > 0)
            {
                Console.WriteLine("Digite um número inteiro válido!");
                goto repe;
            }
            int cont;

            string[] nomes = new string[vezes];
            string[] datas = new string[vezes];
            float[] pesos = new float[vezes];
            float[] alturas = new float[vezes];
            string[] sangu = {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"};
            int[] tsg = new int[vezes];
            
            for (cont = 0; cont < vezes; cont++)
            {
                Console.Clear();
                if (cont > 0)
                {
                    Console.WriteLine("Próximo perfil : ");
                }
                repetir:
                Console.Write("\nInsira o seu nome : ");

                string n = Console.ReadLine();

                Console.Write($"\nConfirma o nome {n}? (S para sim N para não) > ");

                char confirma = char.Parse(Console.ReadLine().ToLower());

                if (confirma != 's')
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    goto repetir;
                }

                nomes[cont] = n;

                Console.Write("\nInsira a sua data de nascimento : ");
                string d = Console.ReadLine();

                datas[cont] = d;

                repetir2:
                Console.Write("\nInsira o seu peso : ");
                if (!float.TryParse(Console.ReadLine(), out float p))
                {
                    Console.WriteLine("Insira um valor válido");
                    goto repetir2;
                }

                pesos[cont] = p;

                repetir3:
                Console.Write("\nInsira a sua altura : ");
                if (!float.TryParse(Console.ReadLine(), out float a))
                {
                    Console.WriteLine("Insira um valor válido");
                    goto repetir3;
                }

                alturas[cont] = a;
                repetir4:
                Console.WriteLine($"\nInsira o seu tipo sanguíneo conforme apresentado abaixo :\n(0) - {sangu[0]}\n(1) - {sangu[1]}\n(2) - {sangu[2]}\n(3) - {sangu[3]}\n(4) - {sangu[4]}\n(5) - {sangu[5]}\n(6) - {sangu[6]}\n(7) - {sangu[7]}");
                if(!int.TryParse(Console.ReadLine(), out int s))
                {
                    if(s != 0 || s != 1 || s != 2 || s != 3 || s != 4 || s != 5 || s != 6 || s != 7)
                    {
                        continue;
                    }
                    Console.WriteLine("\nValor Inválido, siga a tabela!");
                    goto repetir4;
                }
                tsg[cont] = s;

            }

            Console.Clear();

            Console.WriteLine("\n\nDeseja ver as triagens cadastradas e suas informações? (S para sim N para não) > ");
            char resp = char.Parse(Console.ReadLine().ToLower());
            if (resp == 's')
            {
                Console.Clear();
                Console.WriteLine("\nEstão cadastrados no sistema os seguintes perfis :");
                for (int i = 0; i < vezes; i++)
                {
                    float[] imc = new float[vezes];
                    imc[i] = pesos[i] / (alturas[i] * alturas[i]);
                    if (imc[i] < 18.5)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está abaixo do peso.");
                        escrever.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está abaixo do peso.");
                    }
                    else if (imc[i] >= 18.5 && imc[i] < 25)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está dentro do peso adequado.");
                        escrever.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está dentro do peso adequado.");
                    }
                    else if (imc[i] >= 25 && imc[i] < 30)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está acima do peso adequado.");
                        escrever.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está acima do peso adequado.");
                    }
                    else
                    {
                        Console.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está obeso.");
                        escrever.WriteLine($"Nome: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está obeso.");
                    }
                }
            }
        }
    }
}
