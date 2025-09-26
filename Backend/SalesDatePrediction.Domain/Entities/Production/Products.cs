using SalesDatePrediction.Domain.Entities.Sales;
using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities.Production;

public partial class Products
{
    public int Productid { get; set; }

    public string Productname { get; set; }

    public int Supplierid { get; set; }

    public int Categoryid { get; set; }

    public decimal Unitprice { get; set; }

    public bool Discontinued { get; set; }

    public virtual Categories Category { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public virtual Suppliers Supplier { get; set; }
}