using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public class TelaFuncionario : TelaBase<Funcionario>
    {
        public TelaFuncionario(RepositorioFuncionario repo) : base(repo) { }

        protected override Funcionario ObterRegistro()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();

            Console.Write("Salário: ");
            decimal salario = decimal.Parse(Console.ReadLine());

            return new Funcionario { Nome = nome, Cargo = cargo, Salario = salario };
        }

        protected override void MostrarRegistro(Funcionario f)
        {
            Console.WriteLine($"ID: {f.Id} | Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: R${f.Salario}");
        }
    }
}
