using Cinq.RentCar.Abstractions.Models;

namespace Cinq.RentCar.Abstractions.Repositories
{
    public interface IRentRepository
    {
        ICar[] GetAvailableCars();
        void Book(IBook rent);
        IBook[] GetReservations();
        IBook FindReservation(string bookReferenceNumber);
        void CancelReservation(string bookReferenceNumber);
    }
}
