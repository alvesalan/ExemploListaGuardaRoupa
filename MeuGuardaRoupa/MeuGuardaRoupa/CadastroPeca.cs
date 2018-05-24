using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuGuardaRoupa
{
    public partial class CadastroPeca : Form
    {


      
        private Peca peca;
        private int posicao = -1;

        public CadastroPeca()
        {
            InitializeComponent();

            for (int i = 0; i < 60; i++)
            {
                cbTamanho.Items.Add(i);
            }
        }

        public CadastroPeca(Peca peca, int posicao)
        {
            this.posicao = posicao;
            InitializeComponent();
            txtNome.Text = peca.Nome;
            txtValor.Text = Convert.ToString(peca.Valor);
            cbCor.SelectedItem = peca.Cor;
            cbMarca.SelectedItem = peca.Marca;
            cbTamanho.Text = peca.Tamanho;
            cbTecido.SelectedItem = peca.Tecido;
            cbTipo.SelectedItem = peca.Tipo;
            dtpDataCompra.Value = peca.DataCompra;
        }
        
        private void CadastroPeca_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text.Length < 4) 
            {
                MessageBox.Show("Nome deve conter no minimo 4 caracteres");
                txtNome.Focus();
                return;
            }

            if (cbTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo da peça");
                cbTipo.DroppedDown = true;
                return;
            }

            if (cbTamanho.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tamanho da peça");
                cbTamanho.DroppedDown = true;
                return;
            }
            if (txtValor.Text.Length == 0)
            {
                MessageBox.Show("Valor deve ser preenchido");
                txtValor.Focus();
                return;
            }
            try
            {
                double valor = Convert.ToDouble(txtValor.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Valor deve conter somente numeros reais");
                txtValor.Focus();
                return;
                
            }

            if (cbMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a marca");
                cbMarca.DroppedDown = true;
                return;
            }
            if (cbCor.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a cor");
                cbCor.DroppedDown = true;
                return;
            }
            if (cbTecido.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um tecido");
                cbTecido.DroppedDown = true;
                return;
            }
            if (dtpDataCompra.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Data da compra incorreta porfavor digite uma data valida");
            }


            Peca peca = new Peca()
            {


                Nome = txtNome.Text,
                Cor = cbCor.SelectedItem.ToString(),
                Marca = cbMarca.SelectedItem.ToString(),
                Tamanho = cbTamanho.SelectedItem.ToString(),
                Tipo = cbTecido.SelectedItem.ToString(),
                Valor = Convert.ToDouble(txtValor.Text),
                Tecido = cbTecido.SelectedItem.ToString(),
                DataCompra = dtpDataCompra.Value,
                Ativo = rbStatusAtivo.Checked

            };

            if (posicao >= 0 )
            {
                Program.pecas[posicao] = peca;
                MessageBox.Show("Cadastro realizado com sucesso");
            }

            Program.pecas.Add(peca);
            MessageBox.Show("Cadastro realizado com sucesso");
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtValor.Text = "";
            cbCor.SelectedIndex = -1;
            cbTamanho.SelectedIndex = -1;
            cbTecido.SelectedIndex = -1;
            cbMarca.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
            dtpDataCompra.Value = DateTime.Now;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
