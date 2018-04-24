using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace randomnumberASPAPI.Controllers
{
    [Route("api/v1.0/randomnumber")]
    [Route("api/v1.0/random")]
    public class RandomNumberController : Controller
    {
        /// <summary>
        /// Generate random numbres
        /// </summary>
        /// <param name="min">the minimum value (default is 0)</param>
        /// <param name="max">the maximum value (default is 100)</param>
        /// <param name="count">the number of random numbers to generate (default is 1)</param>
        /// <returns>json of random numbers</returns>
        [HttpGet]
        public IEnumerable<int> Get([FromQuery]int min, [FromQuery]int max, [FromQuery]int count )
        {
            //set defaults if not provided
            if (max == 0)
                max = 100;
            if (count == 0)
                count = 1;
            if (count > 100)
                count = 100;

            //generate random numbers
            int[] numbers = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
                numbers[i] = rnd.Next(min, max + 1);

            return numbers;
        }
    }
}
