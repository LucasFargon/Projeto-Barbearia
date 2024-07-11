using Barbearia;
class Program
{
    static List<Barbeiro> barbeiros = new List<Barbeiro>
        {
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

    public static void Main()
    {
        Console.WriteLine("Bem-vindo à Barbearia do Artorias!");
        Console.WriteLine();
        Console.WriteLine("Sistema de Agendamento");
        Console.WriteLine("Você gostaria de: 1) Agendar um corte 2) Ver a agenda?");
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

    public static void AgendarCorte()
    {
        Console.WriteLine("Digite seu nome:");
        string nomeCliente = Console.ReadLine();
        Console.WriteLine("Digite seu CPF:");
        string cpfCliente = Console.ReadLine();
        Cliente cliente = new Cliente { Nome = nomeCliente, Cpf = cpfCliente };

        Console.WriteLine("Escolha um barbeiro:");
        foreach (var barbeiro in barbeiros)
        {
            Console.WriteLine($"{barbeiro.Id}) {barbeiro.Nome}");
        }

        string idBarbeiro = Console.ReadLine();
        Barbeiro barbeiroEscolhido = barbeiros.Find(b => b.Id == idBarbeiro);

        Console.WriteLine("Escolha o tipo de corte de cabelo:");
        foreach (var cabelo in cortesCabelo)
        {
            Console.WriteLine($"{cortesCabelo.IndexOf(cabelo)}) {cabelo.Nome} - R${cabelo.Preco}");
        }
        Cabelo cabeloEscolhido = cortesCabelo[int.Parse(Console.ReadLine())];

        Console.WriteLine("Escolha o tipo de barba:");
        foreach (var barba in cortesBarba)
        {
            Console.WriteLine($"{cortesBarba.IndexOf(barba)}) {barba.Nome} - R${barba.Preco}");
        }
        Barba barbaEscolhida = cortesBarba[int.Parse(Console.ReadLine())];

        Console.WriteLine("Escolha um pedido adicional:");
        foreach (var outro in outrosTipos)
        {
            Console.WriteLine($"{outrosTipos.IndexOf(outro)}) {outro.Nome} - R${outro.Preco}");
        }
        Outros outroEscolhido = outrosTipos[int.Parse(Console.ReadLine())];

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
}