namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore.V1;

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

    public DateTime CreatedAt{get;set;} = DateTime.Now;
}

public class CreateProject{

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

}


public class ProjectQuery{
    public string? UserId {get;set;}
}