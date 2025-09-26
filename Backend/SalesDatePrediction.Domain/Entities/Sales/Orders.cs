using SalesDatePrediction.Domain.Entities.HR;
using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities.Sales;

public partial class Orders
{
    public int Orderid { get; set; }

    public int? Custid { get; set; }

    public int Empid { get; set; }

    public DateTime Orderdate { get; set; }

    public DateTime Requireddate { get; set; }

    public DateTime? Shippeddate { get; set; }

    public int Shipperid { get; set; }

    public decimal Freight { get; set; }

    public string Shipname { get; set; }

    public string Shipaddress { get; set; }

    public string Shipcity { get; set; }

    public string Shipregion { get; set; }

    public string Shippostalcode { get; set; }

    public string Shipcountry { get; set; }

    public virtual Customers Cust { get; set; }

    public virtual Employees Emp { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public virtual Shippers Shipper { get; set; }
}