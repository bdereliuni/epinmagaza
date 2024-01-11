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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
            DisplayMusteriler();

            CalisanAdLbl.Text = Login.CalisanKullaniciAdi;
        }

        int Key = 0;
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (MusteriAdresTb.Text == "" || MusteriAdTb.Text == "" || MusteriTelTb.Text == "")
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("Update MusteriTablosu set MusteriAd=@Mad, MusteriAdres=@Madres, MusteriTel=@Mtel where MusteriId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@Mad", MusteriAdTb.Text);
                    cmd.Parameters.AddWithValue("@Madres", MusteriAdresTb.Text);
                    cmd.Parameters.AddWithValue("@Mtel", MusteriTelTb.Text);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Güncellendi");

                    Con.Close();
                    DisplayMusteriler();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayMusteriler()
        {
            Con.Open();

            string query = "Select * from MusteriTablosu";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MusterilerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            MusteriAdresTb.Text = "";
            MusteriAdTb.Text = "";
            MusteriTelTb.Text = "";
        }

        private void Eklebtn_Click(object sender, EventArgs e)
        {
            if (MusteriAdresTb.Text == "" || MusteriAdTb.Text == "" || MusteriTelTb.Text == "")
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into MusteriTablosu (MusteriAd, MusteriAdres, MusteriTel) values(@Mad,@Madres,@Mtel)", Con);
                    cmd.Parameters.AddWithValue("@Mad", MusteriAdTb.Text);
                    cmd.Parameters.AddWithValue("@Madres", MusteriAdresTb.Text);
                    cmd.Parameters.AddWithValue("@Mtel", MusteriTelTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Eklendi");

                    Con.Close();
                    DisplayMusteriler();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MusterilerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MusteriAdTb.Text = MusterilerDGV.SelectedRows[0].Cells[1].Value.ToString();
            MusteriAdresTb.Text = MusterilerDGV.SelectedRows[0].Cells[2].Value.ToString();
            MusteriTelTb.Text = MusterilerDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (MusteriAdTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MusterilerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Önce Müşteriyi Seç.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("delete from MusteriTablosu where MusteriId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Silindi");

                    Con.Close();
                    DisplayMusteriler();
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

        private void label1_Click(object sender, EventArgs e)
        {
            Urunler obj = new Urunler();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Calisanlar obj = new Calisanlar();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Fatura obj = new Fatura();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {

        }
    }
}
