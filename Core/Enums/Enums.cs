using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enums
{
  public class Enums
  {
    public enum Role
    {
      User = 0,
      Admin = 1,
      Moderator = 2
    }
    public enum RecordStatus
    {
      Active = 0,
      Deleted = 1,
      InActive = 2,
    }
    public enum Provider
    {
      Facebook = 1,
      GooglePlus = 2,
      Twitter = 3,
      Instagram = 4
    }


    public enum Status
    {
      NotAppproved = 0,
      Approved = 1
    }

  }
}
