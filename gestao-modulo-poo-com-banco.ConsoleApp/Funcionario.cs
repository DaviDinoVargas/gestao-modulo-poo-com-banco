using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
