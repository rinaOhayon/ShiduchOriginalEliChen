using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace Schiduch.CRC
{
    class CRCP
    {
        public enum PremiumStatus {FirstTime,OK}
        public static PremiumStatus CheckIsPremium()
        {
            PremiumStatus ret;
            int userId = GLOBALVARS.MyUser.ID;
            SqlDataReader reader= DBFunction.ExecuteReader("SELECT lastpay,crc FROM USERS INNER JOIN CC on CC.userid=USERS.id WHERE USERS.id=" + userId.ToString());
            if (reader.Read())
            {
                if (reader.IsDBNull(1))
                    ret= PremiumStatus.FirstTime;
                else ret= PremiumStatus.OK; 
            }
            else ret= PremiumStatus.FirstTime;
            reader.Close();
            DBFunction.CloseConnections();
            return ret;

        }
        public void SaveCC(string crc,string name,string month,string year,string cvw,bool is90)
        {
            name = Encrypt.EncryptString(name, "pemgail4dX9uzpgzl88");
            crc = Encrypt.EncryptString(crc, "pemgail4dX9uzpgzl88");
            month = Encrypt.EncryptString(month, "pemgail4dX9uzpgzl88");
            year = Encrypt.EncryptString(year, "pemgail4dX9uzpgzl88");
            cvw = Encrypt.EncryptString(cvw, "pemgail4dX9uzpgzl88");
            int price = 0;
            if (!is90) price = 1;
            string sql = "Insert Into CC(crc,name,month,year,cvw,userid,pay_type) Values('" + crc + "','" + name + "','" + month + "','" + year + "','" + cvw +
                "'," + GLOBALVARS.MyUser.ID + "," + price + ")";

            DBFunction.Execute(sql);

            string sql2 = "update users set control=6 where id=" + GLOBALVARS.MyUser.ID;
            DBFunction.Execute(sql2);
        }
    }

    public static class Encrypt
    {
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "pemgail9uzpgzl88";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //Encrypt
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

    }
}
