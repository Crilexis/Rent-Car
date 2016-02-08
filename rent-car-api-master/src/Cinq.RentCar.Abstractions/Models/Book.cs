using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinq.RentCar.Abstractions.Models
{
    public class Book : IBook
    {
        public string BookReference { get; set; }
        public DateTime DropoffDate { get; set; }
        public bool HasAgeExtraFee { get; set; }
        public DateTime PickupDate { get; set; }

        // dizendo para o deserializador para qual tipo ele deve converter
        [JsonConverter(typeof(TypeConverter<Car>))]
        public ICar Car { get; set; }

        // dizendo para o deserializador para qual tipo ele deve converter
        [JsonConverter(typeof(TypeConverter<Driver>))]
        public IDriver Driver { get; set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2}", BookReference, Driver.ToString(), Car.ToString());
        }
    }

    // ajustando um bug que o Json.net tem em deserializar objetos com interfaces
    // fonte: http://blog.greatrexpectations.com/2012/08/30/deserializing-interface-properties-using-json-net/
    public class TypeConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //assume we can convert to anything for now
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //explicitly specify the concrete type we want to create
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //use the default serialization - it works fine
            serializer.Serialize(writer, value);
        }
    }
}
