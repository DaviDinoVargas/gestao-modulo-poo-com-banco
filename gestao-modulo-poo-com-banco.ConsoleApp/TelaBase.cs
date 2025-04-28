using System;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public abstract class TelaBase<T> where T : EntidadeBase
    {
        protected RepositorioBase<T> repositorio;

        public TelaBase(RepositorioBase<T> repositorioBase)
        {
            this.repositorio = repositorioBase;
        }

        public void Inserir()
        {
            Console.Clear();
            Console.WriteLine($"--- Inserir {typeof(T).Name} ---\n");

            T entidade = ObterEntidade();
            repositorio.Inserir(entidade);

            Console.WriteLine("\nRegistro inserido com sucesso!");
            Console.ReadKey();
        }

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine($"--- Editar {typeof(T).Name} ---\n");

            Visualizar();

            Console.Write("\nDigite o ID para editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                T entidade = ObterEntidade();
                if (repositorio.Editar(id, entidade))
                    Console.WriteLine("\nRegistro editado com sucesso!");
                else
                    Console.WriteLine("\nID não encontrado.");
            }
            else
            {
                Console.WriteLine("\nID inválido!");
            }

            Console.ReadKey();
        }

        public void Excluir()
        {
            Console.Clear();
            Console.WriteLine($"--- Excluir {typeof(T).Name} ---\n");

            Visualizar();

            Console.Write("\nDigite o ID para excluir: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (repositorio.Excluir(id))
                    Console.WriteLine("\nRegistro excluído com sucesso!");
                else
                    Console.WriteLine("\nID não encontrado.");
            }
            else
            {
                Console.WriteLine("\nID inválido!");
            }

            Console.ReadKey();
        }

        public void Visualizar()
        {
            Console.Clear();
            Console.WriteLine($"--- Visualizar {typeof(T).Name} ---\n");

            T[] registros = repositorio.SelecionarTodos();
            if (registros.Length == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
            }
            else
            {
                MostrarTabela(registros);
            }

            Console.ReadKey();
        }

        protected abstract T ObterEntidade();
        protected abstract void MostrarTabela(T[] registros);
    }
}
