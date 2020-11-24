using Dal;
using Entity.SystemUser;
using Repository.SystemUser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SystemUser.Repository
{
  public class ExternalLoginRepository : BaseRepository<ExternalLogin>, IExternalLoginRepository
  {
    public ExternalLoginRepository(ApplicationContext context) : base(context)
    {
    }
  }
}
