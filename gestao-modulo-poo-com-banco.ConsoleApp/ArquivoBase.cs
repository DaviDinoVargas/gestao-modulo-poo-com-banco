using System.IO;
using System.Text.Json;

namespace gestao_modulo_poo_com_banco.ConsoleApp
{
    public static class ArquivoBase<T> where T : class, new()
    {
        public static void Salvar(string caminho, T[] registros, int quantidade)
        {
            var registrosValidos = new T[quantidade];
            Array.Copy(registros, registrosValidos, quantidade);

            var json = JsonSerializer.Serialize(registrosValidos, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(caminho, json);
        }

        public static T[] Carregar(string caminho, out int quantidade)
        {
            quantidade = 0;

            if (!File.Exists(caminho))
                return new T[100];

            var json = File.ReadAllText(caminho);

            if (string.IsNullOrWhiteSpace(json))
                return new T[100];

            var registros = JsonSerializer.Deserialize<T[]>(json);

            quantidade = registros?.Length ?? 0;

            var arrayCompleto = new T[100];
            if (registros != null)
                registros.CopyTo(arrayCompleto, 0);

            return arrayCompleto;
        }
    }
}
