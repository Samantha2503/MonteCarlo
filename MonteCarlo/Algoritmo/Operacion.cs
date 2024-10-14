using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Algoritmo
{

    public class Operacion
    {
        private List<int> x_ivalores;

        // Constructor that accepts the data grid from SecondHighestSelector
        public Operacion(List<List<int>> valorselect)
        {
            x_ivalores = new List<int>();

            // Extract the x_i column (last element in each row)
            foreach (var row in valorselect)
            {
                int xi = row.Last(); // The x_i value is the last element in each row
                x_ivalores.Add(xi); // Add to the x_i list
            }
        }

        // Method to calculate the mean of the x_i column
        public double Media()
        {
            if (x_ivalores.Count == 0) throw new InvalidOperationException("No values in x_i column.");

            // Calculate the mean by summing the values and dividing by the number of values
            return x_ivalores.Average();
        }


    }
}

