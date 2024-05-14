namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee : Base
{

    [Key]
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    [EmailAddress]
    public string EmailAddress { get; set; }

    // user id
    // comapny id

    [ForeignKey("User")]

    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Company")]
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }

}