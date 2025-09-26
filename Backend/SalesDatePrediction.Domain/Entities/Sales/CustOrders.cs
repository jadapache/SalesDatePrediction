using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities.Sales;


public partial class CustOrders
{
    public int? Custid { get; set; }

    public DateTime? Ordermonth { get; set; }

    public int? Qty { get; set; }
}