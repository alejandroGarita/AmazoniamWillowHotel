using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmazoniamWillowHotel.Models
{
    public class FacilitieModel
    {
        private SqlConnection connection;

        public FacilitieModel()
        {
            string constring = "data source = 163.178.107.130; initial catalog = Hotel_Amazonian_Willow; user id = laboratorios; password = Saucr.118";
            connection = new SqlConnection(constring);
        }//constructor

        public List<Models.Facilidad> getFacilities()
        {
            List<Models.Facilidad> facilities = new List<Models.Facilidad>();

            SqlCommand cmd = new SqlCommand("sp_getFacilities", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                facilities.Add(
                    new Models.Facilidad
                    {
                        Id_Facilidad          = Convert.ToInt32(dr["Id_Facilidad"]),
                        Descripcion = Convert.ToString(dr["Descripcion"]),
                        Id_Estado      = Convert.ToInt32(dr["Id_Estado"]),
                        Imagen = Convert.ToString(dr["Imagen"]),
                    });
            }
            return facilities;
        }//obtener todas los consunos de agua del sistemas.

    }//end class
}//end namespaced