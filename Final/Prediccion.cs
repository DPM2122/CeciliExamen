using System;
using System.Collections.Generic;



namespace Final
{
    /// <summary>
    /// Clase que nos da la prediccion de 
    /// </summary>
    public class Prediccion
    {
        private double tempCelsius; // temperatura en grados Celsius
        private double tempFarenheit; // temperatura en grados farenheit
        private double tempMax; // temperatura máxima
        private double tempMin; // temperatura mínima

        /// <summary>
        /// Getters y setters de las variables
        /// </summary>
        public double TempCelsius { get => tempCelsius; set => tempCelsius = value; }
        public double TempFarenheit { get => tempFarenheit; set => tempFarenheit = value; }
        public double TempMax { get => tempMax; set => tempMax = value; }
        public double TempMin { get => tempMin; set => tempMin = value; }


        /// <summary>
        /// Constuctor que inicualiza las variables
        /// </summary>
        
       public Prediccion ()
        {
            TempCelsius = 0;
            TempFarenheit = 0;
            TempMax =-1000;
            TempMin = 1000;
        }

        /// <summary>
        /// Funcion que predice la temperatura a raiz de tres dias de observacion
        /// <para>calculamos la temperatura media total, dándo más peso al último día que al primero</para>
        /// </summary>
        /// <param name="observacionDia1">datos de orsevacion de dia 1</param>
        /// <param name="observacionDia2">datos de orsevacion de dia 2</param>
        /// <param name="observacionDia3">datos de orsevacion de dia 3</param>
        /// <exception cref="Exception">La lista no puede estar vacía</exception>
        /// <returns>devuelve la prevision basada en el metodo</returns>  

        public bool PredecirTemperatura (List<double> observacionDia1, 
            List<double> observacionDia2, List<double> observacionDia3)
        {
            int i;  // contador
            double tempMedia1 = 0,
                   tempMedia2 = 0,
                   tempMedia3 = 0; // temperatura media de cada día

            if (observacionDia1.Count <= 0)
            {
                return false;
                throw new Exception("Al menos tiene que existir una observación");
                // Tenemos que tener al menos una observación
            }

            i = CalcularTemperaturaMediaDia(observacionDia1, ref tempMedia1);

            if (observacionDia2.Count <= 0)
            {
                return false;
                throw new Exception("Al menos tiene que existir una observación");
                // Tenemos que tener al menos una observación
            }

            i = CalcularTemperaturaMediaDia(observacionDia2, ref tempMedia2);


            if (observacionDia3.Count <= 0)
            {
                return false;
                throw new Exception("Al menos tiene que existir una observación");
                // Tenemos que tener al menos una observación
            }

            i = CalcularTemperaturaMediaDia(observacionDia3, ref tempMedia3);


            // Finalmente calculamos la temperatura media total, dándo más peso 		
            // al último día que al primero
            //
            TempCelsius = 0.2 * tempMedia1 + 0.35 * tempMedia2 + 0.45 * tempMedia3;

            // calculamos también la temperatura en grados farenheit
            //
            TempFarenheit = (TempCelsius * 1.8) + 32;

            return true;
        }

        private int CalcularTemperaturaMediaDia(List<double> observacionDia1, ref double tempMedia1)
        {
            int i;
            for (i = 0; i < observacionDia1.Count; i++)
            {
                tempMedia1 = tempMedia1 + observacionDia1[i];

                if (TempMin < observacionDia1[i])
                {
                    TempMin = observacionDia1[i];
                }

                if (TempMax > observacionDia1[i])
                {
                    TempMax = observacionDia1[i];
                }
            }

            tempMedia1 = tempMedia1 / observacionDia1.Count;
            return i;
        }
    }
}
