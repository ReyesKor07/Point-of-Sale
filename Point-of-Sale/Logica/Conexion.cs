using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Point_of_Sale.Logica
{
    public class Conexion
    {
        private string BaseDatos;
        private static Conexion Con = null;
        
        private Conexion() 
        {
            this.BaseDatos = "./BD_pointofsale.db";
        }

        public SQLiteConnection CrearConexion()
        {
            SQLiteConnection Cadena = new SQLiteConnection();
            try
            {
                Cadena.ConnectionString = "Data Source=" + this.BaseDatos;
            }
            catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if( Con == null )
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
