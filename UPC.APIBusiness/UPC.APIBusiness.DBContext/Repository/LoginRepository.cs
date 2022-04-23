using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public EntityBaseResponse GetUserByID(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var project = new EntityLogin();
                    const string sql = "usp_ObtenerUsuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSER", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    project = db.Query<EntityLogin>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                            ).FirstOrDefault();

                    if (project != null)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = project;
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0007";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.issuccess = false;
                response.errorcode = "0001";
                response.errormessage = string.Empty;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse GetUsers()
        {

            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var users = new List<EntityLogin>();

                    const string sql = "usp_ListarUsuarios";
                    users = db.Query<EntityLogin>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (users.Count > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = users;
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0001";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.issuccess = false;
                response.errorcode = "0001";
                response.errormessage = string.Empty;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse InsertUser(EntityLogin login)
        {
            throw new NotImplementedException();
        }
    }
}

