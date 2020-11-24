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
  public class ExternalLogin : BaseEntity
  {
    public Guid UserID { get; set; }
    public Provider ProviderName { get; set; }
    public string ProviderKey { get; set; }

    // Relationships
    
    public virtual User User { get; set; }
   
  }
}
