using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Algoritmo
{
   
    public class Eleccion_valor
    {
        private List<List<int>> valorselect;

        // Constructor that accepts the data grid from RandomIntegerDataGenerator
        public Eleccion_valor(List<List<int>> dataGrid)
        {
            this.valorselect = new List<List<int>>();

            // Process each row to find the second-highest value
            foreach (var row in dataGrid)
            {
                List<int> newRow = new List<int>(row); // Copy the original row
                int secondHighest = Encontrar_valor(row);
                newRow.Add(secondHighest); // Append the second-highest value as a new column (x_i)
                valorselect.Add(newRow); // Add the modified row to the new data grid
            }
        }

        // Method to find the second-highest value in a row
        private int Encontrar_valor(List<int> row)
        {
            if (row.Count < 2) throw new InvalidOperationException("Row must have at least 2 elements");

            // Sort the row in descending order, then pick the second element
            List<int> sortedRow = row.OrderByDescending(x => x).ToList();
            return sortedRow[1]; // Second-highest value
        }

        // Method to display the data with the second-highest column (x_i)
    

        // Method to get the modified data (if needed for further processing)
        public List<List<int>> GetDataWithSecondHighest()
        {
            return valorselect;
        }
    }
}


