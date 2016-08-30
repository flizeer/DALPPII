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
    }
}
