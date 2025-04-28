using gestao_modulo_poo_com_banco.ConsoleApp.Empresas;
using System;

namespace gestao_modulo_poo_com_banco.ConsoleApp.Funcionarios
{
    public class TelaFuncionario : TelaBase<Funcionario>
    {
        private RepositorioEmpresa repositorioEmpresa;
        private RepositorioEmpresa repositorioEmpresa1;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario, RepositorioEmpresa repositorioEmpresa)
            : base(repositorioFuncionario)
        {
            this.repositorioEmpresa = repositorioEmpresa;
        }

        public TelaFuncionario(RepositorioBase<Funcionario> repositorioBase, RepositorioEmpresa repositorioEmpresa1) : base(repositorioBase)
        {
            this.repositorioEmpresa1 = repositorioEmpresa1;
        }

        protected override Funcionario ObterEntidade()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o cargo: ");
            string cargo = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Empresas disponíveis:");
            Empresa[] empresas = repositorioEmpresa.SelecionarTodos();
            foreach (var empresa in empresas)
                Console.WriteLine($"[{empresa.Id}] {empresa.Nome}");

            Console.Write("Digite o ID da empresa: ");
            int empresaId = int.Parse(Console.ReadLine());

            return new Funcionario(nome, cargo, idade, empresaId);
        }

        protected override void MostrarTabela(Funcionario[] registros)
        {
            Console.WriteLine("ID | Nome | Cargo | Idade | EmpresaID");
            Console.WriteLine("---------------------------------------");

            foreach (var funcionario in registros)
            {
                Console.WriteLine($"{funcionario.Id} | {funcionario.Nome} | {funcionario.Cargo} | {funcionario.Idade} | {funcionario.EmpresaId}");
            }
        }
    }
}
