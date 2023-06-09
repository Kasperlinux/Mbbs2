using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mbbs2.Models;

[Table("mApplicationStatus")]
public partial class MApplicationStatus
{
    [Key]
    public int ApplicationStatus { get; set; }

    [Column("ApplicationStatus_Desc")]
    [StringLength(20)]
    public string? ApplicationStatusDesc { get; set; }
}
