using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EPINSHOP2
{
    public partial class Calisanlar : Form
    {
        public Calisanlar()
        {
            InitializeComponent();
            DisplayCalisanlar();

            CalisanAdLbl.Text = Login.CalisanKullaniciAdi;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (CalisanAdresTb.Text == "" || CalisanAdTb.Text == "" || CalisanDTTb.Text == "" || CalisanSifreTb.Text == "" || CalisanTelTb.Text == "")
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("Update CalisanTablosu set CalisanAd=@Cad, CalisanAdres=@Cadres, CalisanDT=@Cdt, CalisanTel=@Ctel, CalisanSifre=@Csifre where CalisanId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@Cad", CalisanAdTb.Text);
                    cmd.Parameters.AddWithValue("@Cadres", CalisanAdresTb.Text);
                    cmd.Parameters.AddWithValue("@Cdt", CalisanDTTb.Text);
                    cmd.Parameters.AddWithValue("@Ctel", CalisanTelTb.Text);
                    cmd.Parameters.AddWithValue("@Csifre", CalisanSifreTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Calışan Güncellendi");

                    Con.Close();
                    DisplayCalisanlar();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int Key = 0;
        private void bunifuDataGridView1_CellContentClick(object sender, EventArgs e)
        {

            CalisanAdTb.Text = CalisanlarDGV.SelectedRows[0].Cells[1].Value.ToString();
            CalisanAdresTb.Text = CalisanlarDGV.SelectedRows[0].Cells[2].Value.ToString();
            CalisanDTTb.Text = CalisanlarDGV.SelectedRows[0].Cells[3].Value.ToString();
            CalisanTelTb.Text = CalisanlarDGV.SelectedRows[0].Cells[4].Value.ToString();
            CalisanSifreTb.Text = CalisanlarDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (CalisanAdTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CalisanlarDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayCalisanlar()
        {
            Con.Open();

            string query = "Select * from CalisanTablosu";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CalisanlarDGV.DataSource = ds.Tables[0];

            Con.Close();
        }

        private void Clear()
        {
            CalisanAdresTb.Text = "";
            CalisanAdTb.Text = "";
            CalisanDTTb.Text = "";
            CalisanSifreTb.Text = "";
            CalisanTelTb.Text = "";
        }
        private void Eklebtn_Click(object sender, EventArgs e)
        {
            if(CalisanAdresTb.Text == "" || CalisanAdTb.Text == "" || CalisanDTTb.Text == "" || CalisanSifreTb.Text == "" || CalisanTelTb.Text == "")
            {
                MessageBox.Show("Eksik yerleri doldurunuz.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into CalisanTablosu (CalisanAd, CalisanAdres, CalisanDT, CalisanTel, CalisanSifre) values(@Cad,@Cadres,@Cdt,@Ctel,@Csifre)", Con);
                    cmd.Parameters.AddWithValue("@Cad", CalisanAdTb.Text);
                    cmd.Parameters.AddWithValue("@Cadres", CalisanAdresTb.Text);
                    cmd.Parameters.AddWithValue("@Cdt", CalisanDTTb.Text);
                    cmd.Parameters.AddWithValue("@Ctel", CalisanTelTb.Text);
                    cmd.Parameters.AddWithValue("@Csifre", CalisanSifreTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Calışan Eklendi");

                    Con.Close();
                    DisplayCalisanlar();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Silbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Önce Çalışanı Seç.");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("delete from CalisanTablosu where CalisanId=@CKey", Con);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Calışan Silindi");

                    Con.Close();
                    DisplayCalisanlar();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Musteriler Obj = new Musteriler();
            Obj.Show();
            this.Hide();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Urunler Obj = new Urunler();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Fatura Obj = new Fatura();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Homes Obj = new Homes();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Calisanlar_Load(object sender, EventArgs e)
        {

        }
    }
}
