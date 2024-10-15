using MonteCarlo.Algoritmo;
using MonteCarlo.Clases;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            //Paso 0: condicion vacia
            Validaciones(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            //Paso 1: Inicializa parámetros
            int lim_inf = Convert.ToInt32(textBox1.Text);
            int lim_sup = Convert.ToInt32(textBox2.Text);
            int n_iteraciones = Convert.ToInt32(textBox3.Text);
            int columnas = Convert.ToInt32(textBox4.Text);


            //Paso 2: llamar algoritmo
            Aleatorio randomData = new Aleatorio(columnas,n_iteraciones);
            randomData.GenerateRandomData(lim_inf, lim_sup);
            List<List<double>> dataGrid = randomData.GetDataGrid();

            //List<List<int>> dataGrid = Eleccion_valor.GetDataGrid();
            
            Eleccion_valor selector = new Eleccion_valor(dataGrid);
            
            List<List<double>> dataGridWithXi = selector.GetDataWithSecondHighest();
            LlenarGrid(dataGridWithXi);
            
        }



        public void Validaciones(string d, string a, string b, string c)
        {
            // Call the validation method
            if (Validador.Positivos(textBox1, textBox2, textBox3, textBox4))
            {
                // Proceed with the operation if all values are positive
                MessageBox.Show("All values are valid and positive!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Validation failed, do not proceed
            }
        }

        public void LlenarGrid(List<List<double>> dataGridWithXi)
        {
            // Paso 0: Definir los encabezados de las columnas (Número de columnas dinámico)
            dataGridView1.Columns.Clear(); // Limpia las columnas

            int numberOfColumns = dataGridWithXi[0].Count; // El número de columnas incluye la columna 'x_i'

            // Paso 1: Añadir las columnas
            for (int i = 0; i < numberOfColumns; i++)
            {
                string columnName = (i == numberOfColumns - 1) ? "x_i" : $"Column {i + 1}";
                dataGridView1.Columns.Add(i.ToString(), columnName); // Añade columnas dinámicamente
            }

            // Paso 2: Recorrer el grid para cada fila y llenar de valores
            for (int i = 0; i < dataGridWithXi.Count; i++)
            {
                dataGridView1.Rows.Add(); // Añade una nueva fila al DataGridView
                for (int j = 0; j < numberOfColumns; j++)
                {
                    // Llena cada celda con el valor correspondiente de la lista
                    dataGridView1.Rows[i].Cells[j].Value = dataGridWithXi[i][j].ToString();
                }
            }
            //Para sacar la mean
            // Paso 3: Calcular la media del último columna "x_i"
            double sum = 0;
            int count = dataGridWithXi.Count;

            for (int i = 0; i < count; i++)
            {
                sum += dataGridWithXi[i][numberOfColumns - 1]; // Sumar todos los valores de la última columna
            }

            double mean = sum / count; // Calcular la media

            // Paso 4: Añadir una nueva fila para la media
            dataGridView1.Rows.Add(); // Añade una nueva fila para la media
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[numberOfColumns - 1].Value = mean.ToString(); // Llena la última celda con la media

            // Opcional: Puedes dejar celdas vacías o poner texto indicando que son medias en otras celdas
            for (int i = 0; i < numberOfColumns - 1; i++)
            {
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Value = ""; // Dejar las otras celdas vacías
            }
        }
        public void DescargaCSV(DataGridView data)
        {
            // Paso 0: Definir la ruta donde se guardará el archivo CSV
            string filePath = @"C:\Users\Samantha\Desktop\montecarlo.csv"; // Cambia la ruta según sea necesario

            // Paso 1: Crear el archivo CSV y usar StreamWriter para escribir
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Paso 1.1: Escribir las cabeceras
                string[] columnHeaders = data.Columns.Cast<DataGridViewColumn>()
                    .Select(column => column.HeaderText)
                    .ToArray();
                writer.WriteLine(string.Join(",", columnHeaders));

                // Paso 2: Escribir las filas
                foreach (DataGridViewRow row in data.Rows)
                {
                    // Ignorar filas vacías
                    if (!row.IsNewRow)
                    {
                        string[] cellValues = row.Cells.Cast<DataGridViewCell>()
                            .Select(cell => cell.Value?.ToString().Replace(",", ";")).ToArray();
                        writer.WriteLine(string.Join(",", cellValues));
                    }
                }
            }

            // Mensaje de éxito
            MessageBox.Show("CSV exportado exitosamente en: " + filePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaCSV(dataGridView1);

        }
    }
}
