using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonum
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitapeklesil kitapForm = new kitapeklesil();
            kitapForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result1==DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {

            }


            
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeEkle uyeekle = new uyeEkle();
            uyeekle.Show();
            this.Hide();
        }
    }
}
