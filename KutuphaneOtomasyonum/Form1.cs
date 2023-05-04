using KutuphaneOtomasyonum.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KutuphaneOtomasyonum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller controller = new controller();

             users donenDeger = controller.login(txt_kullaniciadi.Text, txt_sifre.Text);

            if (donenDeger.status == loginStatus.basarili && donenDeger.yetki=="admin")
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else if (donenDeger.status == loginStatus.basarili && donenDeger.yetki == "üye")
            {
                uyeEkrani uyeEkrani = new uyeEkrani();
                uyeEkrani.Show();
                this.Hide();
            }
            else if (donenDeger.status == loginStatus.basarisiz)
            {
                MessageBox.Show("Yanlış giriş yaptınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (donenDeger.status==loginStatus.eksikParametre)
            {
                MessageBox.Show("Bütün alanları doldurunuz !! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Şifre görünürlüğü ayarı (Gizleyip göstermek için);

            if (txt_sifre.PasswordChar.ToString() == "*")
            {
                txt_sifre.PasswordChar = char.Parse("\0");
            }
            else if (txt_sifre.PasswordChar.ToString() == "\0")
            {
                txt_sifre.PasswordChar = char.Parse("*");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (txt_sifre.PasswordChar.ToString() == "\0")
            {
                txt_sifre.PasswordChar = char.Parse("*");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            kayitOl kayitOl = new kayitOl();
            kayitOl.Show();
            this.Hide();
        }
    }
}
