using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ReservationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Garland", "Mammie", "Bruno", "Eleni", "Sang", "Delmar", "Odilia", "Latrisha", "Jovan", "Johanna", "Marc", "April", "Ethyl", "Micaela", "Kittie", "Wynona", "Kamala", "Jodee", "Ricky", "Kali", "Cameron Waters", "Connie Rodriguez", "Leticia Holloway", "Emily Lawrence", "Ken Aguilar", "Willie Cross", "Dennis Murphy", "Gilberto Gregory", "Neal Barnett", "Mabel French", "Archie Holland", "Ernestine Ray", "Jack Brooks", "Tracy Sanchez", "Eloise Stevens", "Kate Reeves", "Bruce Hunt", "Thomas Parsons", "Hector Diaz", "Darin Mckinney", "Alanna Rowley", "Kadeem Richardson", "Elisha Allman", "Javan Jenkins", "Haley Blanchard", "Nyla Guevara", "Izaan Lowe", "Bilal Vickers", "Tyler-James Howells", "Izabel Knox", "Yusuf", "Giana", "Elena", "Chance", "Julio", "Kadence", "Madyson", "Sydney", "Aditya", "Arely", "Holly", "Lance", "Leah", "Kaitlynn", "Abbie", "Tyler", "Melina", "Kasey", "Rylee", "Mallory", "Mark", "Deshawn", "Reginald", "Hamza"
        };

        private static readonly string[] Phones = new []
        {
          "(08) 8910 7607", "(02) 6176 8195", "(03) 5357 0998", "(02) 6105 0607", "(02) 6794 1148", "(02) 4913 6370", "(02) 6153 4432", "(02) 6176 2888", "(03) 6211 7396", "(02) 4626 2264", "(03) 5323 4663", "(03) 5397 5443", "(07) 4038 8073", "(08) 8786 0914", "(08) 9442 2234", "(03) 9694 9758", "(02) 6759 2221", "(03) 5355 3499", "(03) 5398 3038", "(08) 8795 2031", "(02) 4911 5841", "(02) 4919 0442", "(02) 4056 6931", "(08) 9096 6389", "(08) 8795 3906", "(07) 5359 2239", "(02) 6171 6584", "(03) 5384 5969", "(08) 8744 1910", "(03) 5368 4132", "(03) 5370 2283", "(02) 6726 1802", "(07) 5384 4471", "(08) 9040 4013", "(02) 9280 6331", "(07) 5634 8795", "(08) 8794 8265", "(03) 5312 4055", "(08) 9059 1132", "(02) 4970 0905", "(02) 4985 6601", "(02) 4071 2303", "(02) 6107 9274", "(03) 6257 4776", "(08) 8229 1379", "(02) 9021 0452", "(07) 3087 2944", "(02) 6647 6749", "(03) 5375 6896", "(03) 5314 2256", "(02) 4066 9900", "(08) 8731 1810", "(07) 4505 7507", "(08) 8308 9749", "(02) 4994 0580", "(02) 4988 4090", "(02) 6256 7375", "(02) 4013 0152", "(03) 6226 9269", "(03) 5350 5417"
        };

        private static List<Reservation> _database = null;

        private static IEnumerable<Reservation> DataBase() {
          if (_database == null)
          {
            var rng = new Random();
            _database = Enumerable.Range(1, 100).Select(index => new Reservation
            {
                Date = DateTime.Now.AddDays(index % 7).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                Time = rng.Next(5, 9),
                NoOfPeople = rng.Next(2,12),
                Name = Names[rng.Next(Names.Length)],
                PhoneNumber = Phones[rng.Next(Phones.Length)]
            }).ToList<Reservation>();
          }

          return _database;
        }

        private readonly ILogger<ReservationController> _logger;

        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        // [System.Web.Http.Cors.EnableCors("MyPolicy")]
        [HttpGet]
        // [Route("[controller]/{search}")]
        public IEnumerable<Reservation> Get() //(string search = null)
        {
          var search = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("s");

          if (search == null)
          {
            return DataBase();
          }

          Trace.WriteLine($"Search: {search}");

          return DataBase().Where(reservation => reservation.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
