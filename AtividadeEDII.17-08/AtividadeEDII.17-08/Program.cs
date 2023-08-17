using System;

class Aluno
{
    private int id;
    private string nome;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public Aluno()
    {
        Id = -1;
        Nome = " ";
    }

    public Aluno(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public bool PodeMatricular(Curso curso)
    {
        int disciplinasMatriculadas = 0;

        foreach (Disciplina disciplina in curso.Disciplinas)
        {
            if (disciplina != null)
            {
                foreach (Aluno aluno in disciplina.alunos)
                {
                    if (aluno != null && aluno.Id == Id)
                    {
                        disciplinasMatriculadas++;
                        if (disciplinasMatriculadas >= 6)
                        {
                            return false;
                        }
                        break; // O aluno foi encontrado nesta disciplina
                    }
                }
            }
        }

        return true;
    }
}


class Disciplina
{
    public Aluno[] alunos { get; set; }
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Disciplina()
    {
        alunos = new Aluno[15];
        for (int i = 0; i < alunos.Length; i++)
        {
            alunos[i] = new Aluno(-1, " ");
        }
        Id = -1;
        Descricao = " ";
    }

    public Disciplina(int id, string descricao)
    {
        alunos = new Aluno[15];
        for (int i = 0; i < alunos.Length; i++)
        {
            alunos[i] = new Aluno(-1, " ");
        }
        Id = id;
        Descricao = descricao;
    }

    public void MatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < alunos.Length; i++)
        {
            if (alunos[i].Id == -1 && aluno.PodeMatricular(this))
            {
                alunos[i] = aluno;
                break;
            }
        }
    }

    public void DesmatricularAluno(Aluno aluno)
    {
        int alunoIndex = Array.IndexOf(alunos, aluno);
        if (alunoIndex != -1)
        {
            for (int i = alunoIndex; i < alunos.Length - 1; i++)
            {
                alunos[i] = alunos[i + 1];
            }
            alunos[alunos.Length - 1] = new Aluno(-1, " ");
        }
    }
}

class Curso
{
    public Disciplina[] Disciplinas { get; set; }
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Curso()
    {
        Disciplinas = new Disciplina[12];
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            Disciplinas[i] = new Disciplina(-1, " ");
        }
        Id = -1;
        Descricao = " ";
    }

    public Curso(int id, string descricao)
    {
        Disciplinas = new Disciplina[12];
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            Disciplinas[i] = new Disciplina(-1, " ");
        }
        Id = id;
        Descricao = descricao;
    }

    public bool AdicionarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i].Id == -1)
            {
                Disciplinas[i] = disciplina;
                return true;
            }
        }
        return false;
    }

    public Disciplina PesquisarDisciplina(int id)
    {
        foreach (Disciplina disciplina in Disciplinas)
        {
            if (disciplina.Id == id)
            {
                return disciplina;
            }
        }
        return null;
    }

    public bool RemoverDisciplina(Disciplina disciplina)
    {
        int disciplinaIndex = Array.IndexOf(Disciplinas, disciplina);
        if (disciplinaIndex != -1)
        {
            Disciplinas[disciplinaIndex] = new Disciplina(-1, " ");

            for (int i = disciplinaIndex; i < Disciplinas.Length - 1; i++)
            {
                if (Disciplinas[i + 1].Id != -1)
                {
                    Disciplinas[i] = Disciplinas[i + 1];
                    Disciplinas[i + 1] = new Disciplina(-1, " ");
                }
                else
                {
                    break;
                }
            }
            return true;
        }
        return false;
    }
}


class Escola
{
    public Curso[] Cursos { get; set; }

    public Escola()
    {
        Cursos = new Curso[5];
        for (int i = 0; i < Cursos.Length; i++)
        {
            Cursos[i] = new Curso(-1, " ");
        }
    }

    public bool AdicionarCurso(Curso curso)
    {
        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i].Id == -1)
            {
                Cursos[i] = curso;
                return true;
            }
        }
        return false;
    }

    public Curso PesquisarCurso(int id)
    {
        foreach (Curso curso in Cursos)
        {
            if (curso.Id == id)
            {
                return curso;
            }
        }
        return null;
    }

    public bool RemoverCurso(Curso curso)
    {
        int cursoIndex = Array.IndexOf(Cursos, curso);
        if (cursoIndex != -1)
        {
            Cursos[cursoIndex] = new Curso(-1, " ");

            for (int i = cursoIndex; i < Cursos.Length - 1; i++)
            {
                if (Cursos[i + 1].Id != -1)
                {
                    Cursos[i] = Cursos[i + 1];
                    Cursos[i + 1] = new Curso(-1, " ");
                }
                else
                {
                    break;
                }
            }
            return true;
        }
        return false;
    }
    public void PesquisarAluno(string nome)
    {
        int cursos = 0;
        foreach (Curso curso in Cursos)
        {
            if (curso != null)
            {
                foreach (Disciplina disciplina in curso.Disciplinas)
                {
                    if (disciplina != null)
                    {
                        foreach (Aluno aluno in disciplina.alunos)
                        {
                            if (aluno != null && aluno.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                            {
                                 Console.WriteLine("O aluno esta matriculado na matéria: " + disciplina.Descricao);
                                cursos++;
                            }
                        }
                    }
                }
            }
        }
        if(cursos == 0)
        {
            Console.WriteLine("O aluno não está matriculado em nenhuma matéria");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Escola escola = new Escola();

        int opcao = -1;
        while (opcao != 0)
        {
            Console.WriteLine("Opções no seletor:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar curso");
            Console.WriteLine("2. Pesquisar curso");
            Console.WriteLine("3. Remover curso");
            Console.WriteLine("4. Adicionar disciplina no curso");
            Console.WriteLine("5. Pesquisar disciplina");
            Console.WriteLine("6. Remover disciplina do curso");
            Console.WriteLine("7. Matricular aluno na disciplina");
            Console.WriteLine("8. Remover aluno da disciplina");
            Console.WriteLine("9. Pesquisar aluno");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o ID do curso: ");
                    int idCurso = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Digite a descrição do curso: ");
                    string descricaoCurso = Console.ReadLine();
                    Curso novoCurso = new Curso(idCurso, descricaoCurso);
                    if (escola.AdicionarCurso(novoCurso))
                    {
                        Console.WriteLine("Curso adicionado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível adicionar o curso.");
                    }
                    break;
                case 2:
                    Console.Write("Digite o ID do curso a ser pesquisado: ");
                    int idPesquisaCurso = Convert.ToInt32(Console.ReadLine());
                    Curso cursoPesquisado = escola.PesquisarCurso(idPesquisaCurso);
                    if (cursoPesquisado != null)
                    {
                        Console.WriteLine($"Curso encontrado: ID: {cursoPesquisado.Id}, Descrição: {cursoPesquisado.Descricao}");
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 3:
                    Console.Write("Digite o ID do curso a ser removido: ");
                    int idRemoverCurso = Convert.ToInt32(Console.ReadLine());
                    Curso cursoRemover = escola.PesquisarCurso(idRemoverCurso);
                    if (cursoRemover != null && escola.RemoverCurso(cursoRemover))
                    {
                        Console.WriteLine("Curso removido com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível remover o curso.");
                    }
                    break;
                case 4:
                    Console.Write("Digite o ID do curso onde deseja adicionar a disciplina: ");
                    int idCursoDisciplina = Convert.ToInt32(Console.ReadLine());
                    Curso cursoAdicionarDisciplina = escola.PesquisarCurso(idCursoDisciplina);
                    if (cursoAdicionarDisciplina != null)
                    {
                        Console.Write("Digite o ID da disciplina: ");
                        int idDisciplina = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Digite a descrição da disciplina: ");
                        string descricaoDisciplina = Console.ReadLine();
                        Disciplina novaDisciplina = new Disciplina(idDisciplina, descricaoDisciplina);
                        if (cursoAdicionarDisciplina.AdicionarDisciplina(novaDisciplina))
                        {
                            Console.WriteLine("Disciplina adicionada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar a disciplina.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 5:
                    Console.Write("Digite o ID do curso para pesquisar a disciplina: ");
                    int idCursoPesquisaDisciplina = Convert.ToInt32(Console.ReadLine());
                    Curso cursoPesquisaDisciplina = escola.PesquisarCurso(idCursoPesquisaDisciplina);
                    if (cursoPesquisaDisciplina != null)
                    {
                        Console.Write("Digite o ID da disciplina a ser pesquisada: ");
                        int idPesquisaDisciplina = Convert.ToInt32(Console.ReadLine());
                        Disciplina disciplinaPesquisada = cursoPesquisaDisciplina.PesquisarDisciplina(idPesquisaDisciplina);
                        if (disciplinaPesquisada != null)
                        {
                            Console.WriteLine($"Disciplina encontrada: Descrição: {disciplinaPesquisada.Descricao}");
                        }
                        else
                        {
                            Console.WriteLine("Disciplina não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 6:
                    Console.Write("Digite o ID do curso para remover a disciplina: ");
                    int idCursoRemoverDisciplina = Convert.ToInt32(Console.ReadLine());
                    Curso cursoRemoverDisciplina = escola.PesquisarCurso(idCursoRemoverDisciplina);
                    if (cursoRemoverDisciplina != null)
                    {
                        Console.Write("Digite o ID da disciplina a ser removida: ");
                        int idRemoverDisciplina = Convert.ToInt32(Console.ReadLine());
                        Disciplina disciplinaRemover = cursoRemoverDisciplina.PesquisarDisciplina(idRemoverDisciplina);
                        if (disciplinaRemover != null && cursoRemoverDisciplina.RemoverDisciplina(disciplinaRemover))
                        {
                            Console.WriteLine("Disciplina removida com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover a disciplina.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 7:
                    Console.Write("Digite o ID do curso para matricular o aluno: ");
                    int idCursoMatricularAluno = Convert.ToInt32(Console.ReadLine());
                    Curso cursoMatricularAluno = escola.PesquisarCurso(idCursoMatricularAluno);
                    if (cursoMatricularAluno != null)
                    {
                        Console.Write("Digite o ID da disciplina para matricular o aluno: ");
                        int idDisciplinaMatricularAluno = Convert.ToInt32(Console.ReadLine());
                        Disciplina disciplinaMatricularAluno = cursoMatricularAluno.PesquisarDisciplina(idDisciplinaMatricularAluno);
                        if (disciplinaMatricularAluno != null)
                        {
                            Console.Write("Digite o ID do aluno: ");
                            int idAluno = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o nome do aluno: ");
                            string nomeAluno1 = Console.ReadLine();
                            Aluno novoAluno = new Aluno(idAluno, nomeAluno1);
                            disciplinaMatricularAluno.MatricularAluno(novoAluno);
                            Console.WriteLine("Aluno incluído na disciplina.");
                        }
                        else
                        {
                            Console.WriteLine("Disciplina não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 8:
                    Console.Write("Digite o ID do curso para remover o aluno: ");
                    int idCursoRemoverAluno = Convert.ToInt32(Console.ReadLine());
                    Curso cursoRemoverAluno = escola.PesquisarCurso(idCursoRemoverAluno);
                    if (cursoRemoverAluno != null)
                    {
                        Console.Write("Digite o ID da disciplina para remover o aluno: ");
                        int idDisciplinaRemoverAluno = Convert.ToInt32(Console.ReadLine());
                        Disciplina disciplinaRemoverAluno = cursoRemoverAluno.PesquisarDisciplina(idDisciplinaRemoverAluno);
                        if (disciplinaRemoverAluno != null)
                        {
                            Console.Write("Digite o nome do aluno a ser removido: ");
                            string nomeAlunoRemover = Console.ReadLine();
                            foreach (Aluno aluno in disciplinaRemoverAluno.alunos)
                            {
                                if (aluno != null && aluno.Nome.Equals(nomeAlunoRemover, StringComparison.OrdinalIgnoreCase))
                                {
                                    disciplinaRemoverAluno.DesmatricularAluno(aluno);
                                    Console.WriteLine("Aluno removido da disciplina.");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Disciplina não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Curso não encontrado.");
                    }
                    break;
                case 9:
                    Console.Write("Digite o nome do aluno: ");
                    string nomeAluno = Console.ReadLine();
                    escola.PesquisarAluno(nomeAluno);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha uma opção válida.");
                    break;
            }

        }
    }
}
