using System;

namespace Cinq.RentCar.Abstractions.Models
{
    public interface IBook
    {
        string BookReference { get; set; }
        DateTime PickupDate { get; set; }
        DateTime DropoffDate { get; set; }
        ICar Car { get; set; }
        IDriver Driver { get; set; }
        bool HasAgeExtraFee { get; set; }
    }
}
