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
    public partial class Form1 : Form
    {
        MySqlCommand cmd;
      //  MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            FileStream fs = new FileStream("nama.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string userLevel = (string)bf.Deserialize(fs);
            fs.Close();

            if (userLevel == "admin")
            {
                close.Text = "Kembali";
            }
            else
            {
                close.Text = "Logout";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Datelbl.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void FriesCb_CheckedChanged(object sender, EventArgs e)
        {
            if(FriesCb.Checked == true)
            {
                FriesTb.Enabled = true;
            }else
            {
                FriesTb.Enabled = false;
                FriesTb.Text = "0";
            }
        }

        private void BurgerCb_CheckedChanged(object sender, EventArgs e)
        {
            if (BurgerCb.Checked == true)
            {
                BurgerTb.Enabled = true;
            }
            else
            {
                BurgerTb.Enabled = false;
                BurgerTb.Text = "0";
            }
        }

        private void BuburCb_CheckedChanged(object sender, EventArgs e)
        {
            if (BuburCb.Checked == true)
            {
                BuburTb.Enabled = true;
            }
            else
            {
                BuburTb.Enabled = false;
                BuburTb.Text = "0";
            }
        }

        private void SandwichCb_CheckedChanged(object sender, EventArgs e)
        {
            if (SandwichCb.Checked == true)
            {
                SandwichTb.Enabled = true;
            }
            else
            {
                SandwichTb.Enabled = false;
                SandwichTb.Text = "0";
            }
        }

        private void ChickenCb_CheckedChanged(object sender, EventArgs e)
        {
            if (ChickenCb.Checked == true)
            {
                ChickenTb.Enabled = true;
            }
            else
            {
                ChickenTb.Enabled = false;
                ChickenTb.Text = "0";
            }
        }

        private void FishCb_CheckedChanged(object sender, EventArgs e)
        {
            if (FishCb.Checked == true)
            {
                FishTb.Enabled = true;
            }
            else
            {
                FishTb.Enabled = false;
                FishTb.Text = "0";
            }
        }

        private void ColaCb_CheckedChanged(object sender, EventArgs e)
        {
            if (ColaCb.Checked == true)
            {
                ColaTb.Enabled = true;
            }
            else
            {
                ColaTb.Enabled = false;
                ColaTb.Text = "0";
            }
        }

        private void FantaCb_CheckedChanged(object sender, EventArgs e)
        {
            if (FantaCb.Checked == true)
            {
                FantaTb.Enabled = true;
            }
            else
            {
                FantaTb.Enabled = false;
                FantaTb.Text = "0";
            }
        }

        private void FlurryCb_CheckedChanged(object sender, EventArgs e)
        {
            if (FlurryCb.Checked == true)
            {
                FlurryTb.Enabled = true;
            }
            else
            {
                FlurryTb.Enabled = false;
                FlurryTb.Text = "0";
            }
        }

        private void PepsiCb_CheckedChanged(object sender, EventArgs e)
        {
            if (PepsiCb.Checked == true)
            {
                PepsiTb.Enabled = true;
            }
            else
            {
                PepsiTb.Enabled = false;
                PepsiTb.Text = "0";
            }
        }

        private void FizzCb_CheckedChanged(object sender, EventArgs e)
        {
            if (FizzCb.Checked == true)
            {
                FizzTb.Enabled = true;
            }
            else
            {
                FizzTb.Enabled = false;
                FizzTb.Text = "0";
            }
        }

        private void SakuraCb_CheckedChanged(object sender, EventArgs e)
        {
            if (SakuraCb.Checked == true)
            {
                SakuraTb.Enabled = true;
            }
            else
            {
                SakuraTb.Enabled = false;
                SakuraTb.Text = "0";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            string userLevel = GetUserLevel();

            if (userLevel == "admin")
            {
                // Jika level pengguna adalah admin, buka form lobby
                lobby lobbyForm = new lobby();
                lobbyForm.Show();
                this.Hide();
            }
            else
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


        private string GetUserLevel()
        {
            // Gantilah dengan implementasi yang sesuai untuk membaca nama pengguna dari file "nama.txt"
            FileStream fs = new FileStream("nama.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            string nama = (string)bf.Deserialize(fs);
            fs.Close();

            // Gantilah dengan logika sesuai kebutuhan Anda
            if (nama == "admin")
            {
                return "admin";
            }
            else
            {
                return "kasir";
            }
        }

        // harga makanan dan minuman
        private double GetHargaFromDatabase(string namaItem, string jenisItem)
        {
            double harga = 0;

            try
            {
                koneksi.conn.Open();

                string query = $"SELECT harga FROM {jenisItem} WHERE nama = '{namaItem}'";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.conn);

                harga = Convert.ToDouble(cmd.ExecuteScalar());

                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mendapatkan harga {namaItem} dari database. Error: {ex.Message}");
            }

            return harga;
        }


        // varibel 
        double friestp, burgertp, buburtp, sandwichtp, chickentp, fishtp, colatp, fantatp, flurrytp, pepsitp, fizztp, sakuratp;
        double Subtotal = 0, tax, grdtotal;
        int totalItems = 0;

        private void btnpay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReceiptTb.Text))
            {
                MessageBox.Show("Please add items to the receipt before making a payment.");
                return;
            }

            double paymentAmount = grdtotal; 
            using (var paymentForm = new Form())
            {
                paymentForm.Text = "Enter Payment Amount";
                paymentForm.Size = new Size(300, 150);
                paymentForm.StartPosition = FormStartPosition.CenterParent;

                Label label = new Label();
                label.Text = "Enter Payment Amount:";
                label.Location = new Point(10, 20);

                TextBox paymentTextBox = new TextBox();
                paymentTextBox.Location = new Point(10, 50);

                Button confirmButton = new Button();
                confirmButton.Text = "Confirm Payment";
                confirmButton.Location = new Point(10, 80);
                confirmButton.Click += (confirmSender, confirmArgs) =>
                {
                    if (double.TryParse(paymentTextBox.Text, out double customerPayment))
                    {
                        if (customerPayment >= paymentAmount)
                        {
                            // Payment successful
                            double change = customerPayment - paymentAmount;

                            // Append neatly formatted payment details to ReceiptTb
                            ReceiptTb.AppendText($"{"\t  Payment Amount:",-20}\t\tRp{customerPayment:N0}\n");
                            ReceiptTb.AppendText($"{"\t  Change:",-20}\t\tRp{change:N0}\n");

                            paymentForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("Insufficient payment. Please enter a valid amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                paymentForm.Controls.Add(label);
                paymentForm.Controls.Add(paymentTextBox);
                paymentForm.Controls.Add(confirmButton);

                paymentForm.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                DateTime timestamp = DateTime.Now;
                string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO orders (`pesanan`, `timestamp`) VALUES ('{ReceiptTb.Text}', '{formattedTimestamp}')";

                cmd = new MySqlCommand(query, koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Simpan Data Pesanan");
                koneksi.conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah Data Gagal");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReceiptTb.Text))
            {
                MessageBox.Show("ReceiptTb cannot be empty. Please enter some data.");
            }
            else
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(
            ReceiptTb.Text + " Subtotal " + Subtotallbl.Text + " Tax: " + Taxlbl.Text + " Grand Total " + Grdtotallbl.Text,
            new Font("Century Gothic", 12, FontStyle.Regular),Brushes.Blue,new Point(130));
        }

        
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FriesCb.Checked = false;
            BurgerCb.Checked = false;
            BuburCb.Checked = false;
            SandwichCb.Checked = false;
            ChickenCb.Checked = false;
            FishCb.Checked = false;
            ColaCb.Checked = false;
            FantaCb.Checked = false;
            FlurryCb.Checked = false;
            PepsiCb.Checked = false;
            FizzCb.Checked = false;
            SakuraCb.Checked = false;
            ReceiptTb.Clear();
            Subtotallbl.Text = "Rp/--";
            Grdtotallbl.Text = "Rp/--";
            Taxlbl.Text = "Rp/--";
            totalItems = 0;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            // Makanan bang
            friestp = GetHargaFromDatabase("FriedFries", "fast_meal") * Convert.ToDouble(FriesTb.Text);
            burgertp = GetHargaFromDatabase("BigMac", "fast_meal") * Convert.ToDouble(BurgerTb.Text);
            buburtp = GetHargaFromDatabase("Bubur", "fast_meal") * Convert.ToDouble(BuburTb.Text);
            sandwichtp = GetHargaFromDatabase("Sandwich", "fast_meal") * Convert.ToDouble(SandwichTb.Text);
            chickentp = GetHargaFromDatabase("ChickenNugget", "fast_meal") * Convert.ToDouble(ChickenTb.Text);
            fishtp = GetHargaFromDatabase("FishSnackWrap", "fast_meal") * Convert.ToDouble(FishTb.Text);
            // Minuman ygy
            colatp = GetHargaFromDatabase("ColaCola", "drinks_dessert") * Convert.ToDouble(ColaTb.Text);
            fantatp = GetHargaFromDatabase("Fanta", "drinks_dessert") * Convert.ToDouble(FantaTb.Text);
            flurrytp = GetHargaFromDatabase("MacFlurry", "drinks_dessert") * Convert.ToDouble(FlurryTb.Text);
            pepsitp = GetHargaFromDatabase("Pepsi", "drinks_dessert") * Convert.ToDouble(PepsiTb.Text);
            fizztp = GetHargaFromDatabase("AppleFizz", "drinks_dessert") * Convert.ToDouble(FizzTb.Text);
            sakuratp = GetHargaFromDatabase("SakuraFizz", "drinks_dessert") * Convert.ToDouble(SakuraTb.Text);

            ReceiptTb.Clear();
            Subtotal = 0;
            totalItems = 0;
            ReceiptTb.AppendText(Environment.NewLine);
            ReceiptTb.AppendText("\t\tRESTAURANT MEKDI KAWE SUPER" + Environment.NewLine);
            ReceiptTb.AppendText("\t\t\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ Environment.NewLine);
            ReceiptTb.AppendText("\t\t***********************************\n" + Environment.NewLine);
            TambahItemKeReceipt("French Fries", GetHargaFromDatabase("FriedFries", "fast_meal"), FriesCb, FriesTb);
            TambahItemKeReceipt("BigMac", GetHargaFromDatabase("BigMac", "fast_meal"), BurgerCb, BurgerTb);
            TambahItemKeReceipt("Bubur", GetHargaFromDatabase("Bubur", "fast_meal"), BuburCb, BuburTb);
            TambahItemKeReceipt("Sandwich", GetHargaFromDatabase("Sandwich", "fast_meal"), SandwichCb, SandwichTb);
            TambahItemKeReceipt("Chicken Nugget", GetHargaFromDatabase("ChickenNugget", "fast_meal"), ChickenCb, ChickenTb);
            TambahItemKeReceipt("Fish Snack Wrap", GetHargaFromDatabase("FishSnackWrap", "fast_meal"), FishCb, FishTb);
            TambahItemKeReceipt("Cola-Cola", GetHargaFromDatabase("ColaCola", "drinks_dessert"), ColaCb, ColaTb);
            TambahItemKeReceipt("Fanta", GetHargaFromDatabase("Fanta", "drinks_dessert"), FantaCb, FantaTb);
            TambahItemKeReceipt("Mac Flurry", GetHargaFromDatabase("MacFlurry", "drinks_dessert"), FlurryCb, FlurryTb);
            TambahItemKeReceipt("Pepsi", GetHargaFromDatabase("Pepsi", "drinks_dessert"), PepsiCb, PepsiTb);
            TambahItemKeReceipt("Apple Fizz", GetHargaFromDatabase("AppleFizz", "drinks_dessert"), FizzCb, FizzTb);
            TambahItemKeReceipt("Sakura Fizz", GetHargaFromDatabase("SakuraFizz", "drinks_dessert"), SakuraCb, SakuraTb);
            tax = Subtotal * 0.10; // tax 10% ya adik adik
            grdtotal = Subtotal + tax;
            Taxlbl.Text = $"Rp{tax:N0}";
            Grdtotallbl.Text = $"Rp{grdtotal:N0}";
            ReceiptTb.AppendText("\t================================" + Environment.NewLine);
            ReceiptTb.AppendText($"\t  SubTotal:\t\t\tRp{Subtotal:N0}" + Environment.NewLine);
            ReceiptTb.AppendText($"\t  Tax 10%:\t\t\tRp{tax:N0}" + Environment.NewLine);
            ReceiptTb.AppendText($"\t  Grand Total:\t\t\tRp{grdtotal:N0}" + Environment.NewLine);
        }

        private void TambahItemKeReceipt(string namaItem, double hargaItem, CheckBox checkBox, TextBox textBox)
        {
            if (checkBox.Checked == true)
            {
                int quantity = Convert.ToInt32(textBox.Text);
                double totalHargaItem = hargaItem * quantity;

                ReceiptTb.AppendText($"\t{namaItem,-20}\t{quantity}\tRp{hargaItem:N0}\tRp{totalHargaItem:N0}" + Environment.NewLine);

                Subtotal += totalHargaItem;
                totalItems += quantity;
                Subtotallbl.Text = Subtotal.ToString("N0");
            }
        }


        private void ReceiptTb_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
