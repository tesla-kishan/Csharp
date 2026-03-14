using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentMarksWebAPI.Models;

[Index("StudentId", Name = "UQ__Hostels__32C52B980A277076", IsUnique = true)]
public partial class Hostel
{
    [Key]
    public int HostelId { get; set; }

    public int? RoomNumber { get; set; }

    public string? RoomType { get; set; }   // NEW COLUMN

    public int? StudentId { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Hostel")]
    public virtual Student? Student { get; set; }
}