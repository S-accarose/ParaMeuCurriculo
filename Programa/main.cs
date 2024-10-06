using System;
using System.IO;
using System.Threading;   
class Program
{
    public static void Main(string[] args)
    {
        //Função que permite a criação do arquivo de texto.
        using (StreamWriter escrever = new StreamWriter("PerfisTriagem.txt"))
        {
            Console.Clear();
            //Introdução
            Console.WriteLine("\nBem vindo ao Hospital Santa Casa!");
            Thread.Sleep(4000);
            Console.Clear();

            repe:
            Console.Write("\nQuantas triagens online deseja cadastrar? ");
            if (!int.TryParse(Console.ReadLine(), out int vezes) && vezes > 0)
            {
                Console.WriteLine("\nDigite um número inteiro válido!");
                goto repe;
            }

            Console.WriteLine("\nCerto, aguarde um instante enquanto preparamos o sistema.");
            Thread.Sleep(2000);
            Console.Clear();

            //Definição de variáveis, arrays com vezes como extensão, que faz com que a necessidade de armazenamento seja decidida pelo usuário
            int cont;
            string[] nomes = new string[vezes];
            string[] datas = new string[vezes];
            float[] pesos = new float[vezes];
            float[] alturas = new float[vezes];
            string[] sangu = {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"};
            int[] tsg = new int[vezes];
            string[] triagem = new string[vezes];
            float[] imc = new float[vezes];
            string[] medico = new string[vezes];
            //Loop que permite o programa rodar quantas vezes o usuário requisitou logo acima
            for (cont = 0; cont < vezes; cont++)
            {
                 if (cont > 1)
                {
                    Console.WriteLine("\nPróximo perfil : ");
                }
                med:
                Console.Write("\nCom que médico deseja se consultar? :\n[1] Médico Geral   [2] Neurologista\n[3] Ginecologista   [4] Obstetra\n[5] Urologista   [6] Psicólogo\n[7] Psiquiatra   [8] Odontologista\n> ");
                if(!int.TryParse(Console.ReadLine(), out int med))
                {
                    Console.WriteLine("\nInsira um valor válido.");
                    goto med;
                }
                //Estrutura de decisão "caso" que vai associar o nome do médico a uma variável a depender da escolha de serviço do usuário
                switch(med)
                {
                    case 1:
                        medico[cont] = "Rafael Lange";
                    break;

                    case 2:
                        medico[cont] = "Tomas Silva";
                    break;

                    case 3:
                        medico[cont] = "Silvia Martinez";
                    break;

                    case 4:
                        medico[cont] = "Carla Diniz";
                    break;

                    case 5:
                        medico[cont] = "Tom Frederico";
                    break;

                    case 6:
                        medico[cont] = "Cintia Lins";
                    break;

                    case 7:
                        medico[cont] = "Fred Mogli";
                    break;

                    case 8:
                        medico[cont] = "Aretha Orniz";
                    break;
                }

                Console.WriteLine($"A sua consulta será administrada pelo(a) Dr(a).{medico[cont]}.");
                Thread.Sleep(3000);
               
                //Aqui começamos a registrar as informações pessoais do usuário para futura criação de documento txt
                repetir:
                Console.Write($"\n{nomes[cont]} insira o seu nome : ");

                string n = Console.ReadLine();
                Console.Clear();

                Console.Write($"\nConfirma o nome {n}? (S para sim N para não) > ");

                char confirma = char.Parse(Console.ReadLine().ToLower());

                if (confirma != 's')
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    goto repetir;
                }

                nomes[cont] = n;

                Console.Write($"\n {nomes[cont]} insira a sua data de nascimento : ");
                string d = Console.ReadLine();

                datas[cont] = d;

                repetir2:
                Console.Write($"\nInsira o seu peso : ");
                if (!float.TryParse(Console.ReadLine(), out float p))
                {
                    Console.WriteLine("\nInsira um valor válido");
                    goto repetir2;
                }

                pesos[cont] = p;

                repetir3:
                Console.Write($"\nInsira a sua altura : ");
                if (!float.TryParse(Console.ReadLine(), out float a) && a <=0)
                {
                    Console.WriteLine("\nInsira um valor válido");
                    goto repetir3;
                }

                imc[cont] = pesos[cont] / (alturas[cont] * alturas[cont]);

                alturas[cont] = a;

                repetir4:
                Console.Write($"\nInsira o seu tipo sanguíneo conforme apresentado abaixo :\n(0) - {sangu[0]}\n(1) - {sangu[1]}\n(2) - {sangu[2]}\n(3) - {sangu[3]}\n(4) - {sangu[4]}\n(5) - {sangu[5]}\n(6) - {sangu[6]}\n(7) - {sangu[7]}\n> ");
                if(!int.TryParse(Console.ReadLine(), out int s) && (s != 0 || s != 1 || s != 2 || s != 3 || s != 4 || s != 5 || s != 6 || s != 7))
                {
                    Console.WriteLine("\nValor Inválido, siga a tabela!");
                    goto repetir4;
                }
                tsg[cont] = s;

                reptri:
                Console.Write("\nDescreva o que está sentindo(seja objetivo para facilitar): ");
                string t = Console.ReadLine();

                triagem[cont] = t;

                Console.Write("\nConfirma informação inserida acima (s)/(n) > ");
                if(!char.TryParse(Console.ReadLine().ToLower(), out char tc) && (tc != s))
                {
                    goto reptri;
                }
                Console.Clear();
            }

            //Aqui se encerra o registro de informações e termina com o print em console de todo o cadastro para confirmação. (É também criado arquivo txt com as informações.)
            Console.Clear();
            Console.WriteLine("\n\nEm alguns instantes exibiremos os perfis cadastrados na triagem e suas informações.");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("\nEstão cadastrados no sistema de triagem os seguintes perfis :");
            for (int i = 0; i < vezes; i++)
            {
                if (imc[i] < 18.5)
                {
                    Console.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está abaixo do peso.\n\n");
                    escrever.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está abaixo do peso.\n\n");
                }
                else if (imc[i] >= 18.5 && imc[i] < 25)
                {
                    Console.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está dentro do peso adequado.\n\n");
                    escrever.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está dentro do peso adequado.\n\n");
                }
                else if (imc[i] >= 25 && imc[i] < 30)
                {
                    Console.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está acima do peso adequado.\n\n");
                    escrever.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está acima do peso adequado.\n\n");
                }
                else
                {
                    Console.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está obeso.\n\n");
                    escrever.WriteLine($"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está obeso.\n\n");
                }
            }
        }
    }
}
