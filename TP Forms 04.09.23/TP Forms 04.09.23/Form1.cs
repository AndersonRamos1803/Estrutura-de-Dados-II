namespace TP_Forms_04._09._23
{
    public partial class Form1 : Form
    {
        public class Data
        {
            public int Dia { get; set; }
            public int Mes { get; set; }
            public int Ano { get; set; }

            public Data(int dia, int mes, int ano)
            {
                Dia = dia;
                Mes = mes;
                Ano = ano;
            }

            public static bool TryParse(string dataStr, out Data data)
            {
                data = null;

                string[] partes = dataStr.Split('/');
                if (partes.Length == 3 && int.TryParse(partes[0], out int dia) &&
                    int.TryParse(partes[1], out int mes) && int.TryParse(partes[2], out int ano))
                {
                    data = new Data(dia, mes, ano);
                    return true;
                }

                return false;
            }

            public override string ToString()
            {
                return $"{Dia:D2}/{Mes:D2}/{Ano:D4}";
            }
        }




        public class Telefone
        {
            public string Tipo { get; set; }
            public string Numero { get; set; }
            public bool Principal { get; set; }
        }

        public class Contato
        {
            public string Email { get; set; }
            public string Nome { get; set; }
            public Data DtNasc { get; set; }
            public List<Telefone> Telefones { get; } = new List<Telefone>();

            public int GetIdade()
            {
                DateTime hoje = DateTime.Now;
                int idade = hoje.Year - DtNasc.Ano;
                if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
                {
                    idade--;
                }
                return idade;
            }

            public void AdicionarTelefone(Telefone telefone)
            {
                Telefones.Add(telefone);
            }

            public string GetTelefonePrincipal()
            {
                foreach (var telefone in Telefones)
                {
                    if (telefone.Principal)
                    {
                        return telefone.Numero;
                    }
                }
                return "Nenhum telefone principal encontrado";
            }

            public override string ToString()
            {
                string telefonePrincipal = GetTelefonePrincipal();
                return $"Nome: {Nome}\nEmail: {Email}\nData de Nascimento: {DtNasc}\nTelefone Principal: {telefonePrincipal}";
            }

            public override bool Equals(object obj)
            {
                if (obj is Contato contato)
                {
                    return Email.Equals(contato.Email, StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }

        public class Contatos
        {
            private readonly List<Contato> agenda = new List<Contato>();

            public bool Adicionar(Contato contato)
            {
                if (!agenda.Contains(contato))
                {
                    agenda.Add(contato);
                    return true;
                }
                return false;
            }

            public Contato Pesquisar(Contato contato)
            {
                foreach (var c in agenda)
                {
                    if (c.Equals(contato))
                    {
                        return c;
                    }
                }
                return null;
            }

            public bool Alterar(Contato contato)
            {
                int index = agenda.IndexOf(contato);
                if (index != -1)
                {
                    agenda[index] = contato;
                    return true;
                }
                return false;
            }

            public bool Remover(Contato contato)
            {
                return agenda.Remove(contato);
            }

            public void ListarContatos()
            {
                foreach (var contato in agenda)
                {
                    Console.WriteLine(contato.ToString());
                    Console.WriteLine("------------------------");
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

  
            private List<Contato> contatos = new List<Contato>();
            private Contato contatoSelecionado = null;

        private void novo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

             private void adicionar_Click(object sender, EventArgs e)
              {
                string email = textBox1.Text;
                string nome = textBox2.Text;

                if(Data.TryParse(textBox3.Text + "/" + textBox4.Text + "/" + textBox5.Text, out Data dataNasc))
                {
                    string tipo = tipoTelefone.SelectedItem as string;
                    string numero = textBox6.Text;
                    bool principal = principalTelefone.Checked;

                    Telefone telefone = new Telefone { Tipo = tipo, Numero = numero, Principal = principal };
                    Contato novoContato = new Contato { Email = email, Nome = nome, DtNasc = dataNasc };
                    novoContato.AdicionarTelefone(telefone);

                    contatos.Add(novoContato);

                    AtualizarListaContatos();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Data de nascimento inválida. Use o formato dd/mm/aaaa.");
                }
            }


        
          private void salvar_Click(object sender, EventArgs e)
             {
                if (contatoSelecionado != null)
                {
                    string email = textBox1.Text;
                    string nome = textBox2.Text;

                    if (Data.TryParse(textBox3.Text + "/" + textBox4.Text + "/" + textBox5.Text, out Data dataNasc))
                    {
                    string? tipo = tipoTelefone.SelectedItem as string;
                    string numero = textBox6.Text;
                    bool principal = principalTelefone.Checked;

                    Telefone telefone = new Telefone { Tipo = tipo, Numero = numero, Principal = principal };
                        contatoSelecionado.Email = email;
                        contatoSelecionado.Nome = nome;
                        contatoSelecionado.DtNasc = dataNasc;
                        contatoSelecionado.Telefones.Clear();
                        contatoSelecionado.AdicionarTelefone(telefone);

                        AtualizarListaContatos();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Data de nascimento inválida. Use o formato dd/mm/aaaa.");
                    }
                }
            }

         private void pesquisar_Click(object sender, EventArgs e)
          {
                string emailPesquisa = textBox1.Text;
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Contato contatoPesquisado = contatos.Find(match: c => c.Email.Equals(emailPesquisa, StringComparison.OrdinalIgnoreCase));
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

            if (contatoPesquisado != null)
                {
                    contatoSelecionado = contatoPesquisado;
                    PreencherCampos(contatoPesquisado);
                }
                else
                {
                    MessageBox.Show("Contato não encontrado.");
                    LimparCampos();
                }
            }

             private void remover_Click(object sender, EventArgs e)
             {
                if (contatoSelecionado != null)
                {
                    contatos.Remove(contatoSelecionado);
                    AtualizarListaContatos();
                    LimparCampos();
                }
            }

        private void listar_Click(object sender, EventArgs e)
        {
                AtualizarListaContatos();
            }

            private void AtualizarListaContatos()
            {
            dataGridView1.Rows.Clear();

                foreach (Contato contato in contatos)
                {
                    int idade = contato.GetIdade();
                    string telefonePrincipal = contato.GetTelefonePrincipal();

                dataGridView1.Rows.Add(contato.Email, contato.Nome, contato.DtNasc.ToString(), idade, telefonePrincipal);
                }
            }

            private void PreencherCampos(Contato contato)
            {
                textBox1.Text = contato.Email;
                textBox2.Text = contato.Nome;
                textBox3.Text = contato.DtNasc.Dia.ToString();
                textBox4.Text = contato.DtNasc.Mes.ToString();
                textBox5.Text = contato.DtNasc.Ano.ToString();
                principalTelefone.Checked = contato.GetTelefonePrincipal() == textBox6.Text;
                dataGridView2.Rows.Clear();
                dataGridView2.Rows.Add(contato.Telefones[0].Tipo as String, contato.Telefones[0].Numero, contato.Telefones[0].Principal ? "Principal" : null);

            // Define o tipo selecionado no ComboBox
            tipoTelefone.SelectedItem = contato.Telefones.Count > 0 ? contato.Telefones[0].Tipo : null;
            }

            private void LimparCampos()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                tipoTelefone.SelectedItem = null;
                principalTelefone.Checked = false;
                contatoSelecionado = null;
            }

    }
    }

