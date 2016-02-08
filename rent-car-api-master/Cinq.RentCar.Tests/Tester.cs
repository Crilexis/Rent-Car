using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Cinq.RentCar.Abstractions.Controllers;
using Cinq.RentCar.Abstractions.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Cinq.RentCar.Tests
{
    public class Tester
    {
        [Fact]
        public void RequestCars()
        {
            CarController cc = new CarController();
            string result = cc.Get();

            try
            {
                Car[] cars = JsonConvert.DeserializeObject<Car[]>(result);

                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void RequestReservations()
        {
            ReservationsController rc = new ReservationsController();
            string result = rc.Get();

            try
            {
                Book[] books = JsonConvert.DeserializeObject<Book[]>(result);

                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void PostValidBooking()
        {
            BookController bc = new BookController();
            string dummyPost = "{bookReference: \"abc12\", car:{category: 0, model: 1, year: 2015}, driver:{age: 28, firstName: \"John\", lastName: \"Doe\"}, dropoffDate: \"2016-02-20T00:00:00-02:00\", hasAgeExtraFee: false, pickupDate: \"2016-02-07T00:00:00-02:00\"}";

            Assert.True(bc.Post(dummyPost).StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public void PostNullBooking()
        {
            BookController bc = new BookController();
            string dummyPost = "";

            Assert.True(bc.Post(dummyPost).StatusCode == HttpStatusCode.BadRequest);

            dummyPost = null;

            Assert.True(bc.Post(dummyPost).StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void PostInvalidCarBooking()
        {
            BookController bc = new BookController();
            string dummyPost = "{bookReference: \"abc12\", car:{category: 1, model: 1, year: 2012}, driver:{age: 28, firstName: \"John\", lastName: \"Doe\"}, dropoffDate: \"2016-02-20T00:00:00-02:00\", hasAgeExtraFee: false, pickupDate: \"2016-02-07T00:00:00-02:00\"}";

            Assert.True(bc.Post(dummyPost).StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public void PostInvalidJsonBooking()
        {
            BookController bc = new BookController();
            string dummyPost = "{bookReference: \"abc12\", >>>> some random junk here <<<< car:{category: 1, model: 1, year: 2012},driver:{age: 28, firstName: \"John\", lastName: \"Doe\"}, dropoffDate: \"2016-02-20T00:00:00-02:00\", hasAgeExtraFee: false, pickupDate: \"2016-02-07T00:00:00-02:00\"}";

            Assert.True(bc.Post(dummyPost).StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void DeleteValidBooking()
        {
            // inserindo um registro válido para após apagar

            BookController bc = new BookController();
            string dummyPost = "{bookReference: \"abc12\", car:{category: 0, model: 1, year: 2015}, driver:{age: 28, firstName: \"John\", lastName: \"Doe\"}, dropoffDate: \"2016-02-20T00:00:00-02:00\", hasAgeExtraFee: false, pickupDate: \"2016-02-07T00:00:00-02:00\"}";
            bc.Post(dummyPost);

            Assert.True(bc.Delete("abc12").StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public void DeleteInvalidBooking()
        {
            BookController bc = new BookController();
            Assert.True(bc.Delete("randomnumberreferencethatprobablydontexist").StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
