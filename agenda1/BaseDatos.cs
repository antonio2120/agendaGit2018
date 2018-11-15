using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace agenda1
{
    class BaseDatos
    {
        string cadenaConnection = "Persist Security Info=False;Integrated Security=true;Initial Catalog = agenda;Server=FRT_LCRUZ\\SQLEXPRESS";
        //Persist Security Info=False; 
        //Integrated Security=true; Autentificación con Windows
        //Initial Catalog = agenda; Nombre de BD
        //Server=FRT_LCRUZ\\SQLEXPRESS Nombre de su Servidor SQL Server
        SqlConnection connection;
        SqlDataReader dataReader;
        SqlCommand command;
        SqlDataAdapter da;
        public  DataTable dt;

        public void connectionStart()
        {
            this.connection = new SqlConnection(this.cadenaConnection);
            try
            {
                connection.Open();     
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede abrir la conexión ! ");
            }
        }
        public void connectionClose()
        {
            dataReader.Close();
            command.Dispose();
            connection.Close();
        }
        public void select(string sql = null)
        {
            this.connectionStart();           
            try
            {                
                command = new SqlCommand(sql, connection);
                da = new SqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede ejecutar la consulta: "+ sql);
            }

        }
        public void update(string sql = null)
        {

        }            

    }
}
