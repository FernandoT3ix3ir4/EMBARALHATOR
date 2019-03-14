using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embaralhator7000
{
    public class GeradorDeIndice
    {
        /// <summary>
        /// Este método retorna um índice aleatório de acordo com a quantidade de indices desejada (Por padrão retorna 5 posições)
        /// </summary>
        /// <param name="qtdePosicoes"></param>
        /// <returns>int indice</returns>
        public static int RetornaIndice(int qtdePosicoes = 5)
        {
            var retorno = 0;
            int resultado = 0;
            
            for (int i = 0; i < qtdePosicoes; i++)
            {
                var hash = DateTime.Now.Millisecond + i;

                hash = hash * hash;
                
                if (hash != int.MinValue)
                retorno = CalculaHashERetornaIndice(hash, ref resultado);
            }

            return retorno;
        }

        private static int CalculaHashERetornaIndice(int hash, ref int resultado)
        {
            int retorno;
            {
                var valor = hash.ToString().Replace("-", "");

                resultado = CalculaHash(resultado, valor);

                /*Índice 0 é reservado a valor vazio para que o optionset não venha preenchido*/
                if (resultado <= 2)
                    retorno = 1;
                else if (resultado <= 4)
                    retorno = 2;
                else if (resultado <= 6)
                    retorno = 3;
                else if (resultado <= 8)
                    retorno = 4;
                else
                    retorno = 5;
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
