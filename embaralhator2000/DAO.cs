using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embaralhator2000
{
    public static class DAO
    {
        //metodo persistir arquivo CSV
        public static void PersistCSV(List<string> conteudo) {

            try
            {
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("Posicao;Letra");

                foreach (var item in conteudo)
                {
                    csvcontent.AppendLine(item);
                }

                string csvpath = @"C:\Temp";

                if (!Directory.Exists(csvpath))
                    Directory.CreateDirectory(csvpath);

                ApagarArquivoExistente(csvpath);

                File.AppendAllText(string.Format(@"{0}\Teste.csv", csvpath), csvcontent.ToString());

            }
            catch (Exception)
            {
                Console.WriteLine("\nO arquivo está aberto, feche-o antes de prosseguir.\n");
            }
        }

        private static void ApagarArquivoExistente(string csvpath)
        {
            File.Delete(string.Format(@"{0}\Teste.csv", csvpath));
        }
    }
}
