using System;
using System.Collections;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        protected ArrayList registros = new ArrayList();
        protected string caminhoArquivo;

        public RepositorioBase(string nomeArquivo)
        {
            caminhoArquivo = nomeArquivo;
            CarregarDoArquivo();
        }

        public void Inserir(T entidade)
        {
            entidade.Id = GerarNovoId();
            registros.Add(entidade);
            SalvarNoArquivo();
        }

        public bool Editar(int id, T entidadeAtualizada)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                T entidade = (T)registros[i];
                if (entidade.Id == id)
                {
                    entidadeAtualizada.Id = id;
                    registros[i] = entidadeAtualizada;
                    SalvarNoArquivo();
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int id)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                T entidade = (T)registros[i];
                if (entidade.Id == id)
                {
                    registros.RemoveAt(i);
                    SalvarNoArquivo();
                    return true;
                }
            }
            return false;
        }

        public T[] SelecionarTodos()
        {
            T[] array = new T[registros.Count];
            registros.CopyTo(array);
            return array;
        }

        public T SelecionarPorId(int id)
        {
            foreach (T entidade in registros)
                if (entidade.Id == id)
                    return entidade;

            return null;
        }

        protected int GerarNovoId()
        {
            int maiorId = 0;
            foreach (T entidade in registros)
                if (entidade.Id > maiorId)
                    maiorId = entidade.Id;

            return maiorId + 1;
        }

        protected abstract void SalvarNoArquivo();
        protected abstract void CarregarDoArquivo();
    }
}
