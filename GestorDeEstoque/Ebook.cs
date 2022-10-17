using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.autor = autor;
            this.nome = nome;
            this.preco = preco;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-book, pois é um produto digital.");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar venda no E-book {nome}");
            Console.WriteLine("Digite a Qtd de vendas: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {this.nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"vendas: {vendas}");
            Console.WriteLine($"preço: {preco}");
            Console.WriteLine("----------------------------");
        }
    }
}
