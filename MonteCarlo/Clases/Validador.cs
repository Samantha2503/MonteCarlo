using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo.Clases
{
 


    public class Validador
    {
            public static bool Positivos(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4)
            {
                // Create an array of TextBox controls
                TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox4 };

                // Loop through each TextBox and validate
                foreach (var textBox in textBoxes)
                {
                    if (!double.TryParse(textBox.Text, out double value) || value <= 0)
                    {
                        // If parsing fails or the value is not positive
                        MessageBox.Show($"Please enter a positive number in {textBox.Name}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox.Focus(); // Set focus back to the invalid TextBox
                        return false; // Return false indicating validation failed
                    }
                }

                return true; // Return true if all values are valid
            }
        }

 }
