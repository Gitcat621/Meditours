using System.Text.Unicode;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Meditours.Models
{
    public class EncryptMD5
    {
        public string Encrypt(string password)
        {
            string hash = "viendo esto";
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);
        }

        public string Descrypt(string passwordEn)
        {
            string hash = "viendo esto";
            byte[] data = Convert.FromBase64String(passwordEn);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Encoding.UTF8.GetString(result);
        }
    }
}
