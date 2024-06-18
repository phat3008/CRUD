using System;
using System.Collections.Generic;

namespace WebAppCRUD.Entities;

public partial class Lop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Khoa { get; set; }
    

    public virtual Khoa? KhoaNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
