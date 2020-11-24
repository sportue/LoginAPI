using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.Account
{
  public class AccountCreateResponse
  {
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PasswordRetry { get; set; }

  }
}
