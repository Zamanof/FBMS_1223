using System;
using System.Collections.Generic;

namespace EF_Core_Loadings;

public partial class Picture
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Picture1 { get; set; }

    public virtual Book Book { get; set; } = null!;
}
