using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtigoTDD
{
    public class Calculadora 
    {

        public ArithmeticException ExceptionToThrow { get; set; }

        public int soma(int valorA, int valorB)
        {
            return valorA + valorB;
        }

        public int subtrai(int valorA, int valorB)
        {
            return valorA - valorB;
        }

        public int divide(int valorA, int valorB)
        {
            try
            {
                return valorA / valorB;
            }
            catch (ArithmeticException a)
            {
                Console.WriteLine("Exceção capturada: ", a);
                Console.WriteLine("--------");
                return 0;
            }

        }

    }
}