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

                    string x = string.Format("Item:{0};{1}", (i + 1), RetornaIndice(numero));

                    retorno.Add(x);
                }


            }
            catch (System.Exception)
            {

                throw;
            }

            return retorno;
        }

        private static int RetornaIndice(int hash)
        {
            var retorno = 0;
            int resultado = 0;


            if (hash != int.MinValue)
                retorno = CalculaHashERetornaIndice(hash, ref resultado);

            return retorno;
        }

        private static int CalculaHashERetornaIndice(int hash, ref int resultado)
        {
            int retorno;
            {
                var valor = hash.ToString().Replace("-", "");

                resultado = CalculaHash(resultado, valor);

                if (resultado <= 2)
                    retorno = 0;
                else if (resultado <= 4)
                    retorno = 1;
                else if (resultado <= 6)
                    retorno = 2;
                else if (resultado <= 8)
                    retorno = 3;
                else
                    retorno = 4;
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
