using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace randomnumberASPAPI.Controllers
{
    [Route("api/v1.0/randomuuid")]
    [Route("api/v1.0/uuid")]
    public class UUIDController : Controller
    {
        /// <summary>
        /// Get random UUIDS
        /// </summary>
        /// <param name="count">the number of UUID's to generate (default is 1)</param>
        /// <returns>JSON of UUID's</returns>
        [HttpGet]
        public IEnumerable<string> Get([FromQuery]int count )
        {
            //set defaults if not provides
            if (count == 0)
                count = 1;
            if (count > 100)
                count = 100;

            //generate UUID's
            string[] uuids = new string[count];

            for (int i = 0; i < count; i++)
                uuids[i] = System.Guid.NewGuid().ToString();

            return uuids;
        }
    }
}
