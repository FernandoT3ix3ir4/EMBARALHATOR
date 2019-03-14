using System;

namespace embaralhator2000
{
    class Program
    {
        static void Main(string[] args)
        {
            string again = string.Empty;

            Console.WriteLine("############## EMBARALHATOR ##############");

            do
            {
                EmbaralhatorMethod();

                Console.WriteLine("##########################################");

                Console.WriteLine("\nGostaria de executar novamente?  ");
                again = Console.ReadLine();

                while (!again.ToString().ToUpper().Equals("Y") && !again.ToString().ToUpper().Equals("N"))
                {
                    Console.WriteLine("\nSão aceitos apenas 'Y' para 'Sim' e 'N' para 'Não'.");
                    Console.WriteLine("\nGostaria de executar novamente?  ");
                    again = Console.ReadLine();
                }

            } while (!again.ToString().ToUpper().Equals("N"));


            Console.WriteLine("\n\nOBRIGADO!\n");
            Console.WriteLine("##########################################");
            Console.ReadKey();

            Console.WriteLine("############## EMBARALHATOR 7000 ##############");
            Console.WriteLine(string.Format("Retornou o indice: {0}",Embaralhator7000.GeradorDeIndice.RetornaIndice(100)));
            Console.WriteLine("##########################################");
            Console.ReadKey();

        }

        private static void EmbaralhatorMethod()
        {
            Console.WriteLine("Quantos registros deseja criar?  ");

            int qtde;
            int tentativas = 0;
            while (!int.TryParse(Console.ReadLine(), out qtde))
            {
                tentativas++;
                Console.WriteLine("\nEstúpido! São permitidos apenas números!");
                Console.WriteLine();
                Console.WriteLine("Quantos registros deseja criar?  ");

            }

            if (qtde > 0)
            {
                if (tentativas > 0)
                    Console.WriteLine("\nAgora sim múmia paralítica!");

                var inicio = DateTime.Now;

                var content = BO.GeradorDeMassa(qtde);

                var fim = DateTime.Now;

                var diff = fim - inicio;

                Console.WriteLine();
                Console.WriteLine(string.Format("Retornou a letra {0}", content[0].Split(';')[1]));
                Console.WriteLine();
                Console.WriteLine("##########################################");
                Console.WriteLine("Tempo total: " + diff);

                DAO.PersistCSV(content);
            }
            else
                Console.WriteLine("\n0....Você jura!?\n\nVai a merda, não me faça perder tempo!!!\nTCHAU!");
        }
    }
}
