using Core.Mapping;
using Entity.SystemUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.SystemUser
{
  public class ExternalLoginMapping : BaseMap<ExternalLogin>
  {
    public ExternalLoginMapping(EntityTypeBuilder<ExternalLogin> builder)
    {
      builder.HasOne(x => x.User).WithMany(x => x.ExternalLogins).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Restrict);

    }

  }
}
