using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response.Account
{
  public class AccountGetResponse
  {
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Enum Role { get; set; }
  }
}
