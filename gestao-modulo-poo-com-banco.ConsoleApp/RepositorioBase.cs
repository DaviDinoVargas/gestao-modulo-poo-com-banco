using System;
using System.Collections;
using System.IO;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public abstract class RepositorioBase<T> where T : EntidadeBase, new()
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
            foreach (T entidade in registros) 
            {
                if (entidade.Id == id)
                {
                    entidadeAtualizada.Id = id;
                    registros[registros.IndexOf(entidade)] = entidadeAtualizada; 
                    SalvarNoArquivo();
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int id)
        {
            foreach (T entidade in registros) 
            {
                if (entidade.Id == id)
                {
                    registros.Remove(entidade); 
                    SalvarNoArquivo();
                    return true;
                }
            }
            return false;
        }

        public T[] SelecionarTodos()
        {
            T[] copia = new T[registros.Count];
            registros.CopyTo(copia); 
            return copia;
        }

        public T SelecionarPorId(int id)
        {
            foreach (T entidade in registros) 
            {
                if (entidade.Id == id)
                    return entidade;
            }
            return null;
        }

        protected int GerarNovoId()
        {
            int maiorId = 0;
            foreach (T entidade in registros)
            {
                if (entidade.Id > maiorId)
                    maiorId = entidade.Id;
            }
            return maiorId + 1;
        }

        protected abstract string Serializar(T entidade);
        protected abstract T Desserializar(string linha);

        protected void SalvarNoArquivo()
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo, false))
            {
                foreach (T entidade in registros)
                    sw.WriteLine(Serializar(entidade));
            }
        }

        protected void CarregarDoArquivo()
        {
            if (!File.Exists(caminhoArquivo))
                return;

            string[] linhas = File.ReadAllLines(caminhoArquivo);
            foreach (string linha in linhas) 
            {
                T entidade = Desserializar(linha);
                registros.Add(entidade); 
            }
        }
    }
}
