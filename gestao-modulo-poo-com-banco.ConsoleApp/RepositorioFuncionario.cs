﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace gestao_modulo_poo_com_banco.ConsoleApp.Funcionarios
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {
        private int contador;

        public RepositorioFuncionario()
            : base("Funcionarios/funcionarios.json")
        {
        }

        protected override void CarregarDoArquivo()
        {
            if (File.Exists(caminhoArquivo))
            {
              
                string json = File.ReadAllText(caminhoArquivo);

               
                if (!string.IsNullOrWhiteSpace(json))
                {
                    var funcionarios = JsonSerializer.Deserialize<List<Funcionario>>(json);

  
                    if (funcionarios != null)
                    {
                        foreach (var funcionario in funcionarios)
                        {
                            registros[contador++] = funcionario;
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
