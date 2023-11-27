using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mekdi_kawe
{
    public partial class lobby : Form
    {
        public lobby()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            harga hargaForm = new harga();

            // Menampilkan form harga
            hargaForm.Show();

            // Menutup form lobby (jika perlu)
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 kasirForm = new Form1();

            // Menampilkan form harga
            kasirForm.Show();

            // Menutup form lobby (jika perlu)
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new login().Show();
                this.Hide();
                MessageBox.Show("Logout berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
