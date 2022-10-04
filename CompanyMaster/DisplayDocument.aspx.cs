using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CompanyMaster
{
    public partial class DisplayDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string querystr = Request.QueryString["QS"].ToString();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand();
            Object returnValue = null;

            cmd.CommandText = "dbo.GetFile";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(querystr));
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            //returnValue = cmd.ExecuteScalar();
            Object filename = null;
            
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine("\t{0}\t{1}\t{2}",reader[0], reader[1], reader[2]);
                filename = reader[0];
                returnValue = reader[1];

            }
            reader.Close();


            sqlConnection.Close();

            string strpath = System.IO.Path.GetExtension(filename.ToString());

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment; filename=" +filename.ToString());  
            Response.ContentType = "application/pdf";

            byte[] fileContent = ObjectToByteArray(returnValue);
            this.Response.BinaryWrite(fileContent);
            this.Response.End();

            //return returnValue.ToString();
        }

        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}