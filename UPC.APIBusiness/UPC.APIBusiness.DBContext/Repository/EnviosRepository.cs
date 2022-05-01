using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class EnviosRepository : BaseRepository, IEnviosRepository
    {
        public EntityBaseResponse GetEnvios()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var envios = new List<EntityEnvio>();

                    const string sql = "usp_Lista_de_envios";
                    envios = db.Query<EntityEnvio>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (envios.Count > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = envios;
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
        public EntityBaseResponse GetEnvioxUsuario(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    var envios = new List<EntityEnvio>();

                    const string sql = "usp_MostrarEnvios_X_Usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@IDUSER", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    envios = db.Query<EntityEnvio>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                            ).ToList();

                    if (envios != null)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = envios;
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

        public EntityBaseResponse RegistrarNuevoEnvio(EntityEnvio nuevo_envio)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnectionEnvios())
                {
                    const string sql = "usp_Registrar_Nuevo_Pedido";
                    var p = new DynamicParameters();
                    p.Add(name: "@COD_ORDEN", value: nuevo_envio.cod_orden, dbType: DbType.String, direction: ParameterDirection.Output);
                    p.Add(name: "@IDUSER", value: nuevo_envio.iduser, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@SRC_ADD", value: nuevo_envio.src_add, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@DEST_ADD", value: nuevo_envio.dest_add, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PRICE", value: nuevo_envio.price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@WEIGHT", value: nuevo_envio.weight, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@PAQUETE", value: nuevo_envio.paquete, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityUser>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    String cod_orden = p.Get<string>("@COD_ORDEN");

                    if (cod_orden != string.Empty)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormessage = string.Empty;
                        response.data = new { cod_orden = nuevo_envio.cod_orden };
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
                response.errormessage = ex.Message;
                response.data = null;
            }
            return response;
        }
    }
}
