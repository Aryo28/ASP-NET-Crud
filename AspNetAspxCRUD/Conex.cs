using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNetAspxCRUD
{
    /*CREATE LOGIN meuLogin WITH PASSWORD='senha';
        CREATE USER meuLogin FROM LOGIN meuLogin;
        EXEC SP_ADDROLEMEMBER 'DB_DATAREADER', 'meuLogin';
        EXEC SP_ADDROLEMEMBER 'DB_DATAWRITER', 'meuLogin'*/

    public class Conex
    {
        private string conec = @"user id=sa;" +
                @"password=utlaguna1.;server=CTEUTLD01\SEGURIDADB;" +
            //   @"Trusted_Connection=yes;" +
                @"database=securityB;" +
                @"connection timeout=30";

        private SqlConnection cn;

        private void conexion()
        {
            cn = new SqlConnection(conec);
        }

        public SqlConnection abrirconexion()
        {
            try
            {
                conexion();
                cn.Open();

                return cn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void cerrarconexion()
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable executeQuery(string sql)
        {
            conexion();
            abrirconexion();
            try
            {
                SqlCommand sqlComm = new SqlCommand(sql, cn);
                sqlComm.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cerrarconexion();
            }
        }
    }
}