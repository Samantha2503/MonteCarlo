using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Algoritmo
{
  
    public class Aleatorio
    {
        private int columnas;
        private int n_iteraciones;
        private Random random;
        private List<List<double>> dataGrid;

        // Constructor to initialize with the number of columns and rows
        public Aleatorio(int columnas, int n_iteraciones)
        {
            this.columnas = columnas;
            this.n_iteraciones = n_iteraciones;
            this.random = new Random();
            this.dataGrid = new List<List<double>>();
        }

        // Method to generate the random data for the specified number of columns and rows
        public void GenerateRandomData(int lowerLimit, int upperLimit)
        {
            for (int i = 0; i < n_iteraciones; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < columnas; j++)
                {
                    row.Add(GenerateRandomValue(lowerLimit, upperLimit));
                }
                dataGrid.Add(row);
            }
        }

 
        private int GenerateRandomValue(int lowerLimit, int upperLimit)
        {
            // Next(min, max) generates numbers between min (inclusive) and max (exclusive)
            // To make the upper limit inclusive, we use (upperLimit + 1)
            return random.Next(lowerLimit, upperLimit + 1);
        }




        // Method to get the generated data (if needed for further processing)
        public List<List<double>> GetDataGrid()
        {
            return dataGrid;
        }
    }

}
