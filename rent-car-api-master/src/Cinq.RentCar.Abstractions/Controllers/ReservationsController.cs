using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Cinq.RentCar.Abstractions.Repositories;
using Newtonsoft.Json.Serialization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinq.RentCar.Abstractions.Controllers
{
    [Route("reservations")]
    public class ReservationsController : Controller
    {
        public string Get()
        {
            // aqui o ideal seria por uma validação de null ou de serialização, não necessário para critérios do teste

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            string json = JsonConvert.SerializeObject(new Repository().GetReservations(), Formatting.Indented, jsonSerializerSettings);

            return json;
        }
    }
}
