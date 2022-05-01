using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public EntityBaseResponse GetUsers()
        {

            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var users = new List<EntityUser>();

                    const string sql = "usp_ListarUsuarios";
                    users = db.Query<EntityUser>(
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
        public EntityBaseResponse GetUserByID(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var user = new EntityUser();
                    const string sql = "usp_ObtenerUsuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSER", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    user = db.Query<EntityUser>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                            ).FirstOrDefault();

                    if (user != null)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = user;
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
        public EntityBaseResponse RegistertUser(EntityUser user)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    const string sql = "usp_Registrar_Usuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSER", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@USERNAME", dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORD", dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@NAME", dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@LASTNAME", dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@BIRTH", dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@PHONE", dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@EMAIL", dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    int idusuario = p.Get<int>("@IDUSER");
                    if (idusuario > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new { id = idusuario, nombre = user.username };
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.issuccess = false;
                response.errorcode = "0001";
                response.errormessage = ex.Message;
                response.data = null;
            }
            return response;
        }
        public EntityBaseResponse Login(EntityLogin login)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var userresponse = new EntityLoginResponse();
                    const string sql = "usp_login";

                    var p = new DynamicParameters();
                    p.Add(name: "@LOGINUSER", value: login.username, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSER", value: login.password, dbType: DbType.String, direction: ParameterDirection.Input);

                    userresponse = db.Query<EntityLoginResponse>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (userresponse != null)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = userresponse;
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.issuccess = false;
                response.errorcode = "0002";
                response.errormessage = ex.Message;
                response.data = null;
            }
            return response;
        }

    }
}

