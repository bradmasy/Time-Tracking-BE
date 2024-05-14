namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Tokens;

public class Department : Base
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("Company")]
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }


}


public class DepartmentQuery {
    public string? ProjectId {get;set;}
    public string? DepartmentId{get;set;}

    public string? CompanyId {get;set;}
}