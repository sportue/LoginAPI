
using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Core.Enums.Enums;

namespace Entity.SystemUser
{
  public class ForgatPassword : BaseEntity
  {
    public Guid UserID { get; set; }
    public string Key { get; set; }


    // Relationships

    public virtual User User { get; set; }

  }
}
