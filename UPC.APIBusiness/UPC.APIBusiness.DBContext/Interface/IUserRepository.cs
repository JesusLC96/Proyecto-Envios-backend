using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IUserRepository
    {
        EntityBaseResponse GetUsers();
        EntityBaseResponse GetUserByID(int id);
        EntityBaseResponse RegistertUser(EntityUser user);
        EntityBaseResponse Login(EntityLogin login);
    }
}
