using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


        public static bool VerifyPasswordHash(string password,byte[] PasswordHash,byte[] PasswordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i <computedHash.Length; i++)
                {
                    if (computedHash[i]!=PasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
                    

            }
        }
    }
}
