using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace app_api.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    [Required]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [EmailAddress]
    public string EmailAddress { get; set; }
    [Required]
    public string Password { get; set; }
}


public class UserLogin
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}


public class UserSignup
{
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    public string? Email {get; set;}
    public string? Username { get; set; }
    public string? Password { get; set; }

}