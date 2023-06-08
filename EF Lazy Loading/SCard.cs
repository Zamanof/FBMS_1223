using System;
using System.Collections.Generic;

namespace EF_Lazy_Loading;

public partial class SCard
{
    public int Id { get; set; }

    public int IdStudent { get; set; }

    public int IdBook { get; set; }

    public DateTime DateOut { get; set; }

    public DateTime? DateIn { get; set; }

    public int IdLib { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Lib IdLibNavigation { get; set; } = null!;

    public virtual Student IdStudentNavigation { get; set; } = null!;
}
