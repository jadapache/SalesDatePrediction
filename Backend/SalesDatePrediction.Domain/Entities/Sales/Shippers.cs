using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities.Sales;

public partial class Shippers
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; }

    public string Phone { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}