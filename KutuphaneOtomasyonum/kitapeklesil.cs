using KutuphaneOtomasyonum.controllers;
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

namespace KutuphaneOtomasyonum
{
    public partial class kitapeklesil : Form
    {
        controllers.controller controller = new controllers.controller();
        
        public kitapeklesil()
        {
            InitializeComponent();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void kitapeklesil_Load(object sender, EventArgs e)
        {
            kitaplariGetir();
        }

        private void kitaplariGetir()
        {
            List<kitap> bookList = controller.kitaplariGetir();
            dataGridView1.DataSource = bookList;
        }

        // KİTAP EKLEME
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
           int donenDeger = controller.kitapEkle(txt_kitapİsmi.Text, txt_yazari.Text,int.Parse( txt_sayfaSayisi.Text), txt_yayinEvi.Text,int.Parse( txt_basimYili.Text));
           if(donenDeger == 1)
            {
                MessageBox.Show("Başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }
            kitaplariGetir();
        }

        public void textleriDoldur()
        {
            txt_id.Text =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_kitapİsmi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_yazari.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_sayfaSayisi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_yayinEvi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_basimYili.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textleriDoldur();         
        }

        // KİTAP SİLME
        private void btn_sil_Click(object sender, EventArgs e)
        {
           int donenDeger = controller.kitapSil(int.Parse( txt_id.Text));
            if (donenDeger == 1)
            {
                MessageBox.Show("Başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }

            kitaplariGetir();
        }


        // KİTAP GÜNCELLEME
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            

            int donenDeger = controller.kitapGuncelle(int.Parse( txt_id.Text), txt_kitapİsmi.Text, txt_yazari.Text,int.Parse( txt_sayfaSayisi.Text), txt_yayinEvi.Text,int.Parse( txt_basimYili.Text));

            if (donenDeger == 1)
            {
                MessageBox.Show("Başarıyla güncellendi.");
                kitaplariGetir();
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }

        }
    }
}
