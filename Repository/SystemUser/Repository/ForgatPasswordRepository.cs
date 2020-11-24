using Dal;
using Entity.SystemUser;
using Repository.SystemUser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SystemUser.Repository
{
  public class ForgatPasswordRepository : BaseRepository<ForgatPassword>, IForgatPasswordRepository
  {
    public ForgatPasswordRepository(ApplicationContext context) : base(context)
    {
    }
  }
}
