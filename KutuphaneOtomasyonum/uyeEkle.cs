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

namespace KutuphaneOtomasyonum
{
    public partial class uyeEkle : Form
    {
        controller controller = new controller();
        public uyeEkle()
        {
            InitializeComponent();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            
            int donenDeger = controller.uyeEkle(txt_adi.Text, txt_soyadi.Text, txt_kullaniciAdi.Text,txt_sifre.Text,txt_yetki.Text);

                if (donenDeger == 1)
                {
                    MessageBox.Show("Başarıyla eklendi.");
                }
                else
                {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor.");
                }
                

            uyeleriGetir();
            
        }

        private void uyeEkle_Load(object sender, EventArgs e)
        {
            uyeleriGetir();
            this.dataGridView1.Columns["status"].Visible = false;
        }
        private void uyeleriGetir()
        {
            List<users> usersList = controller.uyeleriGetir();
            dataGridView1.DataSource = usersList;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int donenDeger = controller.uyeSil(txt_kullaniciAdi.Text);
            if (donenDeger == 1)
            {
                MessageBox.Show("Başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }
            uyeleriGetir();

        }
        public void textleriDoldur()
        {
            txt_adi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_soyadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_kullaniciAdi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textleriDoldur();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {

            int donenDeger = controller.uyeGuncelle(txt_adi.Text,txt_soyadi.Text,txt_kullaniciAdi.Text,txt_sifre.Text,txt_yetki.Text);

            if (donenDeger == 1)
            {
                MessageBox.Show("Başarıyla güncellendi.");
                uyeleriGetir();
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
