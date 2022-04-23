using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;


namespace DBContext
{
    public interface IEnviosRepository
    {
        EntityBaseResponse GetEnvios();
        EntityBaseResponse GetEnvioxUsuario(int id);
    }
}
