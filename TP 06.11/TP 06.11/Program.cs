using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Log
{
    public int Id { get; set; }
    public DateTime DtAcesso { get; set; }
    public bool TipoAcesso { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}

public class Ambiente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Log> Logs { get; set; } = new List<Log>();
}

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Ambiente> Ambientes { get; set; } = new List<Ambiente>();
}

public class AmbienteUsuario
{
    public int AmbienteId { get; set; }
    public Ambiente Ambiente { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}

public class AmbienteLog
{
    public int AmbienteId { get; set; }
    public Ambiente Ambiente { get; set; }
    public int LogId { get; set; }
    public Log Log { get; set; }
}

public class Context : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ambiente> Ambientes { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<AmbienteUsuario> AmbientesUsuarios { get; set; }
    public DbSet<AmbienteLog> AmbientesLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TPBanco;Trusted_Connection=True;");
    }
}

class Cadastro
{
    private readonly Context context;

    public Cadastro(Context context)
    {
        this.context = context;
    }

    public void AdicionarUsuario(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
    }

    public bool RemoverUsuario(Usuario usuario)
    {
        if (context.Usuarios.Contains(usuario) && usuario.Ambientes.Count == 0)
        {
            context.Usuarios.Remove(usuario);
            return true;
        }
        return false;
    }

    public Usuario PesquisarUsuario(string nome)
    {
        return context.Usuarios.FirstOrDefault(u => u.Nome == nome);
    }

    public void AdicionarAmbiente(Ambiente ambiente)
    {
        context.Ambientes.Add(ambiente);
    }

    public bool RemoverAmbiente(Ambiente ambiente)
    {
        if (context.Ambientes.Contains(ambiente))
        {
            context.Ambientes.Remove(ambiente);
            return true;
        }
        return false;
    }

    public Ambiente PesquisarAmbiente(string nome)
    {
        return context.Ambientes.FirstOrDefault(a => a.Nome == nome);
    }

    public void Upload()
    {
        context.SaveChanges();
        Console.WriteLine("Dados salvos com sucesso.");
    }

    public void Download()
    {
        context.Database.Migrate();
        Console.WriteLine("Dados carregados com sucesso.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new Context())
        {
            var cadastro = new Cadastro(context);
            Console.WriteLine("Bem-vindo ao sistema de controle de acessos!");
            cadastro.Download(); // Carregar dados ao iniciar o aplicativo

            int opcao;
            do
            {
                MostrarMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        CadastrarAmbiente(cadastro);
                        break;
                    case 2:
                        ConsultarAmbiente(cadastro);
                        break;
                    case 3:
                        ExcluirAmbiente(cadastro);
                        break;
                    case 4:
                        CadastrarUsuario(cadastro);
                        break;
                    case 5:
                        ConsultarUsuario(cadastro);
                        break;
                    case 6:
                        ExcluirUsuario(cadastro);
                        break;
                    case 7:
                        ConcederPermissao(cadastro);
                        break;
                    case 8:
                        RevogarPermissao(cadastro);
                        break;
                    case 9:
                        RegistrarAcesso(cadastro);
                        break;
                    case 10:
                        ConsultarLogs(cadastro);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);

            cadastro.Upload(); // Salvar dados ao encerrar o aplicativo
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Opções para o seletor na interface:");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Cadastrar ambiente");
        Console.WriteLine("2. Consultar ambiente");
        Console.WriteLine("3. Excluir ambiente");
        Console.WriteLine("4. Cadastrar usuário");
        Console.WriteLine("5. Consultar usuário");
        Console.WriteLine("6. Excluir usuário");
        Console.WriteLine("7. Conceder permissão de acesso ao usuário");
        Console.WriteLine("8. Revogar permissão de acesso ao usuário");
        Console.WriteLine("9. Registrar acesso");
        Console.WriteLine("10. Consultar logs de acesso");
    }

    static int LerOpcao()
    {
        Console.Write("Escolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out int opcao))
        {
            return opcao;
        }
        return -1; // Opção inválida
    }

    static void CadastrarAmbiente(Cadastro cadastro)
    {
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var ambiente = new Ambiente { Nome = nomeAmbiente };
        cadastro.AdicionarAmbiente(ambiente);
        Console.WriteLine("Ambiente cadastrado com sucesso.");
    }

    static void ConsultarAmbiente(Cadastro cadastro)
    {
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
        if (ambiente != null)
        {
            Console.WriteLine($"ID: {ambiente.Id}, Nome: {ambiente.Nome}");
        }
        else
        {
            Console.WriteLine("Ambiente não encontrado.");
        }
    }

    static void ExcluirAmbiente(Cadastro cadastro)
    {
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
        if (ambiente != null)
        {
            if (cadastro.RemoverAmbiente(ambiente))
            {
                Console.WriteLine("Ambiente excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Não é possível excluir o ambiente com permissões ativas.");
            }
        }
        else
        {
            Console.WriteLine("Ambiente não encontrado.");
        }
    }

    static void CadastrarUsuario(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        var usuario = new Usuario { Nome = nomeUsuario };
        cadastro.AdicionarUsuario(usuario);
        Console.WriteLine("Usuário cadastrado com sucesso.");
    }

    static void ConsultarUsuario(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        var usuario = cadastro.PesquisarUsuario(nomeUsuario);
        if (usuario != null)
        {
            Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }

    static void ExcluirUsuario(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        var usuario = cadastro.PesquisarUsuario(nomeUsuario);
        if (usuario != null)
        {
            if (cadastro.RemoverUsuario(usuario))
            {
                Console.WriteLine("Usuário excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Não é possível excluir o usuário com permissões ativas.");
            }
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }

    static void ConcederPermissao(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var usuario = cadastro.PesquisarUsuario(nomeUsuario);
        var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
        if (usuario != null && ambiente != null)
        {
            if (!usuario.Ambientes.Contains(ambiente))
            {
                usuario.Ambientes.Add(ambiente);
                using (var context = new Context()) { context.SaveChanges(); }
                Console.WriteLine("Permissão concedida com sucesso.");
            }
            else
            {
                Console.WriteLine("Permissão já concedida.");
            }
        }
        else
        {
            Console.WriteLine("Usuário ou ambiente não encontrado.");
        }
    }

    static void RevogarPermissao(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var usuario = cadastro.PesquisarUsuario(nomeUsuario);
        var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
        if (usuario != null && ambiente != null)
        {
            if (usuario.Ambientes.Contains(ambiente))
            {
                usuario.Ambientes.Remove(ambiente);
                using (var context = new Context()) { context.SaveChanges(); }
                Console.WriteLine("Permissão revogada com sucesso.");
            }
            else
            {
                Console.WriteLine("Permissão não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Usuário ou ambiente não encontrado.");
        }
    }

    static void RegistrarAcesso(Cadastro cadastro)
    {
        Console.Write("Nome do usuário: ");
        string nomeUsuario = Console.ReadLine();
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        Console.Write("Tipo de acesso (1 - Autorizado, 0 - Negado): ");
        if (bool.TryParse(Console.ReadLine(), out bool tipoAcesso))
        {
            var usuario = cadastro.PesquisarUsuario(nomeUsuario);
            var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
            if (usuario != null && ambiente != null)
            {
                var log = new Log
                {
                    DtAcesso = DateTime.Now,
                    TipoAcesso = tipoAcesso,
                    Usuario = usuario
                };
                ambiente.Logs.Add(log);
                using (var context = new Context()) { context.SaveChanges(); }
                Console.WriteLine("Acesso registrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Usuário ou ambiente não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Tipo de acesso inválido.");
        }
    }

    static void ConsultarLogs(Cadastro cadastro)
    {
        Console.Write("Nome do ambiente: ");
        string nomeAmbiente = Console.ReadLine();
        var ambiente = cadastro.PesquisarAmbiente(nomeAmbiente);
        if (ambiente != null)
        {
            Console.WriteLine($"Logs de acesso para o ambiente {ambiente.Nome}:");
            foreach (var log in ambiente.Logs)
            {
                Console.WriteLine($"Data de Acesso: {log.DtAcesso}, Tipo de Acesso: {(log.TipoAcesso ? "Autorizado" : "Negado")}");
            }
        }
        else
        {
            Console.WriteLine("Ambiente não encontrado.");
        }
    }
}
