using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentMarksWebAPI.Models;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public int? Age { get; set; }

    [StringLength(100)]
    public string? Course { get; set; }

    [InverseProperty("Student")]
    public virtual Hostel? Hostel { get; set; }
}
