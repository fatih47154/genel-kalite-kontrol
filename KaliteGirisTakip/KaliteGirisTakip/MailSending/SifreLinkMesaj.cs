﻿using KaliteGiris.Helper;
using KaliteGiris.Entities;

namespace MailSending
{
    public   class SifreLinkMesaj
    {
    public   string SifreLinkGovdesi(Personel personel)
        {
          string veri = CriptografiaHelper.EncryptQueryString(personel.PersonelId.ToString());
          string mesaj = "<div style = 'font-size: 12px; padding-left:20px;'>" +
                           "<strong> Sayın " + personel.Adi + " " + personel.Soyadi + " <strong> lab kayıtları değişti.İlgili programdan son durumu takip ediniz. <br>" +
                           "<strong>" + personel.Email + "</strong> adresine bağlı hesabınızın şifresi güncellenecektir." +

                           "<h6>Bu e - posta kişiye özel bilgi içermektedir. Eğer bu ileti size yanlışlıkla ulaştı ise işlem yapmadan siliniz. Lütfen şifrenizi kimseyle paylaşmayınız." +
                           "Program yoneticeleri dahil hiç kimse sizden kişisel bilgi istemez, şifrenizi sormaz. Sizden kişisel bilgilerinizi veya Kullanici Şifrenizi telefon, e - posta v.b.yollar ile isteyen kişilere karşı dikkatli olunuz, bilgilerinizi vermeyiniz.</h6> </div>";
            return mesaj;
        }
    }
}
