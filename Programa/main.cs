using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;  
class Program
{
    public static void Introducao(out vezes)
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

        string[] nomes = new string[vezes];
        string[] datas = new string[vezes];
        float[] pesos = new float[vezes];
        float[] alturas = new float[vezes];
        string[] triagem = new string[vezes];
        float[] imc = new float[vezes];
        int[] tsg = new int[vezes];
        string[] sangu = {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"};
        string[] medico = new string[vezes];
        string resultado;
        int meudeus = vezes - 1;
        int x;
        bool alterar = false;
    }
    public static void Registro(int vezes, string[] medico,string[] nomes,string[] datas,float[] pesos,float[] alturas,string[] triagem,float[] imc,int[] tsg,string[] sangu)
    {
        //Loop que permite o programa rodar quantas vezes o usuário requisitou logo acima
        for (int cont = 0; cont < vezes; cont++)
        {
            med:
            Console.Write("\nCom que médico deseja se consultar? :\n[1] Médico Geral   [2] Neurologista\n[3] Ginecologista   [4] Obstetra\n[5] Urologista   [6] Psicólogo\n[7] Psiquiatra   [8] Odontologista\n\n> ");
            if(!int.TryParse(Console.ReadLine(), out int med)&& med <1 || med >7)
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
            Console.Write($"\nInsira o seu nome : ");

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

            Console.Write("\nConfirma informação inserida acima (S)/(N) > ");
            if(!char.TryParse(Console.ReadLine().ToLower(), out char tc) && (tc != s))
            {
                Console.WriteLine("\nResponda com S ou N!");
                Thread.Sleep(2000);
                Console.Clear();
                goto reptri;
            }
            Console.Clear();
        }
    }
    public static void Print(bool alterar,int cont,int x,int vezes,string[] medico,string[] nomes,string[] datas,float[] pesos,float[] alturas,string[] triagem,float[] imc,int[] tsg,string[] sangu, string resultado)
    {
        //Função que permite a criação do arquivo de texto.
        using (StreamWriter escrever = new StreamWriter("PerfisTriagem.txt"))
        {
             //Aqui, após completar o cadastro das informações, termina com o print em console de todo o cadastro para confirmação. (É também criado arquivo txt com as informações.)
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
            //Confirma os resultados e inicia a troca de dados no registro da triagem
            Console.Write("\nConfirma os resultados? (S)/(N)\n> ");
            if(char.TryParse(Console.ReadLine().ToLower(), out char cf) && cf == 's')
            {
                Console.WriteLine("\nSe apresente no hospital com a cópia digital ou física de sua triagem online!");
                Thread.Sleep(2000);
                Environment.Exit(-1);
            }
            else
            {
                final2:
                alterar = true;
                Console.Write($"\nQual dos {vezes} registros gostaria de corrigir?\n> ");
                if(!int.TryParse(Console.ReadLine().ToLower(), out x) || x < vezes || x > vezes)
                {
                    Console.WriteLine("\nValor inválido");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto final2;
                }
            }
            if(x == 0)
            {
                cont = 0;
            }
            else
            {
                cont = x;
            }
        }
    }
    public static void Repetir(int cont,int x,int vezes,string[] medico,string[] nomes,string[] datas,float[] pesos,float[] alturas,string[] triagem,float[] imc,int[] tsg,string[] sangu)
    {

        string[] nomes2 = new string[vezes];
        string[] datas2 = new string[vezes];
        float[] pesos2 = new float[vezes];
        float[] alturas2 = new float[vezes];
        string[] triagem2 = new string[vezes];
        float[] imc2 = new float[vezes];
        int[] tsg2 = new int[vezes];
        string[] sangu2 = {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"};
        string[] medico2 = new string[vezes];

        Console.Clear();

        //Aqui o usuário escolhe qual informação será trocada
        final3:
        Console.Write("\nQual informação deseja alterar?\n[1] Tipo de consulta\n[2] Nome\n[3] Data de Nascimento\n[4] Peso\n[5] Altura\n[6] Tipo Sanguíneo\n[7] Relatório\n> ");
        if(!int.TryParse(Console.ReadLine(), out int rf) || rf < 1 || rf > 7)
        {
            Console.WriteLine("\nValor Inválido, siga a tabela!");
            Thread.Sleep(2000);
            Console.Clear();
            goto final3;
        }

        switch(rf)
        {
            case 1:

                med2:
                Console.Write("\nCom que médico deseja se consultar? :\n[1] Médico Geral   [2] Neurologista\n[3] Ginecologista   [4] Obstetra\n[5] Urologista   [6] Psicólogo\n[7] Psiquiatra   [8] Odontologista\n\n> ");
                if(!int.TryParse(Console.ReadLine(), out int med2) && med2 <1 || med2 >7)
                {
                    Console.WriteLine("\nInsira um valor válido.");
                    goto med2;
                }
                switch(med2)
                {
                    case 1:
                        medico2[cont] = "Rafael Lange";
                    break;
                    case 2:
                        medico2[cont] = "Tomas Silva";
                    break;
                    case 3:
                        medico2[cont] = "Silvia Martinez";
                    break;
                    case 4:
                        medico2[cont] = "Carla Diniz";
                    break;
                    case 5:
                        medico2[cont] = "Tom Frederico";
                    break;
                    case 6:
                        medico2[cont] = "Cintia Lins";
                    break;
                    case 7:
                        medico2[cont] = "Fred Mogli";
                    break;
                    case 8:
                        medico2[cont] = "Aretha Orniz";
                    break;
                }
            break;

            case 2:

                nom2:
                Console.Write($"\nInsira o seu nome : ");

                string nr = Console.ReadLine();
                Console.Clear();

                Console.Write($"\nConfirma o nome {nr}? (S)/(N)\n> ");

                if(char.TryParse(Console.ReadLine().ToLower(), out char conf) && conf != 's')
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto nom2;
                }

                nomes2[cont] = nr;

            break;

            case 3:
            
                Console.Write($"\n {nomes[cont]} insira a sua data de nascimento : ");
                string dr = Console.ReadLine();

                datas2[cont] = dr;

                Console.Clear();

                break;

            case 4:

                peso2:
                Console.Write($"\nInsira o seu peso : ");
                if (!float.TryParse(Console.ReadLine(), out float pr) || pr <= 0)
                {
                    Console.WriteLine("\nInsira um valor válido");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto peso2;
                }

                pesos2[cont] = pr;

                Console.Clear();
            
            break;

            case 5:
            
                alt2:
                Console.Write($"\nInsira a sua altura : ");
                if (!float.TryParse(Console.ReadLine(), out float ar) || ar <=0)
                {
                    Console.WriteLine("\nInsira um valor válido");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto alt2;
                }
                
                alturas2[cont] = ar;
                
                imc[cont] = pesos[cont] / (alturas[cont] * alturas[cont]);

                Console.Clear();

            break;

            case 6:
            
                sang2:
                Console.Write($"\nInsira o seu tipo sanguíneo conforme apresentado abaixo :\n(0) - {sangu[0]}\n(1) - {sangu[1]}\n(2) - {sangu[2]}\n(3) - {sangu[3]}\n(4) - {sangu[4]}\n(5) - {sangu[5]}\n(6) - {sangu[6]}\n(7) - {sangu[7]}\n\n> ");
                if(!int.TryParse(Console.ReadLine(), out int sr) || sr < 0 || sr > 7)
                {
                    Console.WriteLine("\nValor Inválido, siga a tabela!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto sang2;
                }

                tsg2[cont] = sr;

                Console.Clear();

            break;

            case 7:
            
                rela2:
                Console.Write("\nDescreva o que está sentindo(seja objetivo para facilitar): ");
                string tr = Console.ReadLine();

                triagem2[cont] = tr;

                Console.Write("\nConfirma informação inserida acima (S)/(N) > ");
                if(char.TryParse(Console.ReadLine().ToLower(), out char tcr) && (tcr != s))
                {
                    Console.WriteLine("\nResponda com S ou N!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto rela2;
                }
                Console.Clear();

            break;
        }

        Console.Write("\nDeseja realizar mais alguma alteração?(S)/(N)\n> ");
        if(char.TryParse(Console.ReadLine().ToLower(), out char fin) && (fin != 's'))
        {
            goto final3;
        }

    }
    public static void Main(string[] args,bool alterar,int cont,int x,int vezes,string[] medico,string[] nomes,string[] datas,float[] pesos,float[] alturas,string[] triagem,float[] imc,int[] tsg,string[] sangu, string resultado)
    {
        Program.Introducao();
        Program.Registro(vezes,medico,nomes,datas,pesos,alturas,triagem,imc,alterar,cont,x,tsg,sangu);
        Program.Print(vezes,medico,nomes,datas,pesos,alturas,triagem,imc,alterar,cont,x,tsg,sangu);
        if(alterar == true)
        {
            Program.Repetir();
        }
    }
}
