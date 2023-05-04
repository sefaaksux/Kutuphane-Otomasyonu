using KutuphaneOtomasyonum.Ado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum.controllers
{
    public class controller
    {
        

        
        
        public controller()
        {
            repository repository = new repository();
        }


        // KAYITLARI VERİTABANINDAN ÇEKME İŞLEMİ - CONTROLLER
        public users login(string kullaniciadi, string sifre)
        {
            users gelenDeger;
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                repository repository = new repository();
                gelenDeger = repository.login(kullaniciadi, sifre);
                return gelenDeger;
                
            }
            else
            {
                users users= new users();
                users.status = loginStatus.eksikParametre;
                return users;
            }

        }


        // KİTAP GETİR - CONTROLLER
        public List<kitap> kitaplariGetir()
        {
            repository repository = new repository();
            return repository.kitaplariGetir();
        }

        // KİTAP EKLEME - CONTROLLER
        public int kitapEkle(string kitapismi, string yazari, int sayfasayisi, string yayinevi, int basimyili)
        {
            repository repository = new repository();
             return repository.kitapEkle(kitapismi,yazari,sayfasayisi,yayinevi,basimyili);
            
        }
        
        // KİTAP SİLME - CONTROLLER
        public int kitapSil(int id)
        {
            repository repository = new repository();
             return repository.kitapSil(id);
        }

        // KİTAP GÜNCELLEME - CONTROLLER
        public int kitapGuncelle(int id, string ismi, string yazari, int sayfasayisi, string yayinevi, int basimyili)
        {
            repository repository = new repository();
            return repository.kitapGuncelle(id,ismi, yazari, sayfasayisi, yayinevi, basimyili);

        }

        // ÜYELERİ GETİR - CONTROLLER
        public List<users> uyeleriGetir()
        {
            repository repository = new repository();

            return repository.uyeleriGetir();
        }

        // ÜYE EKLEME - CONTROLLER
        public int uyeEkle(string adi, string soyadi, string kullaniciAdi, string sifre, string yetki)
        {
            repository repository = new repository();

            if (repository.KullaniciAdiKontrol(kullaniciAdi))
            {
                return 0;           
            }
            else
            {
                return repository.uyeEkle(adi, soyadi, kullaniciAdi, sifre, yetki);
            }
        }

        // ÜYE SİLME - CONTROLLER
        public int uyeSil(string no)
        {
            repository repository = new repository();
            return repository.uyeSil(no);
        }

        // ÜYE GÜNCELLEME - CONTROLLER
        public int uyeGuncelle(string adi, string soyadi, string kullaniciAdi, string sifre, string yetki)
        {
            repository repository = new repository();
            return repository.uyeGuncelle(adi,soyadi, kullaniciAdi, sifre, yetki);

        }


    }
}
