using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models; // Refetencia memo parça
using System.Data.SqlClient; //Chamado pra funfa parça
using System.Configuration;

namespace DAL
{
    public class PessoaDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BDAulaDALPPIICS"].ConnectionString; //Usando o App.config pra conectar no banco memo.

        public void InserirPessoa(Pessoa objPessoa)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO Pessoas (NmPessoa, NrCPF, DtNascimento,DsLogradouro,DsCidade,DsUF) VALUES (@nome, @cpf, @data, @logradouro, @cidade, @uf)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nome", objPessoa.NmPessoa);
                cmd.Parameters.AddWithValue("@cpf",objPessoa.NrCPF);
                cmd.Parameters.AddWithValue("@data",objPessoa.DtNascimento);
                cmd.Parameters.AddWithValue("@logradouro", objPessoa.DsLogradouro);
                cmd.Parameters.AddWithValue("@cidade", objPessoa.DsCidade);
                cmd.Parameters.AddWithValue("@uf", objPessoa.DsUF);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        public Pessoa SelecionarPessoaPeloCodigo(int codigo) //Para Selecionar uma pessoa pelo código igual um select no Bando de Dados
        {
            Pessoa objPessoa = null;

            //Vamos abrir uma conexão com o banco de dados
            SqlConnection conn = new SqlConnection(connectionString);

            // Escreve tryf e aperta o TAB
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Pessoas WHERE CdPessoa = @codigo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                //Usar o datareader , ele vai coloca os comando no datareader funciona igual uma tabela virtual

                SqlDataReader dr = cmd.ExecuteReader(); // Jogo os paranaue no dr
                //Verificando se tem linhas, e se ele consegue ler os resultados da tabela
                if (dr.HasRows && dr.Read())
                {
                    objPessoa = new Pessoa();
                    objPessoa.CdPessoa = codigo;
                    objPessoa.NmPessoa = dr["NmPessoa"].ToString(); // Coloca o nome da coluna que esta no banco de dados 
                    objPessoa.NrCPF = dr["NrCPF"].ToString();
                    objPessoa.DtNascimento = Convert.ToDateTime(dr["DtNascimento"]);
                    objPessoa.DsLogradouro = dr["DsLogradouro"].ToString();
                    objPessoa.DsCidade = dr["DsCidade"].ToString();
                    objPessoa.DsUF = dr["DsUF"].ToString();
                }



            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return objPessoa;
        }
        
        public void AtualizarPessoa(Pessoa objPessoa)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string sql = "UPDATE Pessoas SET NmPessoa = @nome, NrCPF = @cpf, DtNascimento = @data,DsLogradouro = @logradouro,DsCidade = @cidade,DsUF =  @uf WHERE CdPessoa = @codigo";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@codigo", objPessoa.CdPessoa);
                cmd.Parameters.AddWithValue("@nome", objPessoa.NmPessoa);
                cmd.Parameters.AddWithValue("@cpf", objPessoa.NrCPF);
                cmd.Parameters.AddWithValue("@data", objPessoa.DtNascimento);
                cmd.Parameters.AddWithValue("@logradouro", objPessoa.DsLogradouro);
                cmd.Parameters.AddWithValue("@cidade", objPessoa.DsCidade);
                cmd.Parameters.AddWithValue("@uf", objPessoa.DsUF);

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
