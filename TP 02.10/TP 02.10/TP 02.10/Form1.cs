namespace TP_02._10
{

    public partial class Form1 : Form
    {
        public class Senha
        {
            public int Id { get; private set; }
            public DateTime DataGerac { get; private set; }
            public DateTime HoraGerac { get; private set; }
            public DateTime DataAtend { get; set; }
            public DateTime HoraAtend { get; set; }

            public Senha(int id)
            {
                Id = id;
                DataGerac = DateTime.Now;
                HoraGerac = DateTime.Now;
            }

            public string DadosParciais()
            {
                return $"{Id}-{DataGerac}-{HoraGerac}";
            }

            public string DadosCompletos()
            {
                return $"{Id}-{DataGerac}-{HoraGerac}-{DataAtend}-{HoraAtend}";
            }
        }

        // Classe Senhas
        public class Senhas
        {
            private Queue<Senha> filaSenhas = new Queue<Senha>();
            private int proximoAtendimento = 1;

            public Senhas()
            {
            }

            public void Gerar()
            {
                Senha novaSenha = new Senha(proximoAtendimento);
                filaSenhas.Enqueue(novaSenha);
                proximoAtendimento++;
            }

            public Senha Remover()
            {
                return filaSenhas.Dequeue();
            }

            public Queue<Senha> ListarSenhas()
            {
                Queue<Senha> listaSenhas = new Queue<Senha>(filaSenhas);
                return listaSenhas;
            }

        }

        // Classe Guiche
        public class Guiche
        {
            public int Id { get; private set; }
            private Queue<Senha> atendimentos = new Queue<Senha>();

            public Guiche()
            {
                Id = 0;
            }

            public Guiche(int id)
            {
                Id = id;
            }

            public bool Chamar(Senha filaSenha)
            {
                if (filaSenha!=null)
                {
                    Senha senhaChamada = filaSenha;
                    senhaChamada.DataAtend = DateTime.Now;
                    senhaChamada.HoraAtend = DateTime.Now;
                    atendimentos.Enqueue(senhaChamada);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public Queue<Senha> ListarAtendimentos()
            {
                Queue<Senha> listaSenhas = new Queue<Senha>(atendimentos);
                return listaSenhas;
            }
        }

        // Classe Guiches
        public class Guiches
        {
            private List<Guiche> listaGuiches = new List<Guiche>();

            public Guiches()
            {
            }

            public void Adicionar(Guiche guiche)
            {
                listaGuiches.Add(guiche);
            }

            public Guiche ObterGuichePorId(int id)
            {
                foreach (Guiche guiche in listaGuiches)
                {
                    if (guiche.Id == id)
                    {
                        return guiche;
                    }
                }

                return null; // Retorna null se nenhum guichê com o ID especificado for encontrado.
            }

        }

        private Senhas sistemaSenhas = new Senhas();
        private Guiches sistemaGuiches = new Guiches();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sistemaSenhas.Gerar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Queue<Senha> senhas = sistemaSenhas.ListarSenhas();

            // Limpa o conteúdo existente no RichTextBox
            richTextBox2.Clear();

            // Adiciona as senhas ao RichTextBox
            foreach (Senha senha in senhas)
            {
                richTextBox2.AppendText($"{senha.Id} - {senha.DataGerac} - {senha.HoraGerac}\n");
            }
        }
        int guicheId = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            guicheId++;
            String novo = guicheId.ToString();
            sistemaGuiches.Adicionar(new Guiche(guicheId));
            label1.Text = novo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int guicheId2;
            if (int.TryParse(textBox1.Text, out guicheId2))
            {
                Guiche guiche = sistemaGuiches.ObterGuichePorId(guicheId2);
                if (guiche != null)
                {
                    guiche.Chamar(sistemaSenhas.Remover());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int guicheId2;
               
            if (int.TryParse(textBox1.Text, out guicheId2))
            {
                Guiche guiche = sistemaGuiches.ObterGuichePorId(guicheId2);
                if (guiche != null)
                {
                    Queue<Senha> atendimentos = guiche.ListarAtendimentos();
                    // Limpa o conteúdo existente no RichTextBox
                    richTextBox3.Clear();

                    // Adiciona as senhas ao RichTextBox
                    foreach (Senha atendimento in atendimentos)
                    {
                        richTextBox3.AppendText($"{atendimento.Id} - {atendimento.DataGerac}- {atendimento.HoraGerac}, " +
                            $"{atendimento.DataAtend} - {atendimento.HoraAtend}\n");
                    }
                }
            }
        }
    }
}