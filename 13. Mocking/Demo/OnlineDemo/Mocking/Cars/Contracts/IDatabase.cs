namespace Cars.Contracts
{
    using System.Collections.Generic;

    using Cars.Models;

    internal interface IDatabase
    {
        IList<Car> Cars { get; set; }
    }
}