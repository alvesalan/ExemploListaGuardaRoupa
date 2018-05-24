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
    public partial class ListaPeca : Form
    {
        public ListaPeca()
        {
            InitializeComponent();
        }


        private void ListaPeca_Load(object sender, EventArgs e)
        {
        }

        private void AtualizarLista()
        {
            dgvListaPeca.Rows.Clear();
            string busca = txtBusca.Text;
            for (int i = 0; i < Program.pecas.Count; i++)
            {

                Peca peca = Program.pecas[i];
                if (peca.Ativo == true &&
                    
                    (peca.Nome.Contains(busca) || peca.Marca.Contains(busca)))
                {
                dgvListaPeca.Rows.Add(new object[]{
                peca.Nome, peca.Cor, peca.Marca, peca.Valor });
                   
                }
                {
                    
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CadastroPeca().ShowDialog();
        }

        private void dgvListaPeca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int LinhaSelecionada = dgvListaPeca.CurrentRow.Index;

            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não tem nenhuma peça selecionada");
            }

            
            Peca peca = Program.pecas[LinhaSelecionada];
            new CadastroPeca(peca, LinhaSelecionada).ShowDialog();

            CadastroPeca cadastropeca = new CadastroPeca(peca, LinhaSelecionada);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não tem nwnhuma peça selecionada");
                return;
            }

            int LinhaSelecionada = dgvListaPeca.CurrentRow.Index;

            Peca peca = Program.pecas[LinhaSelecionada];
            DialogResult resultado = MessageBox.Show("Deseja apagar " + peca.Nome + " o registro?", "AVISO", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                Program.pecas.RemoveAt(LinhaSelecionada);
                AtualizarLista();
                MessageBox.Show("Registro apagado com sucesso");
            }
            else
            {
                MessageBox.Show("Ta salvo o seu registro");
            }

           
        }

        private void ListaPeca_Activated(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AtualizarLista();
            }
        }

        private void txtBusca_Leave(object sender, EventArgs e)
        {
            AtualizarLista();
        }

    }
}
