using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Veiculo> veiculos = new List<Veiculo>();
    static List<Garagem> garagens = new List<Garagem>();
    static bool jornadaIniciada = false;

    static void Main()
    {
        IniciarVeiculosEGaragens();

        int option;
        do
        {
            Console.WriteLine("0. Finalizar");
            Console.WriteLine("1. Cadastrar veículo");
            Console.WriteLine("2. Cadastrar garagem");
            Console.WriteLine("3. Iniciar jornada");
            Console.WriteLine("4. Encerrar jornada");
            Console.WriteLine("5. Liberar viagem");
            Console.WriteLine("6. Listar veículos em garagem");
            Console.WriteLine("7. Quantidade de viagens de origem para destino");
            Console.WriteLine("8. Listar viagens de origem para destino");
            Console.WriteLine("9. Quantidade de passageiros transportados de origem para destino");

            Console.Write("Escolha uma opção: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        CadastrarVeiculo();
                        break;
                    case 2:
                        CadastrarGaragem();
                        break;
                    case 3:
                        IniciarJornada();
                        break;
                    case 4:
                        EncerrarJornada();
                        break;
                    case 5:
                        LiberarViagem();
                        break;
                    case 6:
                        ListarVeiculosEmGaragem();
                        break;
                    case 7:
                        QuantidadeViagensOrigemDestino();
                        break;
                    case 8:
                        ListarViagensOrigemDestino();
                        break;
                    case 9:
                        QuantidadePassageirosOrigemDestino();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

        } while (option != 0);
    }

    static void IniciarVeiculosEGaragens()
    {
        veiculos.Add(new Veiculo(1, "ABC123", 5));
        veiculos.Add(new Veiculo(2, "DEF456", 7));
        veiculos.Add(new Veiculo(3, "GHI789", 4));
        veiculos.Add(new Veiculo(4, "JKL012", 6));
        veiculos.Add(new Veiculo(5, "MNO345", 8));
        veiculos.Add(new Veiculo(6, "PQR678", 5));
        veiculos.Add(new Veiculo(7, "STU901", 7));
        veiculos.Add(new Veiculo(8, "VWX234", 6));

        garagens.Add(new Garagem("Congonhas"));
        garagens.Add(new Garagem("Guarulhos"));
    }

    static void CadastrarVeiculo()
    {
        if (!jornadaIniciada)
        {
            Console.Write("Informe o número do veículo: ");
            int numVeiculo = int.Parse(Console.ReadLine());

            Console.Write("Informe a placa do veículo: ");
            string placaVeiculo = Console.ReadLine();

            Console.Write("Informe a lotação do veículo: ");
            int lotacaoVeiculo = int.Parse(Console.ReadLine());

            Veiculo veiculo = new Veiculo(numVeiculo, placaVeiculo, lotacaoVeiculo);
            veiculos.Add(veiculo);

            Console.WriteLine("Veículo cadastrado com sucesso.");
        }
        else
        {
            Console.WriteLine("Não é possível cadastrar veículos durante a jornada.");
        }
    }

    static void CadastrarGaragem()
    {
        if (!jornadaIniciada)
        {
            Console.Write("Informe o nome da garagem: ");
            string nomeGaragem = Console.ReadLine();

            Garagem garagem = new Garagem(nomeGaragem);
            garagens.Add(garagem);

            Console.WriteLine("Garagem cadastrada com sucesso.");
        }
        else
        {
            Console.WriteLine("Não é possível cadastrar garagens durante a jornada.");
        }
    }

    static void IniciarJornada()
    {
        if (!jornadaIniciada)
        {
            DistribuirVeiculos();
            jornadaIniciada = true;
            Console.WriteLine("Jornada iniciada.");
        }
        else
        {
            Console.WriteLine("A jornada já foi iniciada.");
        }
    }

    static void EncerrarJornada()
    {
        jornadaIniciada = false;
        Console.WriteLine("Jornada encerrada.");
    }

    static void DistribuirVeiculos()
    {
        if (veiculos.Count >= garagens.Count)
        {
            for (int i = 0; i < veiculos.Count; i++)
            {
                garagens[i % garagens.Count].AdicionaVeiculo(veiculos[i]);
            }
        }
        else
        {
            Console.WriteLine("Não há veículos suficientes para distribuir para todas as garagens.");
        }
    }

    static void LiberarViagem()
    {
        if (jornadaIniciada)
        {
            Console.Write("Informe a origem da viagem: ");
            string origem = Console.ReadLine();

            Console.Write("Informe o destino da viagem: ");
            string destino = Console.ReadLine();

            Garagem garagemOrigem = garagens.Find(g => g.NomeGaragem == origem);
            Garagem garagemDestino = garagens.Find(g => g.NomeGaragem == destino);

            if (garagemOrigem != null && garagemDestino != null)
            {
                garagemDestino.AdicionarViagem(garagemOrigem);

                Console.WriteLine("Viagem liberada com sucesso.");
            }
            else
            {
                Console.WriteLine("Garagem de origem ou destino não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("A jornada não foi iniciada.");
        }
    }

    static void ListarVeiculosEmGaragem()
    {
        Console.Write("Informe o nome da garagem: ");
        string nomeGaragem = Console.ReadLine();

        Garagem garagem = garagens.Find(g => g.NomeGaragem == nomeGaragem);

        if (garagem != null)
        {
            garagem.ListarVeiculos();
        }
        else
        {
            Console.WriteLine("Garagem não encontrada.");
        }
    }

    static void QuantidadeViagensOrigemDestino()
    {
        Console.Write("Informe a origem da viagem: ");
        string origem = Console.ReadLine();

        Console.Write("Informe o destino da viagem: ");
        string destino = Console.ReadLine();

        Garagem garagemOrigem = garagens.Find(g => g.NomeGaragem == origem);
        Garagem garagemDestino = garagens.Find(g => g.NomeGaragem == destino);

        if (garagemOrigem != null && garagemDestino != null)
        {
            int quantidadeViagens = garagemDestino.QuantidadeViagensRecebidas(garagemOrigem);
            Console.WriteLine($"Quantidade de viagens de {origem} para {destino}: {quantidadeViagens}");
        }
        else
        {
            Console.WriteLine("Garagem de origem ou destino não encontrada.");
        }
    }

    static void ListarViagensOrigemDestino()
    {
        Console.Write("Informe a origem da viagem: ");
        string origem = Console.ReadLine();

        Console.Write("Informe o destino da viagem: ");
        string destino = Console.ReadLine();

        Garagem garagemOrigem = garagens.Find(g => g.NomeGaragem == origem);
        Garagem garagemDestino = garagens.Find(g => g.NomeGaragem == destino);

        if (garagemOrigem != null && garagemDestino != null)
        {
            garagemDestino.ListarViagensRecebidas(garagemOrigem);
        }
        else
        {
            Console.WriteLine("Garagem de origem ou destino não encontrada.");
        }
    }

    static void QuantidadePassageirosOrigemDestino()
    {
        Console.Write("Informe a origem da viagem: ");
        string origem = Console.ReadLine();

        Console.Write("Informe o destino da viagem: ");
        string destino = Console.ReadLine();

        Garagem garagemOrigem = garagens.Find(g => g.NomeGaragem == origem);
        Garagem garagemDestino = garagens.Find(g => g.NomeGaragem == destino);

        if (garagemOrigem != null && garagemDestino != null)
        {
            int quantidadePassageiros = garagemDestino.QuantidadePassageirosRecebidos(garagemOrigem);
            Console.WriteLine($"Quantidade de passageiros de {origem} para {destino}: {quantidadePassageiros}");
        }
        else
        {
            Console.WriteLine("Garagem de origem ou destino não encontrada.");
        }
    }
}

class Veiculo
{
    public int NumVeiculo { get; set; }
    public string PlacaVeiculo { get; set; }
    public int LotacaoVeiculo { get; set; }

    public Veiculo(int numVeiculo, string placaVeiculo, int lotacaoVeiculo)
    {
        NumVeiculo = numVeiculo;
        PlacaVeiculo = placaVeiculo;
        LotacaoVeiculo = lotacaoVeiculo;
    }
}

class Garagem
{
    public string NomeGaragem { get; set; }
    public Stack<Veiculo> VeiculosGaragem { get; private set; }
    public List<Viagem> ViagensGaragem { get; private set; }

    public Garagem(string nomeGaragem)
    {
        NomeGaragem = nomeGaragem;
        VeiculosGaragem = new Stack<Veiculo>();
        ViagensGaragem = new List<Viagem>();
    }

    public void AdicionaVeiculo(Veiculo veiculo)
    {
        VeiculosGaragem.Push(veiculo);
    }

    public void ExcluiVeiculo()
    {
        if (VeiculosGaragem.Count > 0)
        {
            VeiculosGaragem.Pop();
        }
        else
        {
            Console.WriteLine("A pilha de veículos está vazia.");
        }
    }

    public void AdicionarViagem(Garagem origem)
    {
        if (origem.VeiculosGaragem.Count > 0)
        {
            Veiculo veiculo = origem.VeiculosGaragem.Pop();
            this.VeiculosGaragem.Push(veiculo);
            Viagem viagem = new Viagem(veiculo.LotacaoVeiculo, NomeGaragem, origem.NomeGaragem);
            ViagensGaragem.Add(viagem);
        }
        else
        {
            Console.WriteLine("A Garagem de veículos está vazia. Não é possível iniciar uma viagem.");
        }
    }

    public void ExcluiViagens()
    {
        ViagensGaragem.Clear();
    }


    public void ListarVeiculos()
    {
        Console.WriteLine($"Garagem: {NomeGaragem}");
        Console.WriteLine($"Quantidade de veículos: {VeiculosGaragem.Count}");
        Console.WriteLine("Veículos:");
        foreach (Veiculo veiculo in VeiculosGaragem)
        {
            Console.WriteLine($"Número: {veiculo.NumVeiculo}, Placa: {veiculo.PlacaVeiculo}, Lotação: {veiculo.LotacaoVeiculo}");
        }
    }

    public int QuantidadeViagensRecebidas(Garagem origem)
    {
        return ViagensGaragem.Count(v => v.Origem == origem.NomeGaragem);
    }

    public void ListarViagensRecebidas(Garagem origem)
    {
        Console.WriteLine($"Garagem Destino: {NomeGaragem}");
        Console.WriteLine($"Viagens recebidas de {origem.NomeGaragem}:");
        foreach (Viagem viagem in ViagensGaragem.Where(v => v.Origem == origem.NomeGaragem))
        {
            Console.WriteLine($"Passageiros: {viagem.Passageiros}, Origem: {viagem.Origem}");
        }
    }

    public int QuantidadePassageirosRecebidos(Garagem origem)
    {
        return ViagensGaragem.Where(v => v.Origem == origem.NomeGaragem).Sum(v => v.Passageiros);
    }
}

class Viagem
{
    public int Passageiros { get; set; }
    public String Origem { get; set; }
    public String Destino { get; set; }

    public Viagem(int passageiros, string origem, string destino)
    {
        Passageiros = passageiros;
        Origem = origem;
        Destino = destino;
    }
}
