using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Test_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : Controller
    {
        [HttpGet("{firstName}")]
        public JsonResult GetHash(string firstName)
        {
            string input = firstName;
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            using (var hash = SHA256.Create())
            {
                byte[] hashedBytes = hash.ComputeHash(inputBytes);

                // Convert byte array to hexadecimal string
                var sb = new StringBuilder();
                foreach (var b in hashedBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                
                var response = new HashResponse
                {
                    Hash = sb.ToString()
                };

                return new JsonResult(response);
            }
        }
    }

    public class HashResponse
    {
        public string Hash { get; set; }
    }
}
