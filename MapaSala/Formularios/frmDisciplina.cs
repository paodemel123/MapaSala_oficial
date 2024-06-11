using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Entitidades;

namespace MapaSala.Formularios
{
    public partial class frmDisciplina : Form
    {
        DataTable dados;
        int LinhaSelecionada;
        public frmDisciplina()
        {
            InitializeComponent();
            dados = new DataTable();
            
            foreach (var atributos in typeof(DisciplinaEntidade).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }

            dtGridDisciplina.DataSource = dados;
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DisciplinaEntidade d = new DisciplinaEntidade();
            d.Id = Convert.ToInt32(numId.Value);
            d.Nome = txtNomeDisciplina.Text;
            d.Sigla = txtSigla.Text;

            dados.Rows.Add(d.Linha());
            LimparCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos(); 
        }

        private void LimparCampos()
        {
            numId.Value = 0;
            txtNomeDisciplina.Text = "";
            txtSigla.Text = "";
        }

        private void dtGridDisciplina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LinhaSelecionada = e.RowIndex;
            MessageBox.Show("Novo Valor: " + LinhaSelecionada);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dtGridDisciplina.Rows.RemoveAt(LinhaSelecionada);
        }
    }
}
