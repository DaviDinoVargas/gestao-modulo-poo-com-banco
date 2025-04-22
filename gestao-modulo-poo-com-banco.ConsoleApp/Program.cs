namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repoFuncionario = new RepositorioFuncionario("funcionarios.txt");
            var telaFuncionario = new TelaFuncionario(repoFuncionario);
            telaFuncionario.MostrarMenu();
        }
    }
}
