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

namespace EPINSHOP2
{
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
            DisplayUrunler();

            CalisanAdLbl.Text = Login.CalisanKullaniciAdi;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (UrunAdTb.Text == "" || UrunAdetTb.Text == "" || UrunFiyatTb.Text == "" || UrunkategoriCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into UrunTablosu (UrunAd, UrunAdet, UrunFiyat, UrunKategori) values(@Uad, @Uadet, @Ufiyat, @Ukategori)", Con);
                    cmd.Parameters.AddWithValue("@Uad", UrunAdTb.Text);
                    cmd.Parameters.AddWithValue("@Uadet", UrunAdetTb.Text);
                    cmd.Parameters.AddWithValue("@Ufiyat", UrunFiyatTb.Text);
                    cmd.Parameters.AddWithValue("@Ukategori", UrunkategoriCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün Eklendi");

                    Con.Close();
                    DisplayUrunler();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayUrunler()
        {
            Con.Open();

            string query = "Select * from UrunTablosu";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UrunlerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            UrunAdTb.Text = "";
            UrunAdetTb.Text = "";
            UrunFiyatTb.Text = "";
            UrunkategoriCb.SelectedIndex = 0;
        }

        private void Degistirbtn_Click(object sender, EventArgs e)
        {
            if (UrunAdTb.Text == "" || UrunAdetTb.Text == "" || UrunFiyatTb.Text == "" || UrunkategoriCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("Update UrunTablosu set UrunAd=@Uad, UrunAdet=@Uadet, UrunFiyat=@Ufiyat, UrunKategori=@Ukategori where UrunId=@UKey", Con);
                    cmd.Parameters.AddWithValue("@Uad", UrunAdTb.Text);
                    cmd.Parameters.AddWithValue("@Uadet", UrunAdetTb.Text);
                    cmd.Parameters.AddWithValue("@Ufiyat", UrunFiyatTb.Text);
                    cmd.Parameters.AddWithValue("@Ukategori", UrunkategoriCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün Güncellendi");

                    Con.Close();
                    DisplayUrunler();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int Key = 0;

        private void UrunlerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunAdTb.Text = UrunlerDGV.SelectedRows[0].Cells[1].Value.ToString();
            UrunkategoriCb.Text = UrunlerDGV.SelectedRows[0].Cells[2].Value.ToString();
            UrunAdetTb.Text = UrunlerDGV.SelectedRows[0].Cells[3].Value.ToString();
            UrunFiyatTb.Text = UrunlerDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (UrunAdTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UrunlerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Önce Ürünü Seç.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("delete from UrunTablosu where UrunId=@UKey", Con);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün Silindi");

                    Con.Close();
                    DisplayUrunler();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Calisanlar obj = new Calisanlar();
            obj.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Musteriler obj = new Musteriler();
            obj.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Fatura obj = new Fatura();
            obj.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Urunler_Load(object sender, EventArgs e)
        {

        }
    }
}
