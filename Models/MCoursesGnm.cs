using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Mbbs2.Models;

[Keyless]
[Table("mCourses_GNM")]
public partial class MCoursesGnm
{
    [Column("GNM_CourseCode")]
    public int? GnmCourseCode { get; set; }

    [Column("GMN_Couse")]
    [StringLength(100)]
    public string? GmnCouse { get; set; }
}
