using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface ILoginRepository
    {
        EntityBaseResponse GetUsers();
        EntityBaseResponse GetUserByID(int id);
        EntityBaseResponse InsertUser(EntityLogin login);
    }
}
