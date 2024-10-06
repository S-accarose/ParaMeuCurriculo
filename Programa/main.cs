using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
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
            string resultado;

            //Loop que permite o programa rodar quantas vezes o usuário requisitou logo acima
            for (cont = 0; cont < vezes; cont++)
            {
                med:
                Console.Write("\nCom que médico deseja se consultar? :\n[1] Médico Geral   [2] Neurologista\n[3] Ginecologista   [4] Obstetra\n[5] Urologista   [6] Psicólogo\n[7] Psiquiatra   [8] Odontologista\n\n> ");
                if(!int.TryParse(Console.ReadLine(), out int med))
                {
                    Console.WriteLine("\nInsira um valor válido.");
                    goto med;
                }

                Console.Clear();
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

                Console.WriteLine($"\nA sua consulta será administrada pelo(a) Dr(a).{medico[cont]}.");
                Thread.Sleep(3000);
                Console.Clear();
               
                //Aqui começamos a registrar as informações pessoais do usuário para futura criação de documento txt
                repetir:
                Console.Write($"\n{nomes[cont]} insira o seu nome : ");

                string n = Console.ReadLine();
                Console.Clear();

                Console.Write($"\nConfirma o nome {n}? (S)/(N)\n> ");

                if(char.TryParse(Console.ReadLine().ToLower(), out char confirma) && confirma != 's')
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto repetir;
                }

                nomes[cont] = n;

                Console.Clear();

                Console.Write($"\n {nomes[cont]} insira a sua data de nascimento : ");
                string d = Console.ReadLine();

                datas[cont] = d;

                Console.Clear();

                repetir2:
                Console.Write($"\nInsira o seu peso : ");
                if (!float.TryParse(Console.ReadLine(), out float p) || p <= 0)
                {
                    Console.WriteLine("\nInsira um valor válido");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto repetir2;
                }

                pesos[cont] = p;

                Console.Clear();

                repetir3:
                Console.Write($"\nInsira a sua altura : ");
                if (!float.TryParse(Console.ReadLine(), out float a) || a <=0)
                {
                    Console.WriteLine("\nInsira um valor válido");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto repetir3;
                }
                
                alturas[cont] = a;
                
                imc[cont] = pesos[cont] / (alturas[cont] * alturas[cont]);

                Console.Clear();

                repetir4:
                Console.Write($"\nInsira o seu tipo sanguíneo conforme apresentado abaixo :\n(0) - {sangu[0]}\n(1) - {sangu[1]}\n(2) - {sangu[2]}\n(3) - {sangu[3]}\n(4) - {sangu[4]}\n(5) - {sangu[5]}\n(6) - {sangu[6]}\n(7) - {sangu[7]}\n\n> ");
                if(!int.TryParse(Console.ReadLine(), out int s) || s < 0 || s > 7)
                {
                    Console.WriteLine("\nValor Inválido, siga a tabela!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto repetir4;
                }

                tsg[cont] = s;

                Console.Clear();

                reptri:
                Console.Write("\nDescreva o que está sentindo(seja objetivo para facilitar): ");
                string t = Console.ReadLine();

                triagem[cont] = t;

                Console.Write("\nConfirma informação inserida acima (N)/(N) > ");
                if(!char.TryParse(Console.ReadLine().ToLower(), out char tc) && (tc != s))
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto reptri;
                }
                Console.Clear();
            }

            //Aqui se encerra o registro de informações e termina com o print em console de todo o cadastro para confirmação. (É também criado arquivo txt com as informações.)
            Console.Clear();
            Console.WriteLine("\n\nEm alguns instantes exibiremos os perfis cadastrados na triagem e suas informações.");
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("\nEstão cadastrados no sistema de triagem os seguintes perfis :");
            for (int i = 0; i < vezes; i++)
            {
                if(imc[i] < 18.5)
                {
                    resultado = $"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está abaixo do peso.\nRelatório Triagem:\n{triagem[i]}\n\n";
                    
                }
                else if (imc[i] >= 18.5 && imc[i] < 25)
                {
                    resultado = $"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está dentro do peso adequado.\nRelatório Triagem:\n{triagem[i]}\n\n";
                }
                else if (imc[i] >= 25 && imc[i] < 30)
                {
                    resultado = $"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está acima do peso adequado.\nRelatório Triagem:\n{triagem[i]}\n\n";
                }
                else
                {
                    resultado = $"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]} \nAltura: {alturas[i]} \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2} - Está obeso.\nRelatório Triagem:\n{triagem[i]}\n\n";
                }

                Console.WriteLine(resultado);

                escrever.WriteLine(resultado);
            }


            final:
            Console.Write("\nConfirma os resultados? (S)/(N)\n> ");
            if(char.TryParse(Console.ReadLine().ToLower(), out char cf) && cf != 's')
            {
                Console.WriteLine("\nResponda com S ou N!");
                Thread.Sleep(2000);
                Console.Clear();
                goto final;
            }

            final2:
            Console.Write("\nQual informação deseja alterar?\n[1] Tipo de consulta\n[2] Nome\n[3] Data de Nascimento\n[4] Peso\n[5] Altura\n[6] Tipo Sanguíneo\n[7] Relatório\n> ");
            if(!int.TryParse(Console.ReadLine(), out int rf) || rf < 1 || rf > 7)
            {
                Console.WriteLine("\nValor Inválido, siga a tabela!");
                Thread.Sleep(2000);
                Console.Clear();
                goto final2;
            }
        }
    }
}
