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
    public partial class Login : Form
    {
        public static string CalisanKullaniciAdi = "";
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bdere\Documents\EpinShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = usernameTb.Text;
            user_password = passwordTb.Text;

            try
            {
                String Query = "Select * from CalisanTablosu where CalisanAd='" + usernameTb.Text + "' and CalisanSifre='" + passwordTb.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count > 0 ) 
                {
                    username = usernameTb.Text;
                    user_password = passwordTb.Text;
                    CalisanKullaniciAdi = usernameTb.Text;
                    Homes obj = new Homes();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Bilgisi!");
                }
            }
            catch
            {
                MessageBox.Show("Hata!");
            }
            finally
            {
                Con.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
