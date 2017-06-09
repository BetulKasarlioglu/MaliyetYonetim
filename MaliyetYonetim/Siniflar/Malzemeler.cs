using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetYonetim.Siniflar
{
    class Malzemeler : Araclar, CRUD
    {
        public ModelMalzeme mmalzemeler;
        public bool Ekle()
        {
            cmd = new SqlCommand("insert into MALZEME(MalzemeAdi,BirimFiyat,Aciklama,TurCinsId,Adet,Birim) values(@MalzemeAd,@BirimFiyat,@Aciklama,(Select TurCinsId from TurCins where TurID=@turid and CinsId=@cinsid),@adet,@birim)", baglan);
            cmd.Parameters.AddWithValue("@MalzemeAd", mmalzemeler.MalzemeAd);
            cmd.Parameters.AddWithValue("@BirimFiyat", mmalzemeler.BirimFiyat);
            cmd.Parameters.AddWithValue("@Aciklama", mmalzemeler.Aciklama);
            cmd.Parameters.AddWithValue("@turid",mmalzemeler.TurId);
            cmd.Parameters.AddWithValue("@cinsid", mmalzemeler.CinsId);
            cmd.Parameters.AddWithValue("@adet", mmalzemeler.Adet);
            cmd.Parameters.AddWithValue("@Birim", mmalzemeler.Birim);
            //cmd.ExecuteNonQuery();
            return cmdCalistir();
        }

        public bool Guncelle()
        {
            cmd = new SqlCommand("UPDATE MALZEME SET MalzemeAdi=@MalzemeAd,BirimFiyat=@BirimFiyat,Aciklama=@Aciklama,Adet=@Adet,Birim=@Birim WHERE MalzemeID=@MalzemeID", baglan);
            cmd.Parameters.AddWithValue("@MalzemeAd", mmalzemeler.MalzemeAd);
            cmd.Parameters.AddWithValue("@BirimFiyat", mmalzemeler.BirimFiyat);
            cmd.Parameters.AddWithValue("@Aciklama", mmalzemeler.Aciklama);
            cmd.Parameters.AddWithValue("@Adet", mmalzemeler.Adet);
            cmd.Parameters.AddWithValue("@Birim", mmalzemeler.Birim);
           // cmd.ExecuteNonQuery();
            return cmdCalistir();
        }

        public bool Sil()
        {
            cmd = new SqlCommand("DELETE FROM MALZEME WHERE MalzemeID=@MalzemeID", baglan);
            cmd.Parameters.AddWithValue("@MalzemeID", mmalzemeler.MalzemeID);
            //cmd.ExecuteNonQuery();
            return cmdCalistir();
        }
    }
}
