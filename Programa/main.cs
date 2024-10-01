using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        using (StreamWriter escrever = new StreamWriter("PerfisIMC.txt"))
        {
        repe:
            Console.Write("Quantos perfis deseja cadastrar? ");
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
            
            for (cont = 0; cont < vezes; cont++)
            {
                Console.Clear();
                if (cont > 0)
                    Console.WriteLine("Próximo perfil : ");
                repetir:
                Console.Write("Insira o seu nome : ");

                string n = Console.ReadLine();

                Console.Write($"Confirma o nome {n}? (S para sim N para não) > ");

                char confirma = char.Parse(Console.ReadLine().ToLower());

                if (confirma != 's')
                {
                    goto repetir;
                }

                nomes[cont] = n;

                Console.Write("Insira a sua data de nascimento : ");
                string d = Console.ReadLine();

                datas[cont] = d;

            repetir2:
                Console.Write("Insira o seu peso : ");
                if (!float.TryParse(Console.ReadLine(), out float p))
                {
                    Console.WriteLine("Insira um valor válido");
                    goto repetir2;
                }

                pesos[cont] = p;

            repetir3:
                Console.Write("Insira a sua altura : ");
                if (!float.TryParse(Console.ReadLine(), out float a))
                {
                    Console.WriteLine("Insira um valor válido");
                    goto repetir3;
                }

                alturas[cont] = a;

            }

            Console.Clear();

            Console.WriteLine("Deseja ver os perfis cadastrados e seus IMC? (S para sim N para não) > ");
            char resp = char.Parse(Console.ReadLine().ToLower());
            if (resp == 's')
            {
                Console.Clear();
                Console.WriteLine("Estão cadastrados no sistema os seguintes perfis :");
                for (int i = 0; i < vezes; i++)
                {
                    float[] imc = new float[vezes];
                    imc[i] = pesos[i] / (alturas[i] * alturas[i]);
                    if (imc[i] < 18.5)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está abaixo do peso.");
                        escrever.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está abaixo do peso.");
                    }
                    else if (imc[i] >= 18.5 && imc[i] < 25)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está dentro do peso adequado.");
                        escrever.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está dentro do peso adequado.");
                    }
                    else if (imc[i] >= 25 && imc[i] < 30)
                    {
                        Console.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está acima do peso adequado.");
                        escrever.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está acima do peso adequado.");
                    }
                    else
                    {
                        Console.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está obeso.");
                        escrever.WriteLine($"Nome: {nomes[i]} | Data de nascimento: {datas[i]} | Peso: {pesos[i]} | Altura {alturas[i]} | IMC: {imc[i]:F2} - Está obeso.");
                    }
                }
            }
        }
    }
}
