using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSending
{
  public  class HtmlMesaj
  {


        static string SutunEkle(string deger, int font, string width, string alingment)
        {
            StringBuilder tdBuilder = new StringBuilder();

            tdBuilder.Append("<td style='vertical-align: top; width:" + width + "; text-align:"+alingment+ "; color: #000000;'>");
            tdBuilder.Append("<h" + font);
            tdBuilder.Append(" style='font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-weight: bold;'>");
            tdBuilder.Append(deger);
            tdBuilder.Append("</h" + font + ">");
            tdBuilder.Append("</td>");
            return tdBuilder.ToString();
        }

        static string SutunEkle(string deger, int font, string alingment)
        {
            StringBuilder tdBuilder = new StringBuilder();
            tdBuilder.Append("<td style='vertical-align: top; text-align:" + alingment + "; color: #000000;'>");
            tdBuilder.Append("<h" + font);
            tdBuilder.Append(" style='font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-weight: bold;'>");
            tdBuilder.Append(deger);
            tdBuilder.Append("</h" + font + ">");
            tdBuilder.Append("</td>");
            return tdBuilder.ToString();
        }




        static string SatirEkle(int font, int width, Satir satir)
        {
            StringBuilder mesaj = new StringBuilder();
            try
            {
                mesaj.Append("<tr>");          
                mesaj.Append(SutunEkle(satir.Baslik, font, "150px","Right"));
                mesaj.Append(SutunEkle(":", font, "10","Center"));
                mesaj.Append(SutunEkle(satir.Icerik, font, "500","Left"));             
                mesaj.Append("</tr>");
            }
            catch (Exception ex)
            {
              //  Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }

            return mesaj.ToString();
        }



      public string HtmlTabloIcerigiOlustur(string baslik,int genislik,  params Satir[] satirlar )
      {
       StringBuilder mesaj=new StringBuilder();

           mesaj.Append("<body> <table cellspacing='0' cellpadding='0' style='border-style: solid; border-width: 1px; border-color: #000000; height:150px; width:" + genislik.ToString()+"px;'>");
           mesaj.Append("<tr><td style='text-align: center; padding-top:10px ; vertical-align: middle; color: #000000;' colspan='3'>");
           mesaj.Append("<h3 style='font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-weight: bold;'>"+baslik+"</h3></td></tr>");

          foreach (var satir in satirlar)
          {
                mesaj.Append(SatirEkle(4, genislik, satir));
          }

           mesaj.Append("</table></body>");
           return mesaj.ToString();
      }

        public string HtmlTabloIcerigiOlustur(string baslik, int genislik, string icerik)
        {
            StringBuilder mesaj = new StringBuilder();

            mesaj.Append("<body> <table cellspacing='0' cellpadding='0' style='border-style: solid; border-width: 1px; border-color: #000000; height:150px; width:" + genislik.ToString() + "px;'>");
            mesaj.Append("<tr><td style='text-align: center; padding-top:10px ; vertical-align: middle; color: #000000;' colspan='1'>");
            mesaj.Append("<h3 style='font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif; font-weight: bold;'>" + baslik + "</h3></td></tr>");
            mesaj.Append(SatirEkle(5, 650, icerik));
            mesaj.Append("</table></body>");
            return mesaj.ToString();
        }



        static string SatirEkle(int font, int width, string icerik)
        {
            StringBuilder mesaj = new StringBuilder();
            try
            {
                mesaj.Append("<tr>");
                mesaj.Append(SutunEkle(icerik, font, "650", "Left"));
                mesaj.Append("</tr>");
            }
            catch (Exception ex)
            {
                //Log4NetLibrary.HataDataBaseLog.LogStart.Error(Log4NetLibrary.GetMethodProperties.GetMethodFullName(), ex);
            }

            return mesaj.ToString();
        }
    }
}
