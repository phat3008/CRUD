using System;
using System.Collections.Generic;

namespace WebAppCRUD.Entities;

public partial class Sinhvien
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Lop { get; set; }

    public int? Khoa { get; set; }

    public virtual Khoa? KhoaNavigation { get; set; }

    public virtual Lop? LopNavigation { get; set; }
}
