using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum.Ado
{
    public class repository
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        // VERİTABANINA BAĞLANTI İŞLEMİ - REPOSİTORY
        public repository()
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa; password=1");
            //con = new SqlConnection(@"data source=.\SQLEXPRESS;initial catalog=kutuphane;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }



        // KAYITLARI VERİTABANINDAN ÇEKME İŞLEMİ - REPOSİTORY
        public users login(string kullaniciadi,string sifre)
        {
            List<users> userList = new List<users>();
            con.Open();
            cmd = new SqlCommand("select * from usersTable where kullaniciAdi=@p1 and sifre=@p2", con);
            cmd.Parameters.AddWithValue("@p1", kullaniciadi);
            cmd.Parameters.AddWithValue("@p2", sifre);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                users users = new users();
                
                users.adi = dr["adi"].ToString();
                users.soyadi = dr["soyAdi"].ToString();
                users.kullaniciadi = dr["kullaniciAdi"].ToString();
                users.sifre = dr["sifre"].ToString();
                users.yetki = dr["yetki"].ToString();
               
                if (users.yetki == "admin")
                {
                    users.yetki = "admin";
                }else if(users.yetki=="üye"){
                    users.yetki = "üye";
                }
                userList.Add(users);
                con.Close();
                users.status = loginStatus.basarili;
                
                return users;                

            }
            else
            {
                users users = new users();
                users.status = loginStatus.basarisiz;
                return users;
            }      
        }

        public List<users> uyeleriGetir()
        {
            List<users> usersList = new List<users>();
            
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
            con.Open();
            cmd = new SqlCommand("select * from usersTable", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                users users = new users();
                users.adi = dr["adi"].ToString();
                users.soyadi = dr["soyAdi"].ToString();
                users.kullaniciadi = dr["kullaniciAdi"].ToString();
                users.sifre = dr["sifre"].ToString();
                users.yetki = dr["yetki"].ToString();
                usersList.Add(users);
            }
            con.Close();
            return usersList;

        }


        // KİTAPLARI VERİTABANINDAN ÇEKME İŞLEMİ - REPOSİTORY
        public List<kitap> kitaplariGetir()
        {
            List<kitap> kitapList = new List<kitap>();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa;password=1");
            con.Open();
            cmd = new SqlCommand("select * from kitap", con);
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                kitap kitap = new kitap();
                kitap.kitapID =int.Parse( dr["kitapID"].ToString());
                kitap.Kitapİsmi = dr["Kitapİsmi"].ToString();
                kitap.Yazari = dr["Yazari"].ToString();
                kitap.SayfaSayisi = int.Parse( dr["SayfaSayisi"].ToString());
                kitap.YayinEvi = dr["YayinEvi"].ToString();
                kitap.BasimYili =int.Parse(dr["BasimYili"].ToString());
                kitapList.Add(kitap);
                kitap.status = loginStatus.basarili;
            }
            con.Close();
            return kitapList;

        }
        
        



        // KİTAP EKLEME - REPOSİTORY
        public int kitapEkle(string kitapismi,string yazari, int sayfasayisi, string yayinevi, int basimyili)
        {
            con.Open();
            cmd = new SqlCommand("insert into kitap(Kitapİsmi,Yazari,SayfaSayisi,YayinEvi,BasimYili) values(@p1,@p2,@p3,@p4,@p5)", con);
            cmd.Parameters.AddWithValue("@p1", kitapismi);
            cmd.Parameters.AddWithValue("@p2",yazari);
            cmd.Parameters.AddWithValue("@p3", sayfasayisi);
            cmd.Parameters.AddWithValue("@p4", yayinevi);
            cmd.Parameters.AddWithValue("@p5", basimyili);
            

            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            return donenDeger;

        }

        

        // KİTAP SİLME - REPOSİTORY
        public int kitapSil(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete from kitap where kitapID=@id", con);
            cmd.Parameters.AddWithValue("@id",id);
            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            return donenDeger;

        }

        // KİTAP güncelleme - REPOSİTORY
        public int kitapGuncelle(int id,string ismi,string yazari, int sayfasayisi, string yayinevi,int basimyili)
        {
            con.Open();
            cmd = new SqlCommand("update kitap set Kitapİsmi=@ismi,Yazari=@yazari, SayfaSayisi=@sayfasayisi , YayinEvi=@yayinevi, BasimYili=@basimyili where kitapID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ismi",ismi);
            cmd.Parameters.AddWithValue("@yazari", yazari);
            cmd.Parameters.AddWithValue("@sayfasayisi", sayfasayisi);
            cmd.Parameters.AddWithValue("@yayinevi", yayinevi);
            cmd.Parameters.AddWithValue("@basimyili", basimyili);
            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            return donenDeger;

        }

        // ÜYE EKLEME - REPOSİTORY
        public int uyeEkle(string adi, string soyadi, string kullaniciAdi, string sifre, string yetki)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=kutuphane;User ID=sa; password=1");
            con.Open();
            cmd = new SqlCommand("insert into usersTable(adi,soyAdi,kullaniciAdi,sifre,yetki) values(@p1,@p2,@p3,@p4,@p5)",con);
            cmd.Parameters.AddWithValue("@p1", adi);
            cmd.Parameters.AddWithValue("@p2", soyadi);
            cmd.Parameters.AddWithValue("@p3", kullaniciAdi);
            cmd.Parameters.AddWithValue("@p4", sifre);
            cmd.Parameters.AddWithValue("@p5", yetki);
            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            
            return donenDeger;
            
        }


        // ÜYE SİLME - REPOSİTORY
        public int uyeSil(string no)
        {
            con.Open();
            cmd = new SqlCommand("delete from usersTable where kullaniciAdi=@no", con);
            cmd.Parameters.AddWithValue("@no", no);
            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            return donenDeger;

        }

        // ÜYE güncelleme - REPOSİTORY
        public int uyeGuncelle(string adi, string soyadi, string kullaniciAdi, string sifre, string yetki)
        {
            con.Open();
            cmd = new SqlCommand("update usersTable set adi=@adi,soyadi=@soyadi, kullaniciAdi=@kullaniciAdi, sifre=@sifre, yetki=@yetki", con);
            cmd.Parameters.AddWithValue("@adi", adi);
            cmd.Parameters.AddWithValue("@soyadi", soyadi);
            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@yetki", yetki);

            int donenDeger = cmd.ExecuteNonQuery();
            con.Close();
            return donenDeger;

        }


        // kayıt olurken aynı kullanıcı adından var mı yok mu kontrolü.
        public bool KullaniciAdiKontrol(string kullaniciAdi)
        {
            con.Open();                      
            cmd = new SqlCommand("SELECT COUNT(*) FROM usersTable WHERE kullaniciAdi = @KullaniciAdi",con);
            cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;  
        }


    }
}
