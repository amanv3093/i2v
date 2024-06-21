using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            using (var hash = SHA256.Create())
            {
                byte[] hashedBytes = hash.ComputeHash(inputBytes);
                
                // Return a HashResponse Object which contains the hashString (alphanumeric, without '-') converted from hashedBytes
                var response = new HashResponse
                {
                    Hash = hashedBytes
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
