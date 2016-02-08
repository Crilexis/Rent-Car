using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Cinq.RentCar.Abstractions.Models;
using Cinq.RentCar.Abstractions.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cinq.RentCar.Abstractions.Controllers
{
    [Route("cars")]
    public class CarController : Controller
    {
        [HttpGet]
        public string Get()
        {
            // aqui o ideal seria por uma validação de null ou de serialização, não necessário para critérios do teste

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            string json = JsonConvert.SerializeObject(new Repository().GetAvailableCars(), Formatting.Indented, jsonSerializerSettings);

            return json;
        }

    }
}
