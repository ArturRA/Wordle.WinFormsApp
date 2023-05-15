using System.Globalization;

namespace Wordle.WinFormsApp
{
    public partial class Form1 : Form
    {
        // Lista de todos os botoes do alfabeto
        private List<Button> ListaBotoesAlfabeto { get; set; } = new List<Button>();

        // Escolhendo palavra sorteada
        private List<char> PalavraSorteada { get; set; } = new List<char>();

        // Lista de todos os panels do jogo
        private List<List<Button>> ListaDosBotoesLinhasEColunas { get; set; } = new List<List<Button>>();

        private int ButtonRow { get; set; } = 0;
        private int ButtonCollum { get; set; } = 0;

        public void ConfigurarListaDeBotoesAlfabeto()
        {
            foreach (Button botao in tableBotoesAlfabeto.Controls)
            {
                ListaBotoesAlfabeto.Add(botao);
                botao.Click += AdicionarLetraAoPanel;
            }
        }

        private void AdicionarLetraAoPanel(object? sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (ButtonRow is >= 0 and <= 4
             && ButtonCollum is >= 0 and <= 4)
            {
                ListaDosBotoesLinhasEColunas[ButtonRow][ButtonCollum].Text = button.Text;
                if (ButtonCollum < 4) ButtonCollum++;
            }
        }

        public void ConfigurarListaDosPanels()
        {
            List<Button> row0 = new List<Button> { buttonL0C0, buttonL0C1, buttonL0C2, buttonL0C3, buttonL0C4 };
            List<Button> row1 = new List<Button> { buttonL1C0, buttonL1C1, buttonL1C2, buttonL1C3, buttonL1C4 };
            List<Button> row2 = new List<Button> { buttonL2C0, buttonL2C1, buttonL2C2, buttonL2C3, buttonL2C4 };
            List<Button> row3 = new List<Button> { buttonL3C0, buttonL3C1, buttonL3C2, buttonL3C3, buttonL3C4 };
            List<Button> row4 = new List<Button> { buttonL4C0, buttonL4C1, buttonL4C2, buttonL4C3, buttonL4C4 };

            ListaDosBotoesLinhasEColunas.Add(row0);
            ListaDosBotoesLinhasEColunas.Add(row1);
            ListaDosBotoesLinhasEColunas.Add(row2);
            ListaDosBotoesLinhasEColunas.Add(row3);
            ListaDosBotoesLinhasEColunas.Add(row4);
        }

        public List<char> ObterPalavraSorteada()
        {
            // Lista de palavras
            List<string> listaDePalavras = new List<string> {
                    "�cido", "adiar", "�mpar", "algar", "amado", "amigo", "anexo", "anuir", "aonde", "apelo",
                    "aqu�m", "argil", "arroz", "assar", "atr�s", "�vido", "azeri", "babar", "bagre", "banho",
                    "barco", "bicho", "bolor", "brasa", "brava", "brisa", "bruto", "bulir", "caixa", "cansa",
                    "chato", "chave", "chefe", "choro", "chulo", "claro", "cobre", "corte", "curar", "deixo",
                    "dizer", "dogma", "dores", "duque", "enfim", "estou", "exame", "falar", "fardo", "farto",
                    "fatal", "feliz", "ficar", "fogue", "for�a", "forno", "fraco", "fugir", "fundo", "f�ria",
                    "gaita", "gasto", "geada", "gelar", "gosto", "grito", "gueto", "honra", "humor", "idade",
                    "ideia", "�dolo", "igual", "imune", "�ndio", "�ngua", "irado", "isola", "janta", "jovem",
                    "juizo", "largo", "laser", "leite", "lento", "lerdo", "levar", "lidar", "lindo", "l�rio",
                    "longe", "luzes", "magro", "maior", "malte", "mamar", "manto", "marca", "matar", "meigo",
                    "meios", "mel�o", "mesmo", "metro", "mimos", "moeda", "moita", "molho", "morno", "morro",
                    "motim", "muito", "mural", "naipe", "nasci", "natal", "naval", "ninar", "n�vel", "nobre",
                    "noite", "norte", "nuvem", "oeste", "ombro", "ordem", "�rg�o", "�sseo", "ossos", "outro",
                    "ouvir", "palma", "pardo", "passe", "p�tio", "peito", "p�los", "perdo", "per�l", "perto",
                    "pezar", "piano", "picar", "pilar", "pingo", "pione", "pista", "poder", "por�m", "prado",
                    "prato", "prazo", "pre�o", "prima", "primo", "pular", "quero", "quota", "raiva", "rampa",
                    "rango", "reais", "reino", "rezar", "risco", "ro�ar", "rosto", "roubo", "russo", "saber",
                    "sacar", "salto", "samba", "santo", "selar", "selos", "senso", "ser�o", "serra", "servo",
                    "sexta", "sinal", "sobra", "sobre", "s�cio", "sorte", "subir", "sujei", "sujos", "tal�o",
                    "talha", "tanga", "tarde", "tempo", "tenho", "ter�o", "terra", "tes�o", "tocar", "lacre",
                    "laico", "lamba", "lambo", "largo", "larva", "lasca", "laser", "laura", "lavra", "leigo",
                    "leite", "leito", "leiva", "lenho", "lento", "leque", "lerdo", "les�o", "lesma", "levar",
                    "libra", "limbo", "lindo", "l�neo", "l�rio", "lisar", "lista", "livro", "logar", "lombo",
                    "lotes", "louca", "louco", "louro", "lugar", "luzes", "macio", "ma�om", "maior", "malha",
                    "malte", "mamar", "mam�e", "manto", "mar�o", "maria", "marra", "marta", "matar", "medir",
                    "meigo", "meios", "mel�o", "menta", "menti", "mesmo", "metro", "miado", "m�dia", "mielo",
                    "mielo", "milho", "mimos", "minar", "minha", "miolo", "mirar", "missa", "mitos", "moeda",
                    "mo�do", "moita", "molde", "molho", "monar", "monja", "moral", "morar", "morda", "morfo",
                    "morte", "mosca", "mosco", "motim", "motor", "mudar", "muito", "mular", "mulas", "m�mia",
                    "mural", "extra", "falar", "falta", "fardo", "farol", "farto", "fatal", "feixe", "festa",
                    "feudo", "fezes", "fiapo", "fibra", "ficha", "fidel", "fil�o", "filho", "firma", "fisco",
                    "fisga", "fluir", "for�a", "forma", "forte", "fraco", "frade", "friso", "frito", "fugaz",
                    "fugir", "fundo", "furor", "furto", "fuzil", "gabar", "gaita", "galho", "ganho", "garoa",
                    "garra", "garro", "garvo", "gasto", "gaupe", "gazua", "geada", "gemer", "germe", "gigas",
                    "girar", "gizar", "globo", "gosto", "gr�os", "gra�a", "grava", "grito", "grude", "haver",
                    "haver", "hiato", "hidra", "h�fen", "h�mel", "horas", "hotel", "humor", "ideal", "�dolo",
                    "igual", "ileso", "imune", "irado", "isola", "jarra", "jaula", "jegue", "jeito", "jogar",
                    "jovem", "ju�za", "juizo", "julho", "junho", "jurar", "justa"
                };

            // Escolhendo palavra sorteada
            Random random = new Random();
            int numeroParaEscolherAPalavraSorteada = random.Next(listaDePalavras.Count());
            List<char> palavraSorteada = new List<char>();
            palavraSorteada.AddRange(listaDePalavras[numeroParaEscolherAPalavraSorteada]);
            label1.Text = String.Concat(PalavraSorteada);

            return palavraSorteada;
        }

        public Form1()
        {
            InitializeComponent();
            ConfigurarListaDeBotoesAlfabeto();
            ConfigurarListaDosPanels();
            PalavraSorteada = ObterPalavraSorteada();
            // Mude para true a linha abaixo para mostrar a palavra secreta
            label1.Visible = false;
        }


        private void buttonDeletarUltimoCharacter(object sender, EventArgs e)
        {
            if (ButtonRow is >= 0 and <= 4
             && ButtonCollum is >= 0 and <= 4)
            {
                ListaDosBotoesLinhasEColunas[ButtonRow][ButtonCollum].Text = "";
                if (ButtonCollum > 0) ButtonCollum--;
            }
        }

        private void buttonConfirmarTentativa(object sender, EventArgs e)
        {
            List<char> palavraParaTestar = new List<char>();

            ListaDosBotoesLinhasEColunas[ButtonRow].ForEach(b => palavraParaTestar.Add(Convert.ToChar(b.Text.ToLower())));

            if (ButtonCollum == 4)
            {
                // confirmar e atualiza as cores das letras
                ListaDosBotoesLinhasEColunas[ButtonRow].ForEach(b => AtualizarCorButton(b));
                // checa se ganhou ou n�o
                if (PalavrasSaoIguais(palavraParaTestar, PalavraSorteada))
                {
                    FimDoRound();

                    if (MessageBox.Show("Parabens voce acertou\n" +
                                       $"Deseja jogar novamente?", "Jogar Novamente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ResetDoTabuleiro();
                    }
                }
                else
                {
                    if (ButtonRow is < 4)
                    {
                        ButtonRow++;
                        ButtonCollum = 0;
                    }
                    else
                    {
                        FimDoRound();
                        if (MessageBox.Show($"Que pena voce perdeu a palavra era: {String.Concat(PalavraSorteada)}\n" +
                                            $"Deseja jogar novamente?", "Jogar Novamente",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ResetDoTabuleiro();
                        }
                    }
                }
            }
        }

        private bool VerificaLetraSeIgualSemConsiderarAcento(char letra1, char letra2)
        {
            return String.Compare(Convert.ToString(letra1), Convert.ToString(letra2), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0;
        }

        private bool PalavrasSaoIguais(List<char> palavraTestar, List<char> palavraSorteada)
        {
            for (int i = 0; i < palavraTestar.Count; i++)
                if (!VerificaLetraSeIgualSemConsiderarAcento(palavraTestar[i], palavraSorteada[i]))
                    return false;

            return true;
        }

        private void AtualizarCorButton(Button buttonDaTentativa)
        {
            char charParaComparar = Convert.ToChar(buttonDaTentativa.Text.ToLower());
            Button buttonDoAlfabeto = ListaBotoesAlfabeto.FirstOrDefault(b => VerificaLetraSeIgualSemConsiderarAcento(Convert.ToChar(b.Text.ToLower()), charParaComparar));
            // Checa se o char existe na palabra se n�o existe seta dark gray
            if (!PalavraSorteada.Exists(c => VerificaLetraSeIgualSemConsiderarAcento(c, charParaComparar)))
            {
                buttonDoAlfabeto.BackColor = Color.DarkGray;
                buttonDaTentativa.BackColor = Color.DarkGray;
                return;
            }

            // Checa se o char existe na palabra e esta na posi��o correta utilizando o Tabindex(posi��o na tablelayout) e fazendo mod 5 se sim seta light green
            if (VerificaLetraSeIgualSemConsiderarAcento(charParaComparar, PalavraSorteada[buttonDaTentativa.TabIndex%5]))
            {
                buttonDoAlfabeto.BackColor = Color.LightGreen;
                buttonDaTentativa.BackColor = Color.LightGreen;
                return;
            }

            // Em ultimo caso o char existe na palavra, mas esta na posi��o errada e a seta light yellow
            buttonDaTentativa.BackColor = Color.Yellow;

            // Se o bot�o do alfabeto n�o estiver sido setado como verde ainda ent�o e so ent�o setar ele como amarelo
            if (!(buttonDoAlfabeto.BackColor == Color.LightGreen))
                buttonDoAlfabeto.BackColor = Color.Yellow;
        }

        private void FimDoRound()
        {
            ListaBotoesAlfabeto.ForEach(b => b.Enabled = false);
            buttonReturn.Enabled = false;
            buttonConfirmar.Enabled = false;
        }

        private void ResetDoTabuleiro()
        {
            ListaBotoesAlfabeto.ForEach(b => b.Enabled = true);
            ListaBotoesAlfabeto.ForEach(b => b.BackColor = default(Color));
            ListaDosBotoesLinhasEColunas.ForEach(l => l.ForEach(b => b.BackColor = Color.Tan));
            ListaDosBotoesLinhasEColunas.ForEach(l => l.ForEach(b => b.ResetText()));
            buttonReturn.Enabled = true;
            buttonConfirmar.Enabled = true;
        }
    }
}