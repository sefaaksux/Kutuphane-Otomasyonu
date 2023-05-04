using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneOtomasyonum.controllers;
using System.Windows.Forms;

namespace KutuphaneOtomasyonum
{
    public partial class uyeEkrani : Form
    {
        controller controller = new controller();
        public uyeEkrani()
        {
            InitializeComponent();
        }

        private void uyeEkrani_Load(object sender, EventArgs e)
        {
            kitaplariGetir();
            this.dataGridView1.Columns["status"].Visible = false;
        }
        private void kitaplariGetir()
        {
            List<kitap> bookList = controller.kitaplariGetir();
            dataGridView1.DataSource = bookList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result1 == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            
        }
    }
}
