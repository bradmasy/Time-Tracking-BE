namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project
{

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public double Budget { get; set; } = 00.00;
    [Required]

    public DateTime StartDate { get; set; }
    [Required]
    public DateTime FinishDate { get; set; }
    [Required]
    public double ProjectHours { get; set; }
    public string Description { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

}

public class ProjectDepartment
{
    [Key]
    public Guid Id { get; set; }

    // Foreign keys
    public Guid ProjectId { get; set; }
    public Guid DepartmentId { get; set; }

    // Navigation properties
    public virtual Project Project { get; set; }
    public virtual Department Department { get; set; }
}

public class CreateProject
{

    [Required]
    public string Name { get; set; }

    public Guid UserId { get; set; }

    public double Budget { get; set; } = 00.00;
    [Required]

    public DateTime StartDate { get; set; }
    [Required]
    public DateTime FinishDate { get; set; }
    [Required]
    public double ProjectHours { get; set; }
    public string Description { get; set; } = "";


}


public class ProjectQuery
{
    public string? projectId { get; set; }
}


// public class ProjectDepartmentQuery{
//     public string? projectI
// }