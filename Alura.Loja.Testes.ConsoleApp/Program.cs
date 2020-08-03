using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperaProdutos();
            //ExcluirProdutos();
            //RecuperaProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            // incluir um produto
            GravarUsandoEntity();
            RecuperaProdutos();
            // atualiazar o produto
            using (var repo = new LojaContext())
            {
                Produto primeiro = repo.Produtos.First();
                primeiro.Nome = "Harry Poter - Editado";
                repo.Produtos.Update(primeiro);
                repo.SaveChanges();

            }
            RecuperaProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach (var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }

                repo.SaveChanges();
            }
        }

        private static void RecuperaProdutos()
        {
            using (var contexto = new LojaContext())
            {
                IList<Produto> produtos = contexto.Produtos.ToList();
                Console.WriteLine("Foram encontrados {0} produto(s)", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                    Console.ReadLine();
                }
            }
        }

        

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }
    }

        //private static void GravarUsandoAdoNet()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Ordem da Fênix";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAO())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}
    
}

