using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPINSHOP2
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        int StartP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            StartP += 1;
            MyProgress.Value = StartP;
            PercentLbl.Text = StartP + "%";
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                Login obj = new Login();
                obj.Show();
                this.Hide();
                timer1.Stop();  
            }
        }
    }
}
