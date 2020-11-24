using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Request
{
  public class SignUpRequest
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "şifreler aynı değil")]
    public string PasswordRetry { get; set; }

  }
}
