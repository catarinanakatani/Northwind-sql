using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catarina_e_giuliana
{
    public partial class Form1 : Form
    {
        private SqlConnection conexao;
        private SqlDataAdapter adapter;
        private DataTable tblcategorias, tblveiculos;
        private string strsql, strconex;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            strconex = "data source=(local);initial catalog=locadora;" +
                  "integrated security=True";
            conexao = new SqlConnection(strconex);
            conexao.Open();

            tblcategorias = new DataTable();

            strsql = "select * from categorias";
            adapter = new SqlDataAdapter(strsql, conexao);
            adapter.Fill(tblcategorias);

            cbocategoria.DataSource = tblcategorias;
            cbocategoria.DisplayMember = "categoria";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tblcategorias = new DataTable();
                strsql = "select * from categorias where  " +
                    " categoria='" + cbocategoria.Text + "'";


                adapter = new SqlDataAdapter(strsql, conexao);
                adapter.Fill(tblcategorias);

                txtvalor.Text = tblcategorias.Rows[0]["valor"].ToString();
                txtdescricao.Text = tblcategorias.Rows[0]["descricao"].ToString();

                string codcategoria = tblcategorias.Rows[0]["codcategoria"].ToString();
                tblveiculos = new DataTable();
                strsql = "select * from Veiculos where   " +
                    "   codcategoria='" + codcategoria + "'";
                adapter = new SqlDataAdapter(strsql, conexao);

                adapter.Fill(tblveiculos);
                gradeveiculos.DataSource = tblveiculos;

            }
            catch
            { 

            }
        }

        private void txtdescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
