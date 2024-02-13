namespace app_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Company: Base
{

    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }

}