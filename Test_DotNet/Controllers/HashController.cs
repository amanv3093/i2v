using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Test_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        [HttpGet("{firstName}")]
        public IActionResult GetHash(string firstName)
        {
            // Convert the input string to bytes using UTF-8 encoding
            byte[] inputBytes = Encoding.UTF8.GetBytes(firstName);

            // Compute the SHA256 hash
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);

                // Convert the byte array to a lowercase hexadecimal string
                string hashString = ByteArrayToHexString(hashedBytes);

                // Return the hash string as JSON
                return Ok(new HashResponse { Hash = hashString });
            }
        }

        private string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }

    public class HashResponse
    {
        public string Hash { get; set; }
    }
}
