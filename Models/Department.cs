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

    
    // public Department(string _name, Company _company) : base()
    // {
    //     Name = _name;
    //     Company = _company;

    // }
}