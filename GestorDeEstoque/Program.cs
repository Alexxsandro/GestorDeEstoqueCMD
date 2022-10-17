using GestorDeEstoque;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestorEstoque
{
    class Estoque
    {

        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { adicionar = 1, Remover, Listar, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1 - Adicionar\n2 - Remover\n3 - Listar\n4 - Registrar entrada\n5 - Registrar saída\n6 - Sair");
                int opint = int.Parse(Console.ReadLine());
                if(opint > 0 && opint <= 6)
                {

                Menu opcao = (Menu)opint;

                switch (opcao)
                {
                    case Menu.Listar:
                            Listagem();
                        break;
                    case Menu.adicionar:
                        Cadastrar();
                        break;
                    case Menu.Remover:
                            remover();
                        break;
                    case Menu.Entrada:
                            Entrada();
                        break;
                    case Menu.Saida:
                            Saida();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();

            }

        }
        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento para remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento da entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer da baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Cadastrar()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1 - Produto fisico\n2 - Ebook\n3 - Curso");
            int escolhaInt = int.Parse(Console.ReadLine());
            switch (escolhaInt)
            {
                case 1:
                    CadastrarFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }
        static void CadastrarFisico()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome,preco,frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();

        }
    }
}