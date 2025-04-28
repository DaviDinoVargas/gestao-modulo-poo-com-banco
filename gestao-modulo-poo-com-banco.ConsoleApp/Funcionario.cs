namespace gestao_modulo_poo_com_banco.ConsoleApp.Funcionarios
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public int Idade { get; set; }
        public int EmpresaId { get; set; }

        public Funcionario() { }

        public Funcionario(string nome, string cargo, int idade, int empresaId)
        {
            Nome = nome;
            Cargo = cargo;
            Idade = idade;
            EmpresaId = empresaId;
        }
    }
}
