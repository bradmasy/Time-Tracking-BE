namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Project
{

    [Key]
    public Guid Id { get; set; }
    public int Version { get; set; } = 1;

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

    //always version 1 to begin
    // version exists on this entity as the project department is what gets reconciled 
    public int Version { get; set; } = 1;

    [ForeignKey("Project")]
    public Guid ProjectId { get; set; }

    [ForeignKey("Department")]
    // [Index("IX_Unique_ProjectId", IsUnique = true)]
    public Guid DepartmentId { get; set; }

    public double? Hours { get; set; }
    public double? Actuals { get; set; }
    public double? Forecast { get; set; }
    public virtual Project? Project { get; set; }
    public virtual Department? Department { get; set; }
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


public class ProjectDepartmentQuery
{
    public string? ProjectDepartmentId { get; set; }
    public double? Hours { get; set; }
    public double? Actuals { get; set; }
    public double? Forecast { get; set; }
}

/**
* This class represents a project department that has been reconciled. A reconciled project department is a project that has been edited
* by the project manager, this means their budget, actuals, or forecast could have been changed. The updated project holds the new project data while the
* reconciled project holds the data of the one last edited.
*/
public class ReconciledProjectDepartment
{

    [Key]
    public Guid Id { get; set; }

    //always version 1 to begin
    // version exists on this entity as the project department is what gets reconciled 
    [Required]
    public int Version { get; set; }

    [Required]
    public string Message { get; set; }

    [ForeignKey("ProjectDepartment")]
    public Guid ProjectDepartmentId { get; set; }
    public double? Hours { get; set; }
    public double? Actuals { get; set; }
    public double? Forecast { get; set; }
    public virtual ProjectDepartment? ProjectDepartment { get; set; }

}