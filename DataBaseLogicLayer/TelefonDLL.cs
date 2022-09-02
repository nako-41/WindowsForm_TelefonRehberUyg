using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLogicLayer
{
    public class TelefonDLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader read;

        public TelefonDLL()
        {
            con = new SqlConnection("Server=.;Database=TelefonRehberi;Trusted_Connection=True;");
        }
        public void BaglantiAyarla()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
                con.Close();
        }

        public int SitemKOntrol(Kullanici k)
        {
            int result = 0;
            try
            {
                cmd = new SqlCommand("Select count(*) from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre",con);
                BaglantiAyarla();
                cmd.Parameters.Add("@KullaniciAdi",SqlDbType.VarChar).Value=k.KullaniciAdi;
                cmd.Parameters.Add("@Sifre", SqlDbType.VarChar).Value=k.Sifre;
                result =(int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
           
                
            }finally
            {
                BaglantiAyarla();
            }
            return result;
        }

        public int KayitEkle(Rehber rehber)
        {
            int result = 0;
            try
            {
                cmd = new SqlCommand("INSERT INTO Rehber (Isim,Soyisim,TelefonNumarasi,EmailAdres,WebAdres,Adres,Aciklama) VALUES(@Isim,@Soyisim,@TelefonNumarasi,@EmailAdres,@WebAdres,@Adres,@Aciklama)", con);
                cmd.Parameters.Add("@Isim", SqlDbType.VarChar).Value = rehber.Isim.ToUpper();
                cmd.Parameters.Add("@Soyisim", SqlDbType.VarChar).Value = rehber.Soyisim.ToUpper();
                cmd.Parameters.Add("@TelefonNumarasi", SqlDbType.VarChar).Value = rehber.TelefonNumarasi;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.VarChar).Value = rehber.EmailAdres.ToUpper();
                cmd.Parameters.Add("@WebAdres", SqlDbType.VarChar).Value = rehber.WebAdres.ToUpper();
                cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = rehber.Adres.ToUpper();
                cmd.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = rehber.Aciklama.ToUpper();
                BaglantiAyarla();  

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                BaglantiAyarla(); 
            }

            return result;
        }

        public int KayitDuzenle(Rehber rehber)
        {
            int result = 0;
            try
            {
                cmd = new SqlCommand(
                    @"UPDATE Rehber SET  Isim=@Isim,Soyisim=@Soyisim,TelefonNumarasi=@TelefonNumarasi,EmailAdres=@EmailAdres,WebAdres=@WebAdres,Adres=@Adres,Aciklama=@Aciklama where ID=@ID" , con
                    );
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = rehber.ID;
                cmd.Parameters.Add("@Isim", SqlDbType.VarChar).Value = rehber.Isim;
                cmd.Parameters.Add("@Soyisim", SqlDbType.VarChar).Value = rehber.Soyisim;
                cmd.Parameters.Add("@TelefonNumarasi", SqlDbType.VarChar).Value = rehber.TelefonNumarasi;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.VarChar).Value = rehber.EmailAdres;
                cmd.Parameters.Add("@WebAdres", SqlDbType.VarChar).Value = rehber.WebAdres;
                cmd.Parameters.Add("@Adres", SqlDbType.VarChar).Value = rehber.Adres;
                cmd.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = rehber.Aciklama;
                BaglantiAyarla();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
               
                
            }
            finally
            {
                BaglantiAyarla();
            }
               return result;
        }
        
        public int KayitSil(int ID)
        {
            int result = 0;
            try
            {
                cmd = new SqlCommand(
                     @"DELETE FROM where ID=@ID", con
                     );
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;
                BaglantiAyarla();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                BaglantiAyarla();
            }
            return result;
        }
        public SqlDataReader KayitListe()
        {
            cmd = new SqlCommand("select ID,Isim,Soyisim,TelefonNumarasi,EmailAdres,WebAdres,Adres,Aciklama from Rehber", con);
            BaglantiAyarla();
           return cmd.ExecuteReader();

        }
        public SqlDataReader KayitListeId(int ID)
        {
            cmd = new SqlCommand("SELECT * FROM Rehber where ID=@ID", con);
            cmd.Parameters.Add("@ID",SqlDbType.Int).Value=ID;
            BaglantiAyarla();
            return cmd.ExecuteReader();

        }

    }
}
