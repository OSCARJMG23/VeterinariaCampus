using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVet.Helpers
{
    public class Authorization
    {
        public enum Roles
        {
            Administrador,
            Empleado
        }
        public const Roles rol_default = Roles.Empleado;
    }
}