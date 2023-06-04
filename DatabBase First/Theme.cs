using System;
using System.Collections.Generic;

namespace DatabBase_First;

public partial class Theme
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
