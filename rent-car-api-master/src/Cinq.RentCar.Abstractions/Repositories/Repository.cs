using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Repositories
{
    public class Repository : IRentRepository
    {
        public void Book(IBook rent)
        {
            // nosso amigo, o banco falso
            FakeDB faker = new FakeDB();
            List<IBook> booksToSave;

            // adicionando a nova reserva. Se for a primeira cria do zero.
            IBook[] books = GetReservations();
            if (books == null)
                booksToSave = new List<IBook>();
            else
                booksToSave = books.ToList();

            // impedindo duplicidade e escrevendo em disco
            if (!booksToSave.Any(x => x.BookReference == rent.BookReference))
            {
                booksToSave.Add(rent);

                faker.Save(booksToSave);
            }
        }

        public void CancelReservation(string bookReferenceNumber)
        {
            // removi as verificações de nulos, pois já são feitos em outra função;
            // idealmente não se deve fazer isso, mas para esse teste acredito que não será um problema

            FakeDB faker = new FakeDB();
            // ajustado após a solução abaixo não funcionar
            List<IBook> booksToSave = GetReservations().Where(x => x.BookReference != bookReferenceNumber).ToList();

            // estranhamente não funciona. deixei aqui a título de curiosidade
            //IBook book = FindReservation(bookReferenceNumber);
            //booksToSave.Remove(book);

            faker.Save(booksToSave);
        }

        public IBook FindReservation(string bookReferenceNumber)
        {
            IBook[] books = GetReservations();
            return books.FirstOrDefault(x => x.BookReference == bookReferenceNumber);
        }

        // dados genéricos, poderia ser lido do disco
        public ICar[] GetAvailableCars()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car(EnumCategory.Economy, EnumModel.Sonic, 2015));
            cars.Add(new Car(EnumCategory.Regular, EnumModel.Fusion, 2014));
            cars.Add(new Car(EnumCategory.Sport, EnumModel.Camaro, 2015));

            return cars.ToArray();
        }

        // dados persistentes, salvos em disco atraves das interações anteriores do usuário com o sistema
        public IBook[] GetReservations()
        {
            FakeDB faker = new FakeDB();
            IBook[] books = faker.Load<Book[]>();

            return books;
        }
    }
}
