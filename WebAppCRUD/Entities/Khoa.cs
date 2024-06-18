using System;
using System.Collections.Generic;

namespace WebAppCRUD.Entities;

public partial class Khoa
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
