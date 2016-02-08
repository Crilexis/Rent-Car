namespace Cinq.RentCar.Abstractions.Models
{
    public interface IDriver
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }        
    }
}
