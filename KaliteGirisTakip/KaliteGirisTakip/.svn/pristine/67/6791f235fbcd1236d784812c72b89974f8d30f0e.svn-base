using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KaliteGiris.Helper
{
    public class CryptorEngine
    {
        //////public static string Encrypt(string plainText)
        //////{
        //////    //  string key = "@m2qJzeyjXLBK!axPV$Bvg3QUP";
        //////    // //string key = "@m2qJzeyjXLBK!axPV$Bvg3QUP";
        //////    // byte[] EncryptKey = { };
        //////    // byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
        //////    // EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
        //////    // //AesCryptoServiceProvider des=new AesCryptoServiceProvider();
        //////    //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //////    // byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
        //////    // MemoryStream mStream = new MemoryStream();
        //////    // CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
        //////    // cStream.Write(inputByte, 0, inputByte.Length);
        //////    // cStream.FlushFinalBlock();
        //////    // return Convert.ToBase64String(mStream.ToArray());
        //////    string EncryptionKey = "1250";//"V2SPBNI99212";
        //////    //string EncryptionKey = "HayatSanaBanaGUZELOlsun";
        //////    byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
        //////    using (Aes encryptor = Aes.Create())
        //////    {
        //////        encryptor.Mode = CipherMode.CFB;
        //////        // Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //////        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //////        encryptor.Key = pdb.GetBytes(32);
        //////        encryptor.IV = pdb.GetBytes(16);
        //////        using (MemoryStream ms = new MemoryStream())
        //////        {
        //////            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //////            {
        //////                cs.Write(clearBytes, 0, clearBytes.Length);
        //////                cs.Close();
        //////            }
        //////            plainText = Convert.ToBase64String(ms.ToArray());
        //////        }
        //////    }
        //////    return plainText;
        //////}
        //////public static string Decrypt(string encryptedText)
        ////// {
        //////     //  string key = "@m2qJzeyjXLBK!axPV$Bvg3QUP";
        //////     //// string key = "123456789abcdefgh";        
        //////     //byte[] DecryptKey = { };
        //////     //byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
        //////     //byte[] inputByte = new byte[encryptedText.Length];
        //////     //DecryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
        //////     ////AesCryptoServiceProvider des = new AesCryptoServiceProvider();
        //////     //DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        //////     //inputByte = Convert.FromBase64String(encryptedText);
        //////     //MemoryStream ms = new MemoryStream();
        //////     //CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(DecryptKey, IV), CryptoStreamMode.Write);
        //////     //cs.Write(inputByte, 0, inputByte.Length);
        //////     //cs.FlushFinalBlock();
        //////     //System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        //////     //return encoding.GetString(ms.ToArray());
        //////    string EncryptionKey = "1250";//"V2SPBNI99212";
        //////    // string EncryptionKey = "HayatSanaBanaGUZELOlsun";
        //////     encryptedText = encryptedText.Replace(" ", "+");
        //////     byte[] cipherBytes = Convert.FromBase64String(encryptedText);
        //////     using (Aes encryptor = Aes.Create())
        //////     {
        //////         encryptor.Mode=CipherMode.CFB;
        //////         Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //////         encryptor.Key = pdb.GetBytes(32);
        //////         encryptor.IV = pdb.GetBytes(16);
        //////         using (MemoryStream ms = new MemoryStream())
        //////         {
        //////             using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //////             {
        //////                 cs.Write(cipherBytes, 0, cipherBytes.Length);
        //////                 cs.Close();
        //////             }
        //////             encryptedText = Encoding.Unicode.GetString(ms.ToArray());
        //////         }
        //////     }
        //////     return encryptedText;
        ////// }

        private const string AesIV = @"!QAZ2WSX#EDC4RFV";
        private static string AesKey = @"5TGBDYHN7UJM(IK<";
        public static string Decrypt(string _text)
        {
            //Bu kısmı bu sınıfa ben 
            string text = karakterReplace('_', '/', _text);
            text = karakterReplace('@', '+', text);


            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.Zeros;
            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);
            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }
        public static string Encrypt(string text)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;//blok blok şifreleme yapıldığı için
                                //nekadarlık bloklar halinde şifreleneceği tanımlanıyor.
            aes.KeySize = 128;//anahtar ile şifreleme yapılıyo.
                              //anahtar boyutları, 128-192 ve 256 olabilir.
            aes.IV = Encoding.UTF8.GetBytes(AesIV);
            aes.Key = Encoding.UTF8.GetBytes(AesKey);//anahtar bytea çevriliyor.
                                                     //Böylece evrensel olarak bütün dosya, resim, metin vs
                                                     //bytelara çevrilerek şifreleme yapılabilir.
            aes.Mode = CipherMode.CBC;//Şifreleme modu seçiliyo genelde cbc olur
            aes.Padding = PaddingMode.Zeros;
            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);//aynı şekilde
                                                         //metin de bytelara çevrilir
                                                         //şifreleme burda gerçekleşiyor
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                //bloklar alınır şifrelenir
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                // //daha sonra şifreli byte blokları stringe çevrilir.
                text = karakterReplace('/', '_', Convert.ToBase64String(dest));
                text = karakterReplace('+', '@', text);
                return text;
            }
        }

        static string karakterReplace(char oldChar, char newChar, string oldText)
        {
            return oldText.Replace(oldChar, newChar);
        }


    }
}
