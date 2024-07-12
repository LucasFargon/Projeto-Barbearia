using Barbearia;
using System.Data;
class Program
{
    static List<Barbeiro> barbeiros = new List<Barbeiro>
        {
            new Barbeiro { Id = "0", Nome = "Qualquer um"},
            new Barbeiro { Id = "1", Nome = "Solaire"},
            new Barbeiro { Id = "2", Nome = "Siegmeyer"},
            new Barbeiro { Id = "3", Nome = "Patches"}
        };

    static List<Cabelo> cortesCabelo = new List<Cabelo>
        {
            new Cabelo { Nome = "Americano", Preco = 30},
            new Cabelo { Nome = "Mid Fade", Preco = 30 },
            new Cabelo { Nome = "Low Fade", Preco = 30 }
        };

    static List<Barba> cortesBarba = new List<Barba>
        {
            new Barba { Nome = "Lenhador", Preco = 40},
            new Barba { Nome = "Cavanhaque", Preco = 25 },
            new Barba { Nome = "Alinhamento", Preco = 20 }
        };

    static List<Outros> outrosTipos = new List<Outros>
        {
            new Outros { Nome = "Sobrancelha", Preco = 10},
            new Outros { Nome = "Corte Navalhado", Preco = 10 },
            new Outros { Nome = "Tirar pelos do nariz e orelhas", Preco = 5 }
        };


    public static void AgendarCorte()
    {
        Console.Clear();
        Console.WriteLine("Digite o nome do cliente:");
        string nomeCliente = Console.ReadLine();
        Console.WriteLine("Digite o CPF do cliente:");
        string cpfCliente = Console.ReadLine();
        Console.WriteLine("Digite o telefone do cliente:");
        string telCliente = Console.ReadLine();
        Cliente cliente = new Cliente { Nome = nomeCliente, Cpf = cpfCliente, Telefone = telCliente };

        Console.WriteLine("Qual Barbeiro o cliente deseja ser atendido?");
        foreach (var barbeiro in barbeiros)
        {
            Console.WriteLine($"{barbeiro.Id}) {barbeiro.Nome}");
        }
        Console.WriteLine($"{barbeiros.Count}) Para voltar para a tela inicial");

        string idBarbeiro = Console.ReadLine();
        if (int.Parse(idBarbeiro) == barbeiros.Count)
        {
            TelaInicial();
        }

        Barbeiro barbeiroEscolhido = barbeiros.Find(b => b.Id == idBarbeiro);

        Cabelo cabeloEscolhido = null;
        Barba barbaEscolhida = null;
        List<Outros> outroEscolhido = new List<Outros>();

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer um corte de cabelo? (sim ou não)");
        string cortarCabelo = Console.ReadLine();

        if (cortarCabelo.ToLower() == "sim" || cortarCabelo.ToLower() == "s")
        {
            Console.WriteLine("Escolha o tipo de corte de cabelo:");
            foreach (var cabelo in cortesCabelo)
            {
                Console.WriteLine($"{cortesCabelo.IndexOf(cabelo)}) {cabelo.Nome} - R${cabelo.Preco}");
            }
            Console.WriteLine($"{cortesCabelo.Count}) Para voltar para a tela inicial");
            int rCortesCabelo = int.Parse(Console.ReadLine());
            if (rCortesCabelo == cortesCabelo.Count)
            {
                TelaInicial();
            }
            cabeloEscolhido = cortesCabelo[rCortesCabelo];
        }

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer a barba? (sim ou não)");
        string cortarBarba = Console.ReadLine();

        if (cortarBarba.ToLower() == "sim" || cortarBarba.ToLower() == "s")
        {
            Console.WriteLine("Escolha o tipo de barba:");
            foreach (var barba in cortesBarba)
            {
                Console.WriteLine($"{cortesBarba.IndexOf(barba)}) {barba.Nome} - R${barba.Preco}");
            }
            Console.WriteLine($"{cortesBarba.Count}) Para voltar para a tela inicial");
            int rCortesBarba = int.Parse(Console.ReadLine());
            if (rCortesBarba == cortesBarba.Count)
            {
                TelaInicial();
            }
            barbaEscolhida = cortesBarba[rCortesBarba];
        }

        Console.WriteLine();
        Console.WriteLine("Gostaria de fazer um pedido adicional? (sim ou não)");
        string pedidoAdicional = Console.ReadLine();

        if (pedidoAdicional.ToLower() == "sim" || pedidoAdicional.ToLower() == "s")
        {
           Console.WriteLine("Escolha um pedido adicional:");
           List<Outros> listaAuxiliar = new List<Outros>();
            listaAuxiliar = outrosTipos;
           for (int i = 0; i < 3; i++)
            {
                foreach (var outro in listaAuxiliar)
                {
                    Console.WriteLine($"{listaAuxiliar.IndexOf(outro)}) {outro.Nome} - R${outro.Preco}");
                }
                Console.WriteLine($"{listaAuxiliar.Count}) Para voltar para a tela inicial");
                int resposta = int.Parse(Console.ReadLine());

                if (resposta == listaAuxiliar.Count)
                {
                    TelaInicial();
                }

                Console.WriteLine($"{listaAuxiliar[resposta].Nome} Escolhido");
                Console.WriteLine();

                outroEscolhido.Add(listaAuxiliar[resposta]);
                listaAuxiliar.RemoveAt(resposta);

                if (listaAuxiliar.Count >= 1)
                {
                    Console.WriteLine("Deseja escolher outro?");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 != "sim" && resposta2 != "s")
                    {
                        i = 3;
                    }
                }
            }
        }

        Console.WriteLine("Escolha a data e a hora do agendamento no formato: dd/MM/yyyy HH:mm");
        DateTime dataHora = DateTime.Parse(Console.ReadLine());

        Agendamento agendamento = new Agendamento
        {
            Cliente = cliente,
            Barbeiro = barbeiroEscolhido,
            DataHora = dataHora,
            Cabelo = cabeloEscolhido,
            Barba = barbaEscolhida,
            Outros = outroEscolhido
        };

        cliente.Agendamentos.Add(agendamento);
        barbeiroEscolhido.Agenda.Add(agendamento);

        Console.WriteLine($"O agendamento foi realizado com sucesso! Preço total: R${agendamento.PrecoTotal}");
    }

    public static void VerAgenda()
    {
        Console.Clear();
        foreach (var barbeiro in barbeiros)
        {
            Console.WriteLine($"Agenda do barbeiro {barbeiro.Nome}:");
            foreach (var agendamento in barbeiro.Agenda)
            {
                Console.WriteLine($"Cliente: {agendamento.Cliente.Nome}, Data e Hora: {agendamento.DataHora}, Preço: R${agendamento.PrecoTotal}");
            }
            Console.WriteLine();
        }
    }

    public static void TelaInicial()
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo à Barbearia do Artorias!");
        Console.WriteLine();
        Console.WriteLine("Sistema de Agendamento");
        Console.WriteLine(@"Você gostaria de: 
1) Agendar um corte 
2) Ver a agenda");
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                AgendarCorte();
                break;
            case 2:
                VerAgenda();
                break;
            default:
                Console.WriteLine("Escolha inválida.");
                break;
        }
    }
    public static void Main()
    {
        TelaInicial();
    }
}