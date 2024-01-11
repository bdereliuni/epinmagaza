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
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            SteamStok();
            UplayStok();
            EpicGamesStok();
            ElectronicArtsStok();
            Finance();

            CalisanAdLbl.Text = Login.CalisanKullaniciAdi;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Finance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(Tutar) from FaturaTablosu", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gelirLbl.Text = dt.Rows[0][0].ToString() + " TL";
            Con.Close();
        }

        private void SteamStok()
        {
            string Kategori = "Steam";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UrunTablosu where UrunKategori='" + Kategori + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SteamLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void UplayStok()
        {
            string Kategori = "Uplay";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UrunTablosu where UrunKategori='" + Kategori + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            UplayLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void EpicGamesStok()
        {
            string Kategori = "Epic Games";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UrunTablosu where UrunKategori='" + Kategori + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EpicLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void ElectronicArtsStok()
        {
            string Kategori = "Electronic Arts";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from UrunTablosu where UrunKategori='" + Kategori + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EALbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

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

        private void label4_Click(object sender, EventArgs e)
        {
            Musteriler obj = new Musteriler();
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

        private void Homes_Load(object sender, EventArgs e)
        {

        }
    }
}
