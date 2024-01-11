using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPINSHOP2
{
    public partial class Fatura : Form
    {
        public Fatura()
        {
            InitializeComponent();
            GetMusteriler();
            DisplayUrun();
            Displayislemler();

            CalisanAdLbl.Text = Login.CalisanKullaniciAdi;
        }

        int Key = 0;
        int Stock = 0;

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetMusteriler()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MusteriId from MusteriTablosu", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MusteriId", typeof(int));
            dt.Load(Rdr);
            MusteriIdCb.ValueMember = "MusteriId";
            MusteriIdCb.DataSource = dt;
            Con.Close();
        }

        private void DisplayUrun()
        {
            Con.Open();
            string Query = "Select * from UrunTablosu";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UrunlerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Displayislemler()
        {
            Con.Open();
            string Query = "Select * from FaturaTablosu";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void GetMusteriAd()
        {
            Con.Open();
            string Query = "Select * from MusteriTablosu where MusteriId='" + MusteriIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MusteriAdTb.Text = dr["MusteriAd"].ToString();
            }
            Con.Close();
        }

        private void StokGuncelle()
        {
            try
            {
                int YeniAdet = Stock - Convert.ToInt32(UrunAdetTb.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update UrunTablosu set UrunAdet=@Uadet where UrunId=@Ukey", Con);
                cmd.Parameters.AddWithValue("Uadet", YeniAdet);

                cmd.Parameters.AddWithValue("@Ukey", Key);

                cmd.ExecuteNonQuery();

                Con.Close();
                DisplayUrun();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int n = 0, GrdTotal = 0;
        private void Eklebtn_Click(object sender, EventArgs e)
        {
            if(UrunAdetTb.Text == "" || Convert.ToInt32(UrunAdetTb.Text) > Stock)
            {
                MessageBox.Show("Stok Yeterli Değil!!");
            }
            else if(UrunAdetTb.Text ==  "" || Key == 0)
            {
                MessageBox.Show("Eksik kısımlar var!");
            }
            else
            {
                int Total = Convert.ToInt32(UrunAdetTb.Text) * Convert.ToInt32(UrunFiyatTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(FaturaDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = UrunAdTb.Text;
                newRow.Cells[2].Value = UrunAdetTb.Text;
                newRow.Cells[3].Value = UrunFiyatTb.Text;
                newRow.Cells[4].Value = Total;
                GrdTotal = GrdTotal + Total;
                FaturaDGV.Rows.Add(newRow);
                n++;
                TotalLbl.Text = GrdTotal + "TL";
                StokGuncelle();
                Reset();
            }
        }

        private void Degistirbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            UrunAdTb.Text = "";
            UrunAdetTb.Text = "";
            Stock = 0;
            Key = 0;
        }

        private void UrunlerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunAdTb.Text = UrunlerDGV.SelectedRows[0].Cells[1].Value.ToString();
            //SteamCb.Text =   UrunlerDGV.SelectedRows[0].Cells[2].Value.ToString();
            Stock = Convert.ToInt32(UrunlerDGV.SelectedRows[0].Cells[3].Value.ToString());
            UrunFiyatTb.Text = UrunlerDGV.SelectedRows[0].Cells[4].Value.ToString();
            if(UrunAdTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UrunlerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void MusteriIdCb_SelectionChangeCommitted(Object sender,  EventArgs e)
        {
            GetMusteriAd();
        }

        private void InsertBill()
        {
            try
            {
                Con.Open();

                SqlCommand cmd = new SqlCommand("insert into FaturaTablosu (FaturaTarihi, Musteriid, Musteriad, Calisanad, Tutar) values(@Ft,@Mkey,@Mad,@Cad,@tutar)", Con);
                cmd.Parameters.AddWithValue("@Ft", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@Mkey", MusteriIdCb.Text);
                cmd.Parameters.AddWithValue("@Mad", MusteriIdCb.Text);
                cmd.Parameters.AddWithValue("@Cad", CalisanAdLbl.Text);
                cmd.Parameters.AddWithValue("@tutar", GrdTotal);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fatura Kaydedildi");

                Con.Close();
                Displayislemler();
                //Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string urunad;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            InsertBill();
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        int urunid, urunadet, urunfiyat, tottal, pos = 60;

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

        private void label6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Urunler obj = new Urunler();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void MusteriIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Burak Dereli E-pin Mağazası", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID URUN FİYAT ADET TOPLAM", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach(DataGridViewRow row in FaturaDGV.Rows)
            {
                urunid = Convert.ToInt32(row.Cells["Column1"].Value);
                urunad = "" + row.Cells["Column2"].Value;
                urunfiyat = Convert.ToInt32(row.Cells["Column3"].Value);
                urunadet = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + urunid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Red, new Point(26, pos));
                e.Graphics.DrawString("" + urunad, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Red, new Point(45, pos));
                e.Graphics.DrawString("" + urunfiyat, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Red, new Point(120, pos));
                e.Graphics.DrawString("" + urunad, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Red, new Point(175, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Red, new Point(235, pos));
            }

            e.Graphics.DrawString("Toplam Tutar:" + GrdTotal + " TL", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("*****************e-pin mağazası*****************", new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Crimson, new Point(10, pos+85));
            FaturaDGV.Rows.Clear();
            FaturaDGV.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;
        }

        private void Fatura_Load(object sender, EventArgs e)
        {

        }
    }
}
