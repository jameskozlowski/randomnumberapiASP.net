using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace randomnumberASPAPI.Controllers
{
    [Route("api/v1.0/randomstring")]
    [Route("api/v1.0/string")]
    public class RandomStringController : Controller
    {

        /// <summary>
        /// Generate Random Strings
        /// </summary>
        /// <param name="min">the minimum length of each string (default is 10)</param>
        /// <param name="max">the maximum length of each string (default is 20)</param>
        /// <param name="count">the number of strings to generate (default is 1)</param>
        /// <returns>json of strings</returns>
        [HttpGet]
        public IEnumerable<string> Get([FromQuery]int min, [FromQuery]int max, [FromQuery]int count )
        {
            //Set defaults if not provided
            if (min <= 0)
                min = 10;
            if (max <= 0)
                max = 20;
            if (max > 100)
                max = 100;
            if (count == 0)
                count = 1;
            if (count > 100)
                count = 100;

            //generate strings
            string[] strings = new string[count];
            Random rnd = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < count; i++)
            {
                int length = rnd.Next(min, max + 1);
                strings[i] = new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
            }

            return strings;
        }
    }
}
