using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalNS;


namespace PruebaFinal
{
    [TestClass]
    public class PruebaPrediccion
    {
        [TestMethod]
        public void PruebaTemperaturaFueraRango() //Esta prueba pretende sacar un error si la temperatura máxima o mínima es mayor o menor de lo introducido en la clase
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);

            miPrediccionPrueba.TempMax = 1001;


            if (miPrediccionPrueba.TempMax <= 1000)
            {
                miPrediccionPrueba.PrediccionTemperatura(dia1, dia2, dia3);


                Console.WriteLine("Temperatura Celsius: " + miPrediccionPrueba.TempCelsius);
                Console.WriteLine("Temperatura Farenheit: " + miPrediccionPrueba.TempFarenheit);
                Console.WriteLine("Máxima: " + miPrediccionPrueba.TempMax);
                Console.WriteLine("Mínima: " + miPrediccionPrueba.TempMin);

                Console.ReadKey();


            }
            else
            {

                throw new ArgumentOutOfRangeException("La temperatura máxima es incorrecta");

            }


        }
    }
}
