using System;
using System.Data.SQLite;

namespace Point_of_Sale.Logica
{
    public class Conexion
    {
        private readonly string BaseDatos = "./BD_pointofsale.db";
        private static Conexion Con = null;

        private Conexion() { }

        public SQLiteConnection CrearConexion()
        {
            return new SQLiteConnection("Data Source=" + this.BaseDatos);
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}