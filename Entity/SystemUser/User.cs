using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Core.Enums.Enums;

namespace Entity.SystemUser
{
  public class User : BaseEntity
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    //public Guid? ActivationCode { get; set; }

    //Relations
    public virtual IList<ExternalLogin> ExternalLogins { get; set; }
    public virtual IList<ForgatPassword> ForgatPasswords { get; set; }
  }
}
