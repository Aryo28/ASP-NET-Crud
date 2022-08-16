using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNetAspxCRUD
{
    public class Alumnos
    {
        // Class properties

        public int id;
        public string nome;
        public string last_name;
        public int idade;
        public int altura;
   

        public bool gravarPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into students2 values (@nombre, @edad, @altura, @last_name)";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nome;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = idade;
            cmd.Parameters.Add("@altura", SqlDbType.Int).Value = altura;
            cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = last_name;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public bool excluirPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from students2 where id = @id";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public bool alterarPessoa()
        {
            Conex bd = new Conex();

            SqlConnection cn = bd.abrirconexion();
            SqlTransaction tran = null;

            SqlCommand cmd = new SqlCommand();
            tran = cn.BeginTransaction();

            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update students2 set name = @nombre, age = @edad, height = @altura, last_name = @last_name where id = @id";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nome;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = idade;
            cmd.Parameters.Add("@altura", SqlDbType.Int).Value = altura;
            cmd.Parameters.Add("@last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw;
                return false;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

        public Alumnos retornaPessoa(int id)
        {
            Conex bd = new Conex();

            try
            {
                SqlConnection cn = bd.abrirconexion();
                SqlDataReader rdr = null;

                SqlCommand sqlComm = new SqlCommand("select * from students2", cn);

                rdr = sqlComm.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr.GetInt32(0) == id)
                    {
                        id = 1;
                        nome = rdr.GetString(1);
                        idade = rdr.GetInt32(2);
                        altura = rdr.GetInt32(3);
                        last_name = rdr.GetString(4);

                        return this;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                bd.cerrarconexion();
            }
        }

    }
}