using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public class GeradorId
    {
        public static int idCaixa = 0;
        public static int idAmigo = 0;
        public static int idRevista = 0;
        public static int idEmprestimo = 0;

        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        public static int GerarIdAmigo()
        {
            return ++idAmigo;
        }

        internal static int GerarIdRevista()
        {
            return ++idRevista;
        }

        internal static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }
    }
}
