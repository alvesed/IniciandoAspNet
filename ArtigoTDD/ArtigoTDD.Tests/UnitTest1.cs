using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtigoTDD.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void deveriaSomarDoisValoresPassados() 
        {
            int valorA = 1;
            int valorB = 2;

            //Action
            Calculadora calculadora = new Calculadora();
            int soma = calculadora.soma(valorA, valorB);


            // Assert
            Assert.AreEqual(3, soma);
        }

        [TestMethod]
        public void deveriaSubtrairDoisValoresPassados()
        {
            int valorA = 3;
            int valorB = 1;

            //Action
            Calculadora calculadora = new Calculadora();
            int subtracao = calculadora.subtrai(valorA, valorB);


            // Assert
            Assert.AreEqual(2, subtracao);
        }


        [TestMethod]
        public void deveriaDividirDoisValoresPassados()
        {
            int valorA = 6;
            int valorB = 2;

            //Action
            Calculadora calculadora = new Calculadora();
            int divisao = calculadora.divide(valorA, valorB);


            // Assert
            Assert.AreEqual(3, divisao);
        }

        [TestMethod]
        public void deveriaLancarUmaExcecaoIndicandoFalhaAoDividirUmNumeroPorZero()
        {
            Calculadora calculadora = new Calculadora();
            //DivideByZeroException exception = new DivideByZeroException();
            ArithmeticException exception = new DivideByZeroException();
            calculadora.ExceptionToThrow = exception;
            int valorA = 6;
            int valorB = 0;

            //Action
            //int divisao = calculadora.divide(valorA, valorB);

            // Assert
            //Assert.AreEqual(0, divisao);
            //Assert.IsNotNull(calculadora);
            //Assert.IsTrue(calculadora.Errors.Any());
            Assert.AreEqual(exception, calculadora.divide(valorA, valorB));

        }

    }
}
