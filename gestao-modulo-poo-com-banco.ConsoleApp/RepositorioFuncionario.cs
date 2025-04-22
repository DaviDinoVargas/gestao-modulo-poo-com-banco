using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {
        public RepositorioFuncionario(string arquivo) : base(arquivo) { }

        protected override string Serializar(Funcionario f)
        {
            return $"{f.Id};{f.Nome};{f.Cargo};{f.Salario}";
        }

        protected override Funcionario Desserializar(string linha)
        {
            string[] partes = linha.Split(';');

            return new Funcionario
            {
                Id = int.Parse(partes[0]),
                Nome = partes[1],
                Cargo = partes[2],
                Salario = decimal.Parse(partes[3])
            };
        }
    }
}
