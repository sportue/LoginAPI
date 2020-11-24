using Core.Mapping;
using Entity.SystemUser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping.SystemUser
{
  public class UserMapping : BaseMap<User>
  {
    public UserMapping(EntityTypeBuilder<User> builder)
    {

    }
  }
}
