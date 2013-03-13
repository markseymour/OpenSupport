using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.DataAccess.Tools
{
    public class PasswordHash
    {
        public const int SaltBytes = 24;
        public const int HashBytes = 24;
        public const int Iterrations = 1000;

        public const int IterrationIndex = 0;
        public const int SaltIndex = 1;
        public const int Pbkdf2Index = 2;

        public static string CreateHash(string password)
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltBytes];
            csprng.GetBytes(salt);

            var hash = PBKDF2(password, salt, Iterrations, HashBytes);
            
            return Iterrations + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string goodHash)
        {
            char[] delimiter = { ':' };
            var split = goodHash.Split(delimiter);
            var iterrations = Int32.Parse(split[IterrationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = PBKDF2(password, salt, iterrations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] hash, byte[] testHash)
        {
            var diff = (uint)hash.Length ^ (uint)testHash.Length;
            for (var i = 0; i < hash.Length && i < testHash.Length; i++)
                diff |= (uint)(hash[i] ^ testHash[i]);

            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterrations, int hashBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterrations;
            return pbkdf2.GetBytes(hashBytes);
        }
    }
}
