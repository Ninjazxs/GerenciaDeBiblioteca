using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace GerenciamentodeBiblioteca
{
    class Principal
    {
        static void Main(string []args)
        {
            
            Dictionary<string, string> ColecaodeLivrosInfantis = new Dictionary<string, string>()
            {
                {"O menino maluquinho", "O menino maluquinho"},
                {"A galinha dos ovos de ouro", "A galinha dos ovos de ouro"},
                {"O homem cão", "O homem cão"},
                {"O pequeno peregrino","O pequeno peregrino"}
            };

            Dictionary<string, string> ColecaodeLivrosdeMisterio = new Dictionary<string, string>()
            {
                {"A ilha misteriosa", "A ilha misteriosa"},
                {"Ninguem vai te ouvir gritar", "Ninguem vai te ouvir gritar"},
                {"O misterio da casa verde", "O misterio da casa verde"},
                {"O longo adeus", "O longo adeus"}
            };

            Livro LivrosParaInfancia = new Livro("Livros Infantis", ColecaodeLivrosInfantis);
            Livro LivrosdeMisterio = new Livro("Livro de Misterio", ColecaodeLivrosdeMisterio);

            
            LivrosParaInfancia.Emprestar(ColecaodeLivrosInfantis, "O menino maluquinho");
            LivrosdeMisterio.Emprestar(ColecaodeLivrosdeMisterio, "Ninguem vai te ouvir gritar");
            Console.WriteLine("\n");

            Console.WriteLine("-----------------------");
            Console.WriteLine("Livros infantis disponíveis : ");

            LivrosParaInfancia.ExibirLivrosDisponiveis(ColecaodeLivrosInfantis);
            LivrosdeMisterio.ExibirLivrosDisponiveis(ColecaodeLivrosdeMisterio);
        }
    }

    class Livro 
    {
        public string TipoDoLivro {get; set;}

        public List<Dictionary<string, string>> Livros {get; set;} = new List<Dictionary<string, string>>(2);

        public Livro(string tipo, Dictionary<string, string> livros)
        {
            this.TipoDoLivro = tipo;

            Livros.Add(livros);
        }

        public void Emprestar(Dictionary<string, string> livros, string livroAserEmprestado)
        {   
            if (livros.ContainsKey(livroAserEmprestado))
            {
                livros.Remove(livroAserEmprestado);
                Console.WriteLine($"O livro : {livroAserEmprestado}, foi emprestado com sucesso \n");   
            } else {
                Console.WriteLine($"O livro : {livroAserEmprestado}, não existe na bilbioteca ou já está sendo emprestado");
            }
        }

        public void Devolver(Dictionary<string, string> livros, string livroAserDevolvido)
        {   
            if (livros.ContainsKey(livroAserDevolvido) == false)
            {
                livros.Add(livroAserDevolvido, livroAserDevolvido);
                Console.WriteLine($"O livro {livroAserDevolvido} foi devolvido com sucesso para a biblioteca \n");   
            } else {
                Console.WriteLine($"O livro {livroAserDevolvido} que você está tentando devolver está incorreto ou já faz parte da biblioteca ");
            }
        }
    
        public void ExibirLivrosDisponiveis(Dictionary<string, string> tipodoLivro)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Livros que ainda estão disponíveis : ");
            foreach (KeyValuePair<string, string> livros in tipodoLivro)
            {
                Console.WriteLine(livros.Value); 
            }
        }
    }
}