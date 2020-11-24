using Core.Entity;
using Entity.SystemUser;
using Mapping.SystemUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Enums.Enums;

namespace Dal
{
  public class ApplicationContext : DbContext
  {
      public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);

       //SYSTEMUSER FOLDER

       new ExternalLoginMapping(builder.Entity<ExternalLogin>());
       new UserMapping(builder.Entity<User>());
       new ForgatPasswordMapping(builder.Entity<ForgatPassword>());

      }

      public override int SaveChanges()
      {
        ChangeTracker.DetectChanges();
        if (ChangeTracker.HasChanges())
        {
          foreach (var item in ChangeTracker.Entries())
          {
            var temp = (BaseEntity)item.Entity;
            switch (item.State)
            {
              case EntityState.Detached:
                break;
              case EntityState.Unchanged:
                break;
              case EntityState.Added:
                temp.RecordStatus = RecordStatus.Active;
                temp.CreateDate = DateTime.UtcNow;
                temp.UpdateDate = DateTime.UtcNow;
                break;
              case EntityState.Deleted:
                temp.RecordStatus = RecordStatus.Deleted;
                temp.UpdateDate = DateTime.UtcNow;
                break;
              case EntityState.Modified:
                temp.UpdateDate = DateTime.UtcNow;
                break;
              default:
                break;
            }
          }
        }
        return base.SaveChanges();
     }
  }
}

