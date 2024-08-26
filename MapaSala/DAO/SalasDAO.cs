using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entitidades;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace mapasala.DAO
{
    public class SalasDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        public SalasDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(SalasEntidade salas)
        {
            Conexao.Open();
            string query = "Insert into Salas (NomeSala,Turno) Values (@nomesala, @turno) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro1 = new SqlParameter("@nomesala", salas.Nome);
            SqlParameter parametro2 = new SqlParameter("@numerocadeiras", salas.NumeroCadeiras);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.ExecuteNonQuery();
            Conexao.Close();

        }
        public DataTable ObterSalas()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Nome,NumeroCadeiras, NumeroComputadores  FROM Salas Order by Id desc";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(SalasEntidade).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    SalasEntidade s = new SalasEntidade();
                    s.Id = Convert.ToInt32(Leitura[0]);
                    s.Nome = Leitura[1].ToString();
                    s.NumeroComputadores = Convert.ToInt32(Leitura[2]);
                    s.NumeroCadeiras = Convert.ToInt32(Leitura[3]);
                    dt.Rows.Add(s.Linha());

                }
            }
            Conexao.Close();

            return dt;
        }

    }
}