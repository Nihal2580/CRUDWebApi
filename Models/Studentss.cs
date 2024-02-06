using System;
using System.Collections.Generic;

namespace CRUDWebApi.Models;

public partial class Studentss
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public string Stander { get; set; } = null!;

    public string FatherName { get; set; } = null!;
}
