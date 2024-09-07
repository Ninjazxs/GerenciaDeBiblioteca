using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace GerenciamentodeBiblioteca
{
    class Principal
    {
        static void Main(string []args)
        {

            Dictionary<string, string> ColecaodeLivrosInfantis = new Dictionary<string, string>()
            {
                {"o menino maluquinho", "O menino maluquinho"},
                {"a galinha dos ovos de ouro", "A galinha dos ovos de ouro"},
                {"o homem cão", "O homem cão"},
                {"o pequeno peregrino","O pequeno peregrino"}
            };

            Dictionary<string, string> ColecaodeLivrosdeMisterio = new Dictionary<string, string>()
            {
                {"a ilha misteriosa", "A ilha misteriosa"},
                {"ninguem vai te ouvir gritar", "Ninguem vai te ouvir gritar"},
                {"o misterio da casa verde", "O misterio da casa verde"},
                {"o longo adeus", "O longo adeus"}
            };

            Livro LivrosParaInfancia = new Livro( ColecaodeLivrosInfantis);
            Livro LivrosdeMisterio = new Livro( ColecaodeLivrosdeMisterio);


            Menu menu = new Menu(ColecaodeLivrosInfantis, ColecaodeLivrosdeMisterio);
            menu.DrawScreen();

            /*
            LivrosParaInfancia.Emprestar(ColecaodeLivrosInfantis, "O menino maluquinho");
            LivrosdeMisterio.Emprestar(ColecaodeLivrosdeMisterio, "Ninguem vai te ouvir gritar");
            Console.WriteLine("\n");

            Console.WriteLine("-----------------------");
            Console.WriteLine("Livros infantis disponíveis : ");

            LivrosParaInfancia.ExibirLivrosDisponiveis(ColecaodeLivrosInfantis);
            LivrosdeMisterio.ExibirLivrosDisponiveis(ColecaodeLivrosdeMisterio);
            */
        }
    }

    public class Livro 
    {
        public string TipoDoLivro {get; set;}

        public List<Dictionary<string, string>> Livros {get; set;} = new List<Dictionary<string, string>>(2);

        public Livro(Dictionary<string, string> livros)
        {
            
            Livros.Add(livros);
        }

        virtual public void Emprestar(Dictionary<string, string> listadeLivros, string livroAserEmprestado)
        {   
            if (listadeLivros.ContainsKey(livroAserEmprestado))
            {
                listadeLivros.Remove(livroAserEmprestado);
                Console.WriteLine($"O livro : {livroAserEmprestado}, foi emprestado com sucesso \n");   
            } else {
                Console.WriteLine($"O livro : {livroAserEmprestado}, não existe na bilbioteca ou já está sendo emprestado");
            }
        }

        virtual public void Devolver(Dictionary<string, string> livros, string livroAserDevolvido)
        {   
            if (livros.ContainsKey(livroAserDevolvido) == false)
            {
                livros.Add(livroAserDevolvido, livroAserDevolvido);
                Console.WriteLine($"O livro {livroAserDevolvido} foi devolvido com sucesso para a biblioteca \n");   
            } else {
                Console.WriteLine($"O livro {livroAserDevolvido} que você está tentando devolver está incorreto ou já faz parte da biblioteca ");
            }
        }
    
        virtual public void ExibirLivrosDisponiveis(Dictionary<string, string> tipodoLivro)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Livros que ainda estão disponíveis : ");
            foreach (KeyValuePair<string, string> livros in tipodoLivro)
            {
                Console.WriteLine(livros.Value); 
            }
        }
    }

    public class Menu : Livro{

        private Dictionary<string, string> colecaodeLivrosInfantis;
        private Dictionary<string, string> colecaodeLivrosMisterio;

        public Menu(Dictionary<string, string> livrosInfantis, Dictionary<string, string> livrosMisterio)
        : base (livrosMisterio)
        {
            this.colecaodeLivrosInfantis = livrosInfantis;
            this.colecaodeLivrosMisterio = livrosMisterio;
        }

        public void DrawScreen()
        {


            Console.WriteLine("Seja bem-vindo a biblioteca!\n");
            Console.WriteLine("Você pode explorar livros dos gênero de Mistério e Infantis. 1: Mistério, 2: Infantis, 3: Sair\n");
            Console.WriteLine("Qual você deseja acessar?\n");

            int GenerodoLivro = Convert.ToInt32(Console.ReadLine());

            switch (GenerodoLivro)
            {
                case 1: 
                    Console.Clear();
                    ExibirLivrosDisponiveis(colecaodeLivrosMisterio);
                    Console.WriteLine(" ");
                    Console.WriteLine("Você tem gostaria de Pegar ou devolver algum livro? 1: Pegar, 2: Devolver,");
                break;
                    
                case 2:  
                    Console.Clear();
                    ExibirLivrosDisponiveis(colecaodeLivrosInfantis);
                    Console.WriteLine(" ");
                    Console.WriteLine("Você tem gostaria de Pegar ou devolver algum livro? 1: Pegar, 2: Devolver, 3: Voltar");
                break;

                case 3:
                    Console.WriteLine("Saindo da biblioteca ...");
                    Environment.Exit(0); 
                break;

                default:
                    Console.WriteLine("O número que você digitou está incorreto ou tipo de livro que você escolheu não existe");
                break;
            }

            int acaoaserExecutada = Convert.ToInt32(Console.ReadLine);

            switch (acaoaserExecutada)
            {
                case 1 :  break;
            }
        }

        public override void ExibirLivrosDisponiveis(Dictionary<string, string> ColecaoaserMostrada)
        {
            base.ExibirLivrosDisponiveis(ColecaoaserMostrada);
        }

        public override void Emprestar(Dictionary<string, string> listadeLivros, string livroAserEmprestado)
        {
            base.Emprestar(listadeLivros, livroAserEmprestado);
        }

        public override void Devolver(Dictionary<string, string> livros, string livroAserDevolvido)
        {
            base.Devolver(livros, livroAserDevolvido);
        }

    }
}