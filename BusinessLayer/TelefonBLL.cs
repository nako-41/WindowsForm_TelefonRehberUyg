using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLogicLayer;

namespace BusinessLayer
{
    public class TelefonBLL
    {
        TelefonDLL dll;

        public TelefonBLL()
        {
            dll = new TelefonDLL();
        }
        public int Kaydet(Rehber rehber)
        {
            if (!string.IsNullOrEmpty(rehber.Isim) && !string.IsNullOrEmpty(rehber.Soyisim))
            {
                int data = dll.KayitEkle(new Rehber
                {
                    Isim = rehber.Isim,
                    Soyisim = rehber.Soyisim,
                    TelefonNumarasi = rehber.TelefonNumarasi,
                    EmailAdres = rehber.EmailAdres,
                    WebAdres = rehber.WebAdres,
                    Adres = rehber.Adres,
                    Aciklama = rehber.Aciklama

                });

                return data;
            }
            else
            {
                return -1; //eksik parametre hatası
            }
        }

        public int KayitDuzenle(Rehber rehber)
        {
            if (rehber.ID !=-1 )
            {
                return dll.KayitDuzenle(new Rehber
                {
                    ID = rehber.ID,
                    Isim = rehber.Isim,
                    Soyisim = rehber.Soyisim,
                    TelefonNumarasi = rehber.TelefonNumarasi,
                    EmailAdres = rehber.EmailAdres,
                    WebAdres = rehber.WebAdres,
                    Adres = rehber.Adres,
                    Aciklama = rehber.Aciklama
                }
                );
            }
            else
            {
                return -1;
            }
        }

        public int KayitSil(Rehber rehber)
        {
            if (rehber.ID!=0)
            {
                return dll.KayitSil(rehber.ID);
            }
            else
            {
                return -1;
            }
        }

        public List<Rehber> KayitListe()
        {
            List<Rehber> rehberlistesi = new List<Rehber>();
            int s = 0;
            try
            {
                SqlDataReader read = dll.KayitListe();
                while (read.Read())
                {
                    rehberlistesi.Add(new Rehber()
                    {
                        ID = read.GetInt32(0),
                        Isim = read.IsDBNull(1) ? string.Empty : read.GetString(1),
                        Soyisim = read.IsDBNull(2) ? string.Empty : read.GetString(2),
                        TelefonNumarasi = read.IsDBNull(3) ? string.Empty : read.GetString(3),
                        EmailAdres = read.IsDBNull(4) ? string.Empty : read.GetString(4),
                        WebAdres = read.IsDBNull(5) ? string.Empty : read.GetString(5),
                        Adres = read.IsDBNull(6) ? string.Empty : read.GetString(6),
                        Aciklama = read.IsDBNull(7) ? string.Empty : read.GetString(7),

                    }); 
               
                } 
               
                read.Close();
            }
            catch (Exception ex)
            {

             
            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return rehberlistesi;
        }

        public Rehber KayitListeID(int ID)
        {
           Rehber rehberKayit = new Rehber();

            try
            {
                SqlDataReader read = dll.KayitListeId(ID);
                while (read.Read())
                {
                    rehberKayit = new Rehber()
                    {
                        ID = read.GetInt32(0),
                        Isim = read.IsDBNull(1) ? string.Empty : read.GetString(1),
                        Soyisim = read.IsDBNull(2) ? string.Empty : read.GetString(2),
                        TelefonNumarasi = read.IsDBNull(3) ? string.Empty : read.GetString(3),
                        EmailAdres = read.IsDBNull(4) ? string.Empty : read.GetString(4),
                        WebAdres = read.IsDBNull(5) ? string.Empty : read.GetString(5),
                        Adres = read.IsDBNull(6) ? string.Empty : read.GetString(6),
                        Aciklama = read.IsDBNull(7) ? string.Empty : read.GetString(7),

                    };

                }
                read.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return rehberKayit;
        }
        public int SistemKontol(Kullanici k)
        {
            if (!string.IsNullOrEmpty(k.KullaniciAdi) && !string.IsNullOrEmpty(k.Sifre))
            {
                return dll.SitemKOntrol(new Kullanici { KullaniciAdi = k.KullaniciAdi, Sifre = k.Sifre });
            }
            else
            {
                return -1;
            }
        }


    }
}
