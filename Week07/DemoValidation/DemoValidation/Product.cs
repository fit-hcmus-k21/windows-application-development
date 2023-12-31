﻿using System;
using System.Collections.Generic;

namespace DemoValidation;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
