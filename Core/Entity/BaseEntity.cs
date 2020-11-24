using System;
using System.Collections.Generic;
using System.Text;
using static Core.Enums.Enums;

namespace Core.Entity
{
    //POCO
  public class BaseEntity
  {
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public RecordStatus RecordStatus { get; set; }
  }
}
