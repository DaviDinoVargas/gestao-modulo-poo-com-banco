using gestao_modulo_poo_com_banco.ConsoleApp.Funcionarios;
using gestao_modulo_poo_com_banco.ConsoleApp.Empresas;
using System;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestão - POO com Banco (JSON)";

            RepositorioEmpresa repositorioEmpresa = new RepositorioEmpresa();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

            TelaEmpresa telaEmpresa = new TelaEmpresa(repositorioEmpresa);
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario, repositorioEmpresa);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Gestão ===\n");
                Console.WriteLine("1 - Gerenciar Empresas");
                Console.WriteLine("2 - Gerenciar Funcionários");
                Console.WriteLine("S - Sair\n");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                if (opcao.ToUpper() == "S")
                    break;

                switch (opcao)
                {
                    case "1":
                        SubMenu(telaEmpresa, "Empresas");
                        break;

                    case "2":
                        SubMenu(telaFuncionario, "Funcionários");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void SubMenu<T>(TelaBase<T> tela, string nomeModulo) where T : EntidadeBase
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Gestão de {nomeModulo} ===\n");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Editar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Visualizar");
                Console.WriteLine("V - Voltar\n");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                if (opcao.ToUpper() == "V")
                    break;

                switch (opcao)
                {
                    case "1":
                        tela.Inserir();
                        break;

                    case "2":
                        tela.Editar();
                        break;

                    case "3":
                        tela.Excluir();
                        break;

                    case "4":
                        tela.Visualizar();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
