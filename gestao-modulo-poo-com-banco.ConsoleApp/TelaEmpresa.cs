using System;

namespace gestao_modulo_poo_com_banco.ConsoleApp.Empresas
{
    public class TelaEmpresa : TelaBase<Empresa>
    {
        public TelaEmpresa(RepositorioEmpresa repositorioEmpresa)
            : base(repositorioEmpresa)
        {
        }

        protected override Empresa ObterEntidade()
        {
            Console.Write("Digite o nome da empresa: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CNPJ: ");
            string cnpj = Console.ReadLine();

            return new Empresa(nome, cnpj);
        }

        protected override void MostrarTabela(Empresa[] registros)
        {
            Console.WriteLine("\nID | Nome | CNPJ");
            Console.WriteLine("--------------------");

            foreach (var empresa in registros)
            {
                if (empresa != null)
                    Console.WriteLine($"{empresa.Id} | {empresa.Nome} | {empresa.CNPJ}");
            }
        }
    }
}
