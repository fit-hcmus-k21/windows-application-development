using System;
using System.Collections.Generic;

namespace DemoValidation;

public partial class Category
{
    public Category()
    {
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
