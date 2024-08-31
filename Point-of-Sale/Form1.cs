using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Point_of_Sale.Logica;

namespace Point_of_Sale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear conexión usando la clase Conexion
                using (SQLiteConnection con = Conexion.getInstancia().CrearConexion())
                {
                    con.Open();

                    // Crear un comando SQL para obtener los datos de los usuarios
                    string query = "SELECT Name, Rol FROM Users";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder sb = new StringBuilder();

                            // Leer y concatenar los resultados
                            while (reader.Read())
                            {
                                sb.AppendLine($"Name: {reader["Name"]}, Rol: {reader["Rol"]}");
                            }

                            // Mostrar los datos en un MessageBox
                            MessageBox.Show(sb.ToString(), "User Data");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}