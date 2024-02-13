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

}