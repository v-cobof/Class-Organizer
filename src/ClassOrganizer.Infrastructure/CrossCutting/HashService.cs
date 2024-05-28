using ClassOrganizer.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Infrastructure.CrossCutting
{
    public class HashService : IHashingService
    {
        public string CriarHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));

                string base64Hash = Convert.ToBase64String(hashBytes);

                return base64Hash;
            }
        }
    }
}
