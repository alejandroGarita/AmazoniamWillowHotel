using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmazoniamWillowHotel.Models
{
    public class StatusModel
    {
        private SqlConnection connection;

        public StatusModel()
        {
            string constring = "data source = 163.178.107.130; initial catalog = Hotel_Amazonian_Willow; user id = laboratorios; password = Saucr.118";
            connection = new SqlConnection(constring);
        }//constructor

        public List<Models.Estado> getStatus()
        {
            List<Models.Estado> status = new List<Models.Estado>();

            SqlCommand cmd = new SqlCommand("sp_getStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                status.Add(
                    new Models.Estado
                    {
                        Id_Estado = Convert.ToInt32(dr["Id_Estado"]),
                        Nombre = Convert.ToString(dr["Nombre"]),
                    });
            }
            return status;
        }//obtener todas los consunos de agua del sistemas.

    }//end class
}//end namespace