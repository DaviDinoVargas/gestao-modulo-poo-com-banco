using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace gestao_modulo_poo_com_banco.ConsoleApp.Empresas
{
    public class RepositorioEmpresa : RepositorioBase<Empresa>
    {
        private int contador;

        public RepositorioEmpresa()
            : base("Empresas/empresas.json")
        {
        }

        protected override void CarregarDoArquivo()
        {
            if (File.Exists(caminhoArquivo))
            {
 
                string json = File.ReadAllText(caminhoArquivo);


                if (!string.IsNullOrWhiteSpace(json))
                {
                    var empresas = JsonSerializer.Deserialize<List<Empresa>>(json);

                    if (empresas != null)
                    {
                        foreach (var empresa in empresas)
                        {
                            registros[contador++] = empresa;
                        }
                    }
                }
            }
        }

        protected override void SalvarNoArquivo()
        {
         
            var diretorio = Path.GetDirectoryName(caminhoArquivo);
            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            var json = JsonSerializer.Serialize(registros, new JsonSerializerOptions { WriteIndented = true });

       
            File.WriteAllText(caminhoArquivo, json);
        }
    }
}
