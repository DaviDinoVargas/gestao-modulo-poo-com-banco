namespace gestao_modulo_poo_com_banco.ConsoleApp.Empresas
{
    public class Empresa : EntidadeBase
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        public Empresa(string nome, string cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
        }
    }
}
