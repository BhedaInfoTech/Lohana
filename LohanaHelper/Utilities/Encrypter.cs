﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LohanaHelper.Utilities
{
   public class Encrypter
    {
        private static readonly ICryptoTransform _encrypter;

        private static readonly ICryptoTransform _decrypter;

        private static string _prefix;

       public static string Encrypt(string value)
       {

           string EncryptionKey = "MAKV2SPBNI99212";
           byte[] clearBytes = Encoding.Unicode.GetBytes(value);
           using (Aes encryptor = Aes.Create())
           {
               Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
               encryptor.Key = pdb.GetBytes(32);
               encryptor.IV = pdb.GetBytes(16);
               using (MemoryStream ms = new MemoryStream())
               {
                   using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                   {
                       cs.Write(clearBytes, 0, clearBytes.Length);
                       cs.Close();
                   }
                   value = Convert.ToBase64String(ms.ToArray());
               }
           }
           return value;

       }

       public static string Decrypt(string value)
       {
           string EncryptionKey = "MAKV2SPBNI99212";
           value = value.Replace(" ", "+");
           byte[] cipherBytes = Convert.FromBase64String(value);
           using (Aes encryptor = Aes.Create())
           {
               Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
               encryptor.Key = pdb.GetBytes(32);
               encryptor.IV = pdb.GetBytes(16);
               using (MemoryStream ms = new MemoryStream())
               {
                   using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                   {
                       cs.Write(cipherBytes, 0, cipherBytes.Length);
                       cs.Close();
                   }
                   value = Encoding.Unicode.GetString(ms.ToArray());
               }
           }
           return value;
       }
   }
}
