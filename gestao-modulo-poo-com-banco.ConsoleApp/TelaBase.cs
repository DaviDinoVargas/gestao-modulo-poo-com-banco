using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public abstract class TelaBase<T> where T : EntidadeBase, new()
    {
        protected RepositorioBase<T> repositorio;

        public TelaBase(RepositorioBase<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void MostrarMenu()
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine($"Cadastro de {typeof(T).Name}s");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Editar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Visualizar");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Inserir(); break;
                    case "2": Editar(); break;
                    case "3": Excluir(); break;
                    case "4": Visualizar(); break;
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            } while (opcao != "0");
        }

        protected abstract T ObterRegistro();

        protected virtual void Inserir()
        {
            T registro = ObterRegistro();
            repositorio.Inserir(registro);
            Console.WriteLine("Registro inserido com sucesso!");
        }

        protected virtual void Editar()
        {
            Console.Write("Digite o ID para editar: ");
            int id = int.Parse(Console.ReadLine());

            T registro = ObterRegistro();
            if (repositorio.Editar(id, registro))
                Console.WriteLine("Registro editado com sucesso!");
            else
                Console.WriteLine("ID não encontrado.");
        }

        protected virtual void Excluir()
        {
            Console.Write("Digite o ID para excluir: ");
            int id = int.Parse(Console.ReadLine());

            if (repositorio.Excluir(id))
                Console.WriteLine("Registro excluído com sucesso!");
            else
                Console.WriteLine("ID não encontrado.");
        }

        protected virtual void Visualizar()
        {
            T[] registros = repositorio.SelecionarTodos();

            Console.WriteLine("\n--- Lista de Registros ---\n");

            foreach (var item in registros)
                MostrarRegistro(item);
        }

        protected abstract void MostrarRegistro(T registro);
    }
}
