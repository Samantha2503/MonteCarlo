using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Algoritmo
{
   
    public class Eleccion_valor
    {
        public List<List<double>> valorselect;

        // Constructor that accepts the data grid from RandomIntegerDataGenerator
        public Eleccion_valor(List<List<double>> dataGrid)
        {
            this.valorselect = new List<List<double>>();

            // Process each row to find the second-highest value
            foreach (var row in dataGrid)
            {
                List<double> newRow = new List<double>(row); // Copy the original row
                double secondHighest = Encontrar_valor(row);
                newRow.Add(secondHighest); // Append the second-highest value as a new column (x_i)
                valorselect.Add(newRow); // Add the modified row to the new data grid
            }
        }

        // Method to find the second-highest value in a row
        public double Encontrar_valor(List<double> row)
        {
            if (row.Count < 2) throw new InvalidOperationException("Row must have at least 2 elements");

            // Sort the row in descending order, then pick the second element
            List<double> sortedRow = row.OrderByDescending(x => x).ToList();
            return sortedRow[1]; // Second-highest value
        }

        // Method to display the data with the second-highest column (x_i)
    

        // Method to get the modified data (if needed for further processing)
        public List<List<double>> GetDataWithSecondHighest()
        {
            return valorselect;
        }
    }
}


