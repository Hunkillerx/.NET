﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_3Corte
{
    class Controlador
    {
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataAdapter adapt;

        //Constructor sobrecargado del DAO
        public Controlador(string cadenaConexion)
        {
            con = new SqlConnection(cadenaConexion);
            System.Diagnostics.Debug.WriteLine("Conexión establecida: " + con);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        //Método para realizar la inserción del registro
        public bool insertarRegistro(string nomProducto, int proovedor,int categoria,double precioUnd,string cantidadxUnd,int undxOrden,int nivelReorg,byte estaDescon)
        {
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("insert into dbo.Products(ProductName,SupplierID,CategoryID,UnitPrice,QuantityPerUnit,UnitsOnOrder,ReorderLevel,Discontinued)" +
                    " values(@productName,@supplierID,@categoryID,@unitPrice,@QuantxUnit,@undOrder,@reordLevel,@discont)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@productName", nomProducto);
                cmd.Parameters.AddWithValue("@supplierID", proovedor);
                cmd.Parameters.AddWithValue("@categoryID", categoria);
                cmd.Parameters.AddWithValue("@unitPrice", precioUnd);
                cmd.Parameters.AddWithValue("@QuantxUnit", cantidadxUnd);
                cmd.Parameters.AddWithValue("@undOrder", undxOrden);
                cmd.Parameters.AddWithValue("@reordLevel", nivelReorg);
                cmd.Parameters.AddWithValue("@discont", estaDescon);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seInserto);
        }


        public DataTable GetListaProovedores()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select SupplierID,CompanyName from dbo.Suppliers Order by SupplierID;", con);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetListaCategorias()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select CategoryID,CategoryName,Description from dbo.Categories Order by CategoryID;", con);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetListaProductos()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select * from dbo.Products Order by ProductID;", con);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetConsultaPunto9()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select A.ProductID,A.ProductName,A.QuantityPerUnit,B.CompanyName,B.Address,B.City from dbo.Products A " +
                    "INNER JOIN dbo.Suppliers B ON A.SupplierID = B.SupplierID Order by  ProductID asc;", con);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetProovedoresV2()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select CompanyName from dbo.Suppliers;", con);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetCategoriasV2()
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select CategoryName from dbo.Categories;", con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        public DataTable GetProovEspec(String Seleccion)
        {
            DataTable dt = new DataTable();
            bool seInserto = false;
            try
            {
                cmd = new SqlCommand("select A.ProductID,A.ProductName,A.QuantityPerUnit,B.CompanyName,B.Address,B.City from dbo.Products A " +
                    "INNER JOIN dbo.Suppliers B ON A.SupplierID = B.SupplierID where CompanyName = @CompanyName Order by  ProductID asc;", con);
                con.Open();
                cmd.Parameters.AddWithValue("@CompanyName", Seleccion);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);
                cmd.ExecuteNonQuery();
                seInserto = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de inserción: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (dt);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        //Método para realizar la modificación del registro
        public bool modificarRegistro(string nombre, string estado, int id)
        {
            bool seModifico = false;
            try
            {
                cmd = new SqlCommand("update tbl_Record set Name=@name,State=@state where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", nombre);
                cmd.Parameters.AddWithValue("@state", estado);
                cmd.ExecuteNonQuery();
                seModifico = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de modificación: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seModifico);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        public bool eliminarRegistro(int id)
        {
            bool seElimino = false;
            try
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                seElimino = true;
            }

            catch (Exception errorInsertar)
            {
                System.Diagnostics.Debug.WriteLine("Error de eliminación: " + errorInsertar.Message);
                System.Diagnostics.Debug.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (seElimino);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        /*public DataTable rellenarDatosDataSource()
        {
            DataTable tablaDatos = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.tbl_Record", con);
            adapt.Fill(tablaDatos);
            con.Close();

            return (tablaDatos);
        }
        //************************************************************************
        //************************************************************************
        //************************************************************************
        public RecordVO consultarRegistroRecord(string idRegistro)
        {
            RecordVO registroConsultado = new RecordVO();
            string queryString =
            "select Name, State from dbo.tbl_Record where id = @id";
            SqlCommand command = null;
            SqlDataReader cursor = null;


            try
            {
                con.Open();
                command = new SqlCommand(queryString, con);
                command.Parameters.AddWithValue("@id", idRegistro);

                //Recorremos el cursor de la consulta para obtener
                //los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.Nombre = cursor.GetString(0);
                        registroConsultado.IdEstado = cursor.GetInt32(1);
                    }

                    //Verificamos los datos
                    System.Diagnostics.Debug.WriteLine("NOMBRE = " + registroConsultado.Nombre
                        + " ID DEPTO = " + registroConsultado.IdEstado);
                }
            }

            catch (Exception errorLectura)
            {
                System.Diagnostics.Debug.WriteLine("Error de consulta: " + errorLectura.Message);
                RecordVO registroVacio = new RecordVO();
                registroVacio.Nombre = "SIN REGISTRO";
                registroVacio.IdEstado = 0;
                return (registroVacio);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            return (registroConsultado);
        }*/
    }
}
