using System;
using System.IO;
using System.Threading;

class Program
{
    public static void Introducao()
    {   
        //Introdução
        Console.Clear();
        Console.WriteLine("\nBem vindo ao Hospital Santa Casa!");
        Thread.Sleep(2000);
        Console.Clear();

        repe:
        Console.Write("\nQuantas triagens online deseja cadastrar? ");
        if (!int.TryParse(Console.ReadLine(), out int vezes) || vezes <= 0)
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
        string[] sangu = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
        string[] medico = new string[vezes];
        bool alterar = false;
        string resultado = string.Empty;

        Registro(vezes, medico, nomes, datas, pesos, alturas, triagem, imc, tsg, sangu);

        //Pergunta se o usuário quer modificar alguma informação antes de gerar o relatório final
        Console.Write("\nDeseja alterar algum registro antes de finalizar? (S)/(N)\n> ");
        if (char.TryParse(Console.ReadLine().ToLower(), out char cf) && cf == 's')
        {
            alterar = true;
        }

        if (alterar)
        {
            AlterarInformacao(vezes, medico, nomes, datas, pesos, alturas, triagem, imc, tsg, sangu);
        }

        Print(vezes, medico, nomes, datas, pesos, alturas, triagem, imc, tsg, sangu, resultado);
    }

    public static void Registro(int vezes, string[] medico, string[] nomes, string[] datas, float[] pesos, float[] alturas, string[] triagem, float[] imc, int[] tsg, string[] sangu)
    {
        for (int cont = 0; cont < vezes; cont++)
        {
            // Escolha do médico
            med:
            Console.Write("\nCom que médico deseja se consultar? :\n[1] Médico Geral   [2] Neurologista\n[3] Ginecologista   [4] Obstetra\n[5] Urologista   [6] Psicólogo\n[7] Psiquiatra   [8] Odontologista\n\n> ");
            if (!int.TryParse(Console.ReadLine(), out int med) || med < 1 || med > 8)
            {
                Console.WriteLine("\nInsira um valor válido.");
                goto med;
            }

            switch (med)
            {
                case 1: medico[cont] = "Rafael Lange"; break;
                case 2: medico[cont] = "Tomas Silva"; break;
                case 3: medico[cont] = "Silvia Martinez"; break;
                case 4: medico[cont] = "Carla Diniz"; break;
                case 5: medico[cont] = "Tom Frederico"; break;
                case 6: medico[cont] = "Cintia Lins"; break;
                case 7: medico[cont] = "Fred Mogli"; break;
                case 8: medico[cont] = "Aretha Orniz"; break;
            }

            // Cadastro de informações do usuário
            Console.Write("\nInsira o seu nome: ");
            nomes[cont] = Console.ReadLine();
            Console.Clear();

            Console.Write("\nInsira a sua data de nascimento: ");
            datas[cont] = Console.ReadLine();
            Console.Clear();

            Console.Write("\nInsira o seu peso: ");
            while (!float.TryParse(Console.ReadLine(), out pesos[cont]) || pesos[cont] <= 0)
            {
                Console.WriteLine("\nInsira um peso válido.");
            }
            Console.Clear();

            Console.Write("\nInsira a sua altura: ");
            while (!float.TryParse(Console.ReadLine(), out alturas[cont]) || alturas[cont] <= 0)
            {
                Console.WriteLine("\nInsira uma altura válida.");
            }
            Console.Clear();

            // Cálculo do IMC
            imc[cont] = pesos[cont] / (alturas[cont] * alturas[cont]);

            // Tipo sanguíneo
            repSangue:
            Console.Write("\nInsira o seu tipo sanguíneo conforme apresentado abaixo:\n(0) - A+  (1) - A-  (2) - B+  (3) - B-  (4) - AB+  (5) - AB-  (6) - O+  (7) - O-\n> ");
            if (!int.TryParse(Console.ReadLine(), out tsg[cont]) || tsg[cont] < 0 || tsg[cont] > 7)
            {
                Console.WriteLine("\nValor Inválido, siga a tabela!");
                goto repSangue;
            }
            Console.Clear();

            Console.Write("\nDescreva o que está sentindo: ");
            triagem[cont] = Console.ReadLine();
            Console.Clear();
        }
    }

    public static void AlterarInformacao(int vezes, string[] medico, string[] nomes, string[] datas, float[] pesos, float[] alturas, string[] triagem, float[] imc, int[] tsg, string[] sangu)
    {
        //Código para alteração das informações antes de exibir no console todas as informações cadastradas
        Console.Clear();
        Console.WriteLine("Qual registro deseja alterar?");
        for (int i = 0; i < vezes; i++)
        {
            Console.WriteLine($"[{i + 1}] {nomes[i]} - {datas[i]}");
        }

        int escolha;
        do
        {
            Console.Write("\nEscolha o número do registro: ");
        } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > vezes);

        int indice = escolha - 1;
        Console.Clear();
        Console.WriteLine("Qual informação deseja alterar?");
        Console.WriteLine("[1] Nome\n[2] Data de nascimento\n[3] Peso\n[4] Altura\n[5] Tipo Sanguíneo\n[6] Relatório de Triagem");

        int opcao;
        do
        {
            Console.Write("\nEscolha uma opção: ");
        } while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 6);

        switch (opcao)
        {
            case 1:
                Console.Write("\nInsira o novo nome: ");
                nomes[indice] = Console.ReadLine();
            break;
            case 2:
                Console.Write("\nInsira a nova data de nascimento: ");
                datas[indice] = Console.ReadLine();
            break;
            case 3:
                Console.Write("\nInsira o novo peso: ");
                while (!float.TryParse(Console.ReadLine(), out pesos[indice]) || pesos[indice] <= 0)
                {
                    Console.WriteLine("\nInsira um valor válido.");
                }
                imc[indice] = pesos[indice] / (alturas[indice] * alturas[indice]);
            break;
            case 4:
                Console.Write("\nInsira a nova altura: ");
                while (!float.TryParse(Console.ReadLine(), out alturas[indice]) || alturas[indice] <= 0)
                {
                    Console.WriteLine("\nInsira um valor válido.");
                }
                imc[indice] = pesos[indice] / (alturas[indice] * alturas[indice]);
            break;
            case 5:
                repSangue:
                Console.Write("\nInsira o novo tipo sanguíneo:\n(0) - A+  (1) - A-  (2) - B+  (3) - B-  (4) - AB+  (5) - AB-  (6) - O+  (7) - O-\n> ");
                if (!int.TryParse(Console.ReadLine(), out tsg[indice]) || tsg[indice] < 0 || tsg[indice] > 7)
                {
                    Console.WriteLine("\nValor Inválido, siga a tabela!");
                    goto repSangue;
                }
            break;
            case 6:
                Console.Write("\nInsira o novo relatório de triagem: ");
                triagem[indice] = Console.ReadLine();
            break;
        }

        Console.WriteLine("\nInformação alterada com sucesso!");
    }

    public static void Print(int vezes, string[] medico, string[] nomes, string[] datas, float[] pesos, float[] alturas, string[] triagem, float[] imc, int[] tsg, string[] sangu, string resultado)
    {
        //Função para criar o arquivo de texto com os registros
        using (StreamWriter escrever = new StreamWriter("PerfisTriagem.txt"))
        {
            Console.Clear();
            Console.WriteLine("\nPerfis cadastrados na triagem e suas informações:\n");

            for (int i = 0; i < vezes; i++)
            {
                resultado = $"\nMédico: {medico[i]} \nPaciente: {nomes[i]} \nData de nascimento: {datas[i]} \nPeso: {pesos[i]}kg \nAltura: {alturas[i]}m \nTipo Sanguíneo: {sangu[tsg[i]]} \nIMC: {imc[i]:F2}";
                if (imc[i] < 18.5)
                {
                    resultado += " - Está abaixo do peso.";
                }
                else if (imc[i] < 25)
                {
                    resultado += " - Está no peso ideal.";
                }
                else if (imc[i] < 30)
                {
                    resultado += " - Está acima do peso.";
                }
                else
                {
                    resultado += " - Está obeso.";
                }

                resultado += $"\nRelatório Triagem: {triagem[i]}\n";
                Console.WriteLine(resultado);
                escrever.WriteLine(resultado);
            }
        }
    }

    public static void Main(string[] args)
    {
        Introducao();
    }
}
