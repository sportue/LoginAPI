using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Request
{
  public class RePassword
  {
    [Required]
    public string Code { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [MinLength(6)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Girmiş olduğunuz şifreler birbiri ile uyuşmamaktadır.")]
    public string PasswordRetry { get; set; }
  }
}
