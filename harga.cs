using MySql.Data.MySqlClient;
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
    public partial class harga : Form
    {
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        public String id;
        public harga()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datejam.Text = DateTime.Now.ToLongTimeString();
        }

        private void harga_Load(object sender, EventArgs e)
        {
            Datejam.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            Tampil1();
            Tampil2();
        }

        private void close_Click(object sender, EventArgs e)
        {
            lobby lobbyForm = new lobby();

            lobbyForm.Show();

            this.Hide();
        }

        private void Clear()
        {
            txtmeal.Text = "";

            btnupdatemeal.Enabled = false;
        }

        private void Tampil1()
        {
            try
            {

                koneksi.conn.Open(); 

                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `mcd_kw`.`fast_meal`", koneksi.conn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dgfastmeal.DataSource = ds.Tables[0];
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Duh!!, Ada Error Nih" + ex.Message);
            }
        }

        private void Tampil2()
        {
            try
            {

                koneksi.conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `mcd_kw`.`drinks_dessert`", koneksi.conn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dgdessert.DataSource = ds.Tables[0];
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Duh!!, Ada Error Nih" + ex.Message);
            }
        }

        private void dgfastmeal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnupdatemeal.Enabled = true;

            int baris = dgfastmeal.CurrentCell.RowIndex;
            id = dgfastmeal.Rows[baris].Cells[0].Value.ToString();
            txtmeal.Text = dgfastmeal.Rows[baris].Cells[1].Value.ToString();
        }

        private void dgdessert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = dgdessert.CurrentCell.RowIndex;
            id = dgdessert.Rows[baris].Cells[0].Value.ToString();
            txtdessert.Text = dgdessert.Rows[baris].Cells[1].Value.ToString();
        }

        private void btnupdatemeal_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                String Queri = "UPDATE fast_meal SET `harga`='" + txtmeal.Text + "' WHERE  `id`='" + id + "'";
                cmd = new MySqlCommand(Queri, koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Update harga");
                koneksi.conn.Close();

                Tampil1();
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Gagal. Error: " + ex.Message);
            }
        }
        }
    }
