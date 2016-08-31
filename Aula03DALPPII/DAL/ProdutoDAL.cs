using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class ProdutoDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BDAulaDALPPIICS"].ConnectionString;

        public void InserirProduto(Produto objProduto)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Produtos (NmProduto,DsProduto,VlProduto) VALUES (@nome,@descricao,@valor)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", objProduto.NmProduto);
                cmd.Parameters.AddWithValue("@descricao", objProduto.DsProduto);
                cmd.Parameters.AddWithValue("@valor", objProduto.VlProduto);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        public void ExcluirProduto(int cdProduto)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "DELETE FROM Produtos WHERE Cdproduto = @cdproduto";
                SqlCommand cmd = new SqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("cdproduto", cdProduto);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public List<Produto> ListarProdutos()
        {
            List<Produto> objProdutos = new List<Produto>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM Produtos";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Produto p = null;
                    while (dr.Read())
                    {
                        p = new Produto();
                        p.CdProduto = Convert.ToInt32(dr["Cdproduto"]);
                        p.NmProduto = dr["NmProduto"].ToString();
                        p.DsProduto = dr["DsProduto"].ToString();
                        p.VlProduto = Convert.ToDecimal(dr["VlProduto"]);

                        objProdutos.Add(p);

                    }
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return objProdutos;
        }
    }
}
