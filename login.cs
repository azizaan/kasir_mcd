using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mekdi_kawe
{
    public partial class login : Form
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtpassword.Text))
            {
                MessageBox.Show("Email dan password bersifat wajib fardhu ain, harap untuk diisi ya banh");
            }
            else
            {
                koneksi.conn.Open();
                string query = "SELECT * FROM `users` WHERE `username` = '" + txtusername.Text + "' AND `password` = '" + txtpassword.Text + "'";
                cmd = new MySqlCommand(query, koneksi.conn);
                dr = cmd.ExecuteReader();

                try
                {
                    if (dr.Read())
                    {
                        // Mendapatkan nilai kolom 'level'
                        string level = dr["level"].ToString();

                        if (level.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            // Jika tingkat adalah 'admin', tampilkan lobby
                            new lobby().Show();
                            // Ambil username pengguna
                            FileStream fs = new FileStream("nama.txt", FileMode.Create);
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(fs, level);
                            fs.Close();
                        }
                        else
                        {
                            // Jika tingkat bukan 'admin', tampilkan Form1
                            new Form1().Show();
                            // Ambil username pengguna
                            FileStream fs = new FileStream("nama.txt", FileMode.Create);
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(fs, level);
                            fs.Close();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Ups! Email atau Password anda Salah");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ups! Gagal Login");
                }

                koneksi.conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
