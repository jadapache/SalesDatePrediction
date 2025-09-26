using System;
using System.Collections.Generic;

namespace SalesDatePrediction.Domain.Entities.Production;

public partial class Categories
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}