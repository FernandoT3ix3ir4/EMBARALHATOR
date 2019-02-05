using System;
using System.Collections.Generic;

namespace embaralhator2000
{
    public static class BO
    {
        public static List<string> GeradorDeMassa(int qtde)
        {
            var retorno = new List<string>();

            try
            {
                for (int i = 0; i < qtde; i++)
                {
                    var numero = DateTime.Now.Millisecond + i;

                    numero = numero * numero;

                    string x = string.Format("Item:{0};{1}", (i + 1), RetornaLetra(numero));

                    retorno.Add(x);
                }


            }
            catch (System.Exception)
            {

                throw;
            }

            return retorno;
        }

        private static string RetornaLetra(int hash)
        {
            var retorno = string.Empty;
            int resultado = 0;


            if (hash != int.MinValue)
                retorno = CalculaHashERetornaLetra(hash, ref resultado);

            return retorno;
        }

        private static string CalculaHashERetornaLetra(int hash, ref int resultado)
        {
            string retorno;
            {
                var valor = hash.ToString().Replace("-", "");

                resultado = CalculaHash(resultado, valor);

                if (resultado <= 2)
                    retorno = "A";
                else if (resultado <= 4)
                    retorno = "B";
                else if (resultado <= 6)
                    retorno = "C";
                else if (resultado <= 8)
                    retorno = "D";
                else
                    retorno = "E";
            }

            return retorno;
        }

        private static int CalculaHash(int resultado, string valor)
        {
            resultado = RetornaNumeroUnitario(valor, resultado);

            while (resultado.ToString().Length > 1)
            {
                string novoValor = resultado.ToString();

                resultado = RetornaNumeroUnitario(novoValor, 0);
            }

            return resultado;
        }

        private static int RetornaNumeroUnitario(string valor, int resultado)
        {
            for (int i = 0; i < valor.Length; i++)
            {
                resultado += int.Parse(valor.Substring(i, 1));

            }



            return resultado;
        }
    }
}
