using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Helpers
{
    public class Crypto
    {


        public static int GenerateHashCode(int hashValue)
        {
            unchecked // desabilita checagem de overflow de inteiros
            {
                int hash = (int)2166136261; // numero primo arbitrario para iniciar o hash
                hash = (hash * 16777619) ^ hashValue; // heuristica de Bob Jenskins para gerar hash
                return hash;
            }
        }

        public static byte[] Encrypt(string data, byte[] key) // AES Algorithm
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public static string GenerateAccessToken(string userInfo)
        {
            Enumerators.RandomKeys keyEnum = (Enumerators.RandomKeys)new Random().Next(1, 5); // busca uma palavra aleatória para ser a chave de criptografia
            byte[] key = Encoding.UTF8.GetBytes(keyEnum.ToString());
            string tokenPt1 = Encoding.UTF8.GetString(Encrypt(userInfo, key));
            string tokenPt2 = GenerateHashCode(DateTime.Now.GetHashCode()).ToString();

            return tokenPt1 + "-" + tokenPt2;
        }
    }

}