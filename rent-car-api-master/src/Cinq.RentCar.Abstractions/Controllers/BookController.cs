using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.Net;
using Newtonsoft.Json;
using Cinq.RentCar.Abstractions.Models;
using System.Net.Http;
using Cinq.RentCar.Abstractions.Repositories;
using System.Collections.Generic;

namespace Cinq.RentCar.Abstractions.Controllers
{
    [Route("book")]
    public class BookController : Controller
    {
        [HttpPost]
        public HttpResponseMessage Post(string value)
        {
            Repository repository = new Repository();

            // se nada for enviado no corpo do post, retorna 400
            if (string.IsNullOrEmpty(value))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            // parsing
            Book book = null;

            try
            {
                book = JsonConvert.DeserializeObject<Book>(value);
            }
            catch (Exception)
            {
                // adição minha, caso não consiga converter corretamente também envia um erro   
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            // caso o carro informado não existe, retorna 404
            ICar[] cars = new Repository().GetAvailableCars();
            if (!cars.Any(x => x.Category == book.Car.Category && x.Model == book.Car.Model && x.Year == book.Car.Year))
                return new HttpResponseMessage(HttpStatusCode.NotFound);

            // tudo certo, salvando o agendamento
            repository.Book(book);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete("{bookReferenceNumber}/cancel")]
        public HttpResponseMessage Delete(string bookReferenceNumber)
        {
            Repository repository = new Repository();

            // se não encontrar nenhuma reserva com o numero informado, retorna 400
            IBook book = repository.FindReservation(bookReferenceNumber);
            if (book == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            // cancelando e apagando do disco
            repository.CancelReservation(bookReferenceNumber);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
