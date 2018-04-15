using System;
using System.Security.Cryptography;
using System.Text;
using GestaoJogos.Domain.Services;
using GestaoJogos.Domain.ValuesObjects;
using Newtonsoft.Json;

namespace GestaoJogos.Infra.Security
{
    public class SecurityService : ISecurityService
    {
        private const string PrivateKey = "34df6299-05f9-4a94-b8ab-d059c90aa0c0";


        public string CreateToken(string user, string pass)
        {
            var userRequest = new UserRequestToken
            {
                User = user,
                Password = pass,
                DateAndHourValid = DateTime.Now.AddHours(24),
                PrivateKey = PrivateKey
            };

            var userJson = JsonConvert.SerializeObject(userRequest);

            return Encrypt(userJson);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var typeToken = token.Substring(0, 7);

                if (!typeToken.ToLower().Equals("bearer "))
                    return false;

                var onlyToken = token.Substring(7);
                var userJson = Decrypt(onlyToken);
                var userRequest = JsonConvert.DeserializeObject<UserRequestToken>(userJson);

                return userRequest.DateAndHourValid >= DateTime.Now && userRequest.PrivateKey == PrivateKey;
            }
            catch
            {
                return false;
            }
        }


        private static string Encrypt(string userJson)
        {
            var desCryptoProvider = new TripleDESCryptoServiceProvider();
            var hashMd5Provider = new MD5CryptoServiceProvider();

            var byteHash = hashMd5Provider.ComputeHash(Encoding.UTF8.GetBytes(PrivateKey));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB;
            var byteBuff = Encoding.UTF8.GetBytes(userJson);

            return Convert.ToBase64String(desCryptoProvider.CreateEncryptor()
                .TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }

        private static string Decrypt(string token)
        {
            var desCryptoProvider = new TripleDESCryptoServiceProvider();
            var hashMd5Provider = new MD5CryptoServiceProvider();

            var byteHash = hashMd5Provider.ComputeHash(Encoding.UTF8.GetBytes(PrivateKey));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB;
            var byteBuff = Convert.FromBase64String(token);

            return Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor()
                .TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
    }
}
