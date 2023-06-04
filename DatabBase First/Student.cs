using System;
using System.Collections.Generic;

namespace DatabBase_First;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int IdGroup { get; set; }

    public int Term { get; set; }

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual ICollection<SCard> SCards { get; set; } = new List<SCard>();
}
