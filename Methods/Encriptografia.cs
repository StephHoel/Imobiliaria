using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Imobiliaria.Methods
{
    public class Encriptografia
    {
        public static string Encrypt(string text)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(text);
                using (DESCryptoServiceProvider des = new())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string Decrypt(string text)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[text.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(text.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new())
                {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }


        // static void Main()
        // {
        //     string encrypted = Encrypt("WaterWorld");
        //     Console.WriteLine("Encriptografado: " + encrypted);

        //     Console.WriteLine();

        //     string decrypted = Decrypt(encrypted);
        //     Console.WriteLine("Descriptografado: " + decrypted);
        // }
    }
}