using System;
using KutuphaneOtomasyonum.controllers;
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
    public partial class kayitOl : Form
    {
        controller controller = new controller();
        
        public kayitOl()
        {
            InitializeComponent();
        }
        

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            int donenDeger = controller.uyeEkle(txt_adi.Text, txt_soyadi.Text, txt_kullaniciAdi.Text, txt_sifre.Text, txt_yetki.Text);
            if (donenDeger == 1)
            {
                MessageBox.Show("Başarıyla kayıt olundu.");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten var.");
            }

            
        }
    }
}
