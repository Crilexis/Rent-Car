namespace Cinq.RentCar.Abstractions.Models
{
    public interface ICar
    {
        int Year { get; set; }
        EnumModel Model { get; set; }
        EnumCategory Category { get; set; }
    }
}
