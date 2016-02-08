using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinq.RentCar.Abstractions.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cinq.RentCar.Abstractions.Repositories
{
    /// <summary>
    /// Classe capaz de serializar e salvar, ou carregar e deserializar, em disco qualquer objeto com o uso de tipos genéricos
    /// O caminho para salvar poderia ser recebida via construtor, porém para este teste não achei necessário
    /// </summary>
    public class FakeDB
    {
        public T Load<T>()
        {
            // caminho local, apenas para testes
            string name = typeof(T).ToString().Substring(typeof(T).ToString().LastIndexOf('.') + 1).Replace("]", "").Replace("[", "");
            if (name.StartsWith("I"))
                name = name.Substring(1);

            string path = Path.Combine(Directory.GetCurrentDirectory(), name);

            if (!File.Exists(path))
                return default(T);

            // lendo e deserializando.
            // espera-se que tenha sido salvo corretamente
            string file = File.ReadAllText(path);
            T json = JsonConvert.DeserializeObject<T>(file);
            
            return json;
        }

        public void Save(object obj)
        {
            // caminho local, apenas para testes
            string name = obj.GetType().ToString().ToString().Substring(obj.GetType().ToString().ToString().LastIndexOf('.') + 1).Replace("]", "").Replace("[", "");
            if (name.StartsWith("I"))
                name = name.Substring(1);

            string path = Path.Combine(Directory.GetCurrentDirectory(), name);

            // serializando e salvando
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
        }
    }
}
