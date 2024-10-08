﻿using Model.Entitidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaSala.DAO
{
    public class DisciplinaDAO
    {
        private string LinhaConexao = "Server=LS05MPF;Database=AULA_DS;User Id=sa;Password=admsasql;";
        private SqlConnection Conexao;
        public DisciplinaDAO()
        {
            Conexao = new SqlConnection(LinhaConexao);
        }
        public void Inserir(DisciplinaEntidade disciplina)
        {
            Conexao.Open();
            string query = "Insert into Disciplinas (Nome,Sigla) Values (@nome, @sigla) ";
            SqlCommand comando = new SqlCommand(query, Conexao);
            SqlParameter parametro1 = new SqlParameter("@nome", disciplina.Nome);
            SqlParameter parametro2 = new SqlParameter("@sigla", disciplina.Sigla);
            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.ExecuteNonQuery();
            Conexao.Close();

        }
        public DataTable ObterDisciplinas()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Nome, Sigla  FROM Disciplinas Order by Id desc";
            SqlCommand comando = new SqlCommand(query, Conexao);

            SqlDataReader Leitura = comando.ExecuteReader();
            foreach (var atributos in typeof(DisciplinaEntidade).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    DisciplinaEntidade d = new DisciplinaEntidade();
                    d.Id = Convert.ToInt32(Leitura[0]);
                    d.Nome = Leitura[1].ToString();
                    d.Sigla = Leitura[2].ToString();
                    dt.Rows.Add(d.Linha());

                }
            }


            return dt;
        }

    }
}