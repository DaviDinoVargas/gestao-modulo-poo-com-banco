using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public abstract class RepositorioBase<T> where T : EntidadeBase, new()
    {
        protected T[] registros = new T[100];
        protected int contador = 0;
        protected string caminhoArquivo;

        public RepositorioBase(string nomeArquivo)
        {
            caminhoArquivo = nomeArquivo;
            CarregarDoArquivo();
        }

        public void Inserir(T entidade)
        {
            entidade.Id = GerarNovoId();
            registros[contador++] = entidade;
            SalvarNoArquivo();
        }

        public bool Editar(int id, T entidadeAtualizada)
        {
            for (int i = 0; i < contador; i++)
            {
                if (registros[i].Id == id)
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
            for (int i = 0; i < contador; i++)
            {
                if (registros[i].Id == id)
                {
                    for (int j = i; j < contador - 1; j++)
                        registros[j] = registros[j + 1];

                    registros[--contador] = default(T);
                    SalvarNoArquivo();
                    return true;
                }
            }
            return false;
        }

        public T[] SelecionarTodos()
        {
            T[] copia = new T[contador];
            Array.Copy(registros, copia, contador);
            return copia;
        }

        public T SelecionarPorId(int id)
        {
            for (int i = 0; i < contador; i++)
                if (registros[i].Id == id)
                    return registros[i];

            return null;
        }

        protected int GerarNovoId()
        {
            int maiorId = 0;
            for (int i = 0; i < contador; i++)
                if (registros[i].Id > maiorId)
                    maiorId = registros[i].Id;

            return maiorId + 1;
        }

        protected abstract string Serializar(T entidade);
        protected abstract T Desserializar(string linha);

        protected void SalvarNoArquivo()
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo, false))
            {
                for (int i = 0; i < contador; i++)
                    sw.WriteLine(Serializar(registros[i]));
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
                registros[contador++] = entidade;
            }
        }
    }
}
