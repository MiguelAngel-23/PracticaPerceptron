using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Perceptron
{
    class Program
    {
        public static List<String> lista_Variables = new List<string>();
        public static double[] Almacen = new double[4];

        static int[,] TablaAND = {
                { -1, -1, -1 },
                { -1,  1, -1 },
                {  1, -1, -1 },
                {  1,  1,  1 }
            };
        public static double w1 = 0, w2 = 0, u = 0;
        public static double resultado = 0;
        static int y = 0;

        public static double resultado1 = 0;
        public static double resultado2 = 0;
        public static double resultado3 = 0;
        public static double resultado4 = 0;

        static int[] TablaY = new int[5];

        public static int cont = 0;
        public static int cont2 = 0;
        static void Main(string[] args)
        {
            Console.Write("Ingresa W1: ");
            w1 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa W2: ");
            w2 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa U: ");
            u = double.Parse(Console.ReadLine());
            resultado = (TablaAND[cont, 0] * w1) + (TablaAND[cont, 1] * w2) + (u);
            while (cont < 4)
            {
                Operacion2(cont);
                cont++;
            }
            Console.WriteLine("");
            Console.WriteLine("Sin Regresar al Final");

            for (int i = 0; i < lista_Variables.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + lista_Variables[i] + " --> dx " + TablaY[i]);
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
        public static void Operacion2(int cont)
        {
            resultado = (TablaAND[cont, 0] * w1) + (TablaAND[cont, 1] * w2) + (u);

            if (resultado > 0)
            {
                y = 1;
                TablaY[cont] = 1;
            }
            else
            {
                y = -1;
                TablaY[cont] = -1;
            }
            if (y == TablaAND[cont, 2])
            {
                lista_Variables.Add(resultado.ToString());
            }
            else
            {
                w1 += TablaAND[cont, 2] * TablaAND[cont, 0];
                w2 += TablaAND[cont, 2] * TablaAND[cont, 1];
                u += TablaAND[cont, 2];
                Operacion2(cont);
            }
        }
    }
}
