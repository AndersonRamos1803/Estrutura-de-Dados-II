using System;

class Venda
{
    public int qtde;
    public double valor;

    public double valorMedio()
    {
        if (qtde == 0)
            return 0;
        return valor / qtde;
    }
}

class Vendedor
{
    public int id;
    public string nome;
    public double percComissao;
    public Venda[] asVendas = new Venda[31];

    public void registrarVenda(int dia, Venda venda)
    {
        if (dia >= 1 && dia <= 31)
            asVendas[dia - 1] = venda;
    }

    public double valorVendas()
    {
        double total = 0;
        foreach (Venda venda in asVendas)
        {
            if (venda != null)
                total += venda.valor;
        }
        return total;
    }

    public double valorComissao()
    {
        return valorVendas() * percComissao;
    }
}

class Vendedores
{
    public Vendedor[] osVendedores = new Vendedor[10];
    public int max = 10;
    public int qtde = 0;

       public bool addVendedor(Vendedor v)
    {
        if (qtde < max)
        {
            osVendedores[qtde] = v;
            qtde++;
            return true;
        }
        return false;
    }

    public bool delVendedor(Vendedor v)
    {
        if (qtde > 0)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i] == v)
                {
                    for (int j = i; j < qtde - 1; j++)
                    {
                        osVendedores[j] = osVendedores[j + 1];
                    }
                        osVendedores[qtde-1] = new Vendedor
                        {
                            nome = "",
                            id = -1,
                            percComissao = -1
                        };
                    qtde--;
                    return true;
                }
            }
        }
        return false;
    }

    public Vendedor searchVendedor(int id)
    {
        foreach (Vendedor vend in osVendedores)
        {
            if (vend.id == id)
                return vend;
        }
        return null;
    }

    public double valorVendas()
    {
        double total = 0;
        foreach (Vendedor vendedor in osVendedores)
        {
            if (vendedor.id != -1)
                total += vendedor.valorVendas();
        }
        return total;
    }

    public double valorComissao()
    {
        double total = 0;
        foreach (Vendedor vendedor in osVendedores)
        {
            if (vendedor.id != -1)
                total += vendedor.valorComissao();
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vendedores vendedores = new Vendedores();

        for (int i = 0; i < vendedores.osVendedores.Length; i++)
        {
            vendedores.osVendedores[i] = new Vendedor
            {
                nome = "",
                id = -1,
                percComissao = -1
            };
}

        while (true)
        {
            Console.WriteLine("OPÇÕES:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Cadastrar vendedor");
            Console.WriteLine("2. Consultar vendedor");
            Console.WriteLine("3. Excluir vendedor");
            Console.WriteLine("4. Registrar venda");
            Console.WriteLine("5. Listar vendedores");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcao == 0)
            {
                break;
            }
            else if (opcao == 1)
            {
                if (vendedores.qtde < vendedores.max)
                {
                    Vendedor novoVendedor = new Vendedor();
                    Console.Write("Informe o ID do vendedor: ");
                    bool ok = false;
                    while (ok == false)
                    {
                        int id = int.Parse(Console.ReadLine());
                        if (vendedores.searchVendedor(id) == null)
                        {
                            novoVendedor.id = id;
                            ok = true;
                        }
                        else if(vendedores.searchVendedor(id).id == id)
                        {
                            Console.WriteLine("ID Indisponível!!");
                            Console.Write("Informe o ID do vendedor: ");
                        }
                        else
                        {
                            novoVendedor.id = id;
                            ok = true;
                        }
                        
                    }
                    Console.Write("Informe o nome do vendedor: ");
                    novoVendedor.nome = Console.ReadLine();
                    Console.Write("Informe a porcentagem de comissão do vendedor: ");
                    novoVendedor.percComissao = 0.01 * double.Parse(Console.ReadLine());
                    vendedores.addVendedor(novoVendedor);
                    Console.WriteLine("Vendedor cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Limite máximo de vendedores atingido!");
                }
            }
            else if (opcao == 2)
            {
                Console.Write("Informe o ID do vendedor: ");
                int vendedorId = int.Parse(Console.ReadLine());
                Vendedor vendedorConsultado = new Vendedor() { id = vendedorId };
                Vendedor encontrado = vendedores.searchVendedor(vendedorConsultado.id);
                if (encontrado != null)
                {
                    Console.WriteLine("ID: " + encontrado.id);
                    Console.WriteLine("Nome: " + encontrado.nome);
                    Console.WriteLine("Valor total das vendas: " + encontrado.valorVendas().ToString("C"));
                    Console.WriteLine("Valor da comissão devida: " + encontrado.valorComissao().ToString("C"));
                    for (int dia = 1; dia <= 31; dia++)
                    {
                        if (encontrado.asVendas[dia - 1] != null)
                        {
                            Console.WriteLine("Dia " + dia + ": Valor da venda: " + encontrado.asVendas[dia - 1].valor.ToString("C"));
                        }
                    }
                    Console.WriteLine("Valor médio das vendas diárias: " + (encontrado.valorVendas() / 31).ToString("C"));
                }
                else
                {
                    Console.WriteLine("Vendedor não encontrado!");
                }
            }
            else if (opcao == 3)
            {
                Console.Write("Informe o ID do vendedor a ser excluído: ");
                int vendedorId = int.Parse(Console.ReadLine());
                Vendedor vendedorParaExcluir = new Vendedor() { id = vendedorId };
                Vendedor encontrado = vendedores.searchVendedor(vendedorParaExcluir.id);
                if (encontrado != null)
                {
                    if (encontrado.valorVendas() == 0)
                    {
                        vendedores.delVendedor(encontrado);
                        Console.WriteLine("Vendedor excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não é possível excluir vendedor com vendas associadas!");
                    }
                }
                else
                {
                    Console.WriteLine("Vendedor não encontrado!");
                }
            }
            else if (opcao == 4)
            {
                Console.Write("Informe o ID do vendedor: ");
                int vendedorId = int.Parse(Console.ReadLine());
                Vendedor vendedorParaRegistrarVenda = new Vendedor() { id = vendedorId };
                Vendedor encontrado = vendedores.searchVendedor(vendedorParaRegistrarVenda.id);
                if (encontrado != null)
                {
                    Console.Write("Informe o dia da venda (1 a 31): ");
                    int diaVenda = int.Parse(Console.ReadLine());
                    if (diaVenda >= 1 && diaVenda <= 31)
                    {
                        Venda novaVenda = new Venda();
                        Console.Write("Informe a quantidade de itens vendidos: ");


                        novaVenda.qtde = int.Parse(Console.ReadLine());
                        Console.Write("Informe o valor total da venda: ");
                        novaVenda.valor = double.Parse(Console.ReadLine());
                        encontrado.registrarVenda(diaVenda, novaVenda);
                        Console.WriteLine("Venda registrada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Dia inválido!");
                    }
                }
                else
                {
                    Console.WriteLine("Vendedor não encontrado!");
                }
            }
            else if (opcao == 5)
            {
                Console.WriteLine("LISTA DE VENDEDORES:");
                foreach (Vendedor vendedor in vendedores.osVendedores)
                {
                    if (vendedor.id != -1)
                    {
                        Console.WriteLine("ID: " + vendedor.id);
                        Console.WriteLine("Nome: " + vendedor.nome);
                        Console.WriteLine("Valor total das vendas: " + vendedor.valorVendas().ToString("C"));
                        Console.WriteLine("Valor da comissão devida: " + vendedor.valorComissao().ToString("C"));
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Valor total de vendas de todos os vendedores: " + vendedores.valorVendas().ToString("C"));
                Console.WriteLine("Valor total de comissão devida de todos os vendedores: " + vendedores.valorComissao().ToString("C"));
            }
            else
            {
                Console.WriteLine("Opção inválida! Escolha uma opção válida.");
            }
        }
    }
}
