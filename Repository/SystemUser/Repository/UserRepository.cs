using Dal;
using Entity.SystemUser;
using Repository.SystemUser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SystemUser.Repository
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(ApplicationContext context) : base(context)
    {
          
           
    }
  }
}
