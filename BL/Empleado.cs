using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.OTorresLeendGroupEntities context = new DL.OTorresLeendGroupEntities())
                {
                    var resultQuery = context.EmpleadoGetAll().ToList();


                    if (resultQuery != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in resultQuery)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.NOMBRE;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            //empleado.Estado = new ML.Estado();
                            //empleado.Estado.IdEstado = (int)obj.IdEstado;
                            empleado.IdEstado = (int)obj.IdEstado;

                            result.Objects.Add(empleado);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresLeendGroupEntities context = new DL.OTorresLeendGroupEntities())
                {
                    var objEmpleado = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objEmpleado != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.IdEmpleado = objEmpleado.IdEmpleado;
                        empleado.NumeroNomina = objEmpleado.NumeroNomina;
                        empleado.Nombre = objEmpleado.NOMBRE;
                        empleado.ApellidoPaterno = objEmpleado.ApellidoPaterno;
                        empleado.ApellidoMaterno = objEmpleado.ApellidoMaterno;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = objEmpleado.IdEmpleado;


                        result.Object = empleado;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error la tabla no contiene informacion ";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.OTorresLeendGroupEntities context = new DL.OTorresLeendGroupEntities())
                {
                    var resultQuery = context.EmpleadoAdd( empleado.Nombre, empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puede añadir la direccion " + empleado.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }


        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresLeendGroupEntities context = new DL.OTorresLeendGroupEntities())
                {
                    var updateResult = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.Nombre, empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno, empleado.Estado.IdEstado);

                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el empleado" + empleado.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }


        public static ML.Result Delete(int empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.OTorresLeendGroupEntities context = new DL.OTorresLeendGroupEntities())
                {
                    var updateResult = context.EmpleadoDelete(empleado);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al elimino el empleado " + empleado;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

    }
}
